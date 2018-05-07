using ClinicWebAPI.Models;
using ClinicWebAPI.Models.Builders;
using ClinicWebAPI.Models.Validators;
using ClinicWebAPI.Repositories.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace ClinicWebAPI.Services.Users
{
    public class AdminServiceMySQL : IAdminService
    {
        private IUserRepository userRepo;

        public AdminServiceMySQL(IUserRepository userRepo)
        {
            this.userRepo = userRepo;
        }

        public bool DeleteUser(User user)
        {
            return userRepo.Delete(user);
        }

        public List<User> GetUsers()
        {
            return userRepo.FindAll();
        }

        public Notification<bool> Register(User user)
        {
            UserValidator userValidator = new UserValidator(user);
            bool userValid = userValidator.Validate();
            Notification<bool> notifier = new Notification<bool>();

            if (!userValid)
            {
                foreach (var error in userValidator.GetErrors())
                {
                    notifier.AddError(error);
                }
                notifier.SetResult(false);
            }
            else
            {
                user.SetId(GetMaxId()+1);
                user.SetPassword(EncodePassword(user.GetPassword()));
                notifier.SetResult(userRepo.Create(user));
            }
            return notifier;

        }

        public User GetUserById(long id)
        {
            return userRepo.FindById(id);
        }

        private string EncodePassword(string password)
        {
            SHA256 sha256 = new SHA256Managed();
            byte[] sha256Bytes = System.Text.Encoding.Default.GetBytes(password);
            byte[] cryString = sha256.ComputeHash(sha256Bytes);
            string sha256Str = string.Empty;
            foreach (byte b in cryString)
            {
                sha256Str += b.ToString("x");

            }
            return sha256Str;
        }

        private long GetMaxId()
        {
            List<User> users = userRepo.FindAll();
            if (users.Capacity == 0)
                return 1;
            else
            {
                long max = users.ElementAt(0).GetId();
                foreach (User user in users)
                {
                    if (max < user.GetId())
                        max = user.GetId();
                }
                return max;
            }
        }


        public bool UpdateUser(User user)
        {
            string oldPass = userRepo.FindById(user.GetId()).GetPassword();
            if(!oldPass.Equals(EncodePassword(user.GetPassword())))
            {
                user.SetPassword(EncodePassword(user.GetPassword()));
            }
            return userRepo.Update(user);
        }
    }
}
