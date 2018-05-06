using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using ClinicWebAPI.Models;
using ClinicWebAPI.Models.Builders;
using ClinicWebAPI.Models.Validators;
using ClinicWebAPI.Repositories.Users;

namespace ClinicWebAPI.Services.Users
{
    public class AuthenticationServiceMySQL : IAuthenticationService
    {
        private IUserRepository userRepo;

        public AuthenticationServiceMySQL(IUserRepository userRepo)
        {
            this.userRepo = userRepo;
        }

        public Notification<User> Login(string username, string password)
        {
            User user = new UserBuilder()
                .SetUsername(username)
                .SetPassword(password)
                .Build();
            UserValidator validator = new UserValidator(user);
            Notification<User> notifier = new Notification<User>();

            if (!validator.Validate())
            {
                foreach (var error in validator.GetErrors())
                {
                    notifier.AddError(error);
                }
                notifier.SetResult(null);
            }
            else
            {
                user = userRepo.FindByUsernameAndPassword(username, EncodePassword(password));
                notifier.SetResult(user);
            }

            return notifier;
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
    }
}
