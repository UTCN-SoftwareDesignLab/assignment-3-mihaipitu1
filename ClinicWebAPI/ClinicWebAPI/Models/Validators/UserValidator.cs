using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ClinicWebAPI.Models.Validators
{
    public class UserValidator
    {
        private Regex email_regex = new Regex("^[a-zA-Z0-9_!#$%&'*+/=?`{|}~^.-]+@[a-zA-Z0-9.-]+$");
        private static int MIN_PASSWORD_LENGTH = 8;
        private static int MAX_PASSWORD_LENGTH = 20;

        private List<string> errors;
        private User user;

        public UserValidator(User user)
        {
            this.user = user;
            errors = new List<string>();
        }

        public List<string> GetErrors()
        {
            return errors;
        }

        public bool Validate()
        {
            ValidateUsername(user.GetUsername());
            ValidatePassword(user.GetPassword());
            return errors.Capacity == 0;
        }

        private void ValidateUsername(string username)
        {
            Match match = email_regex.Match(username);
            if (!match.Success)
            {
                errors.Add("Invalid Username!");
            }
        }

        private void ValidatePassword(string password)
        {
            if (password.Length < MIN_PASSWORD_LENGTH)
            {
                errors.Add("Password is too short!");
            }
            if (password.Length > MAX_PASSWORD_LENGTH)
            {
                errors.Add("Password is too long!");
            }
            if (!ContainsSpecialCharacters(password))
            {
                errors.Add("Password must contain at least one special character!");
            }
            if (!ContainsDigit(password))
            {
                errors.Add("Password must contain at least one digit!");
            }
        }

        private bool ContainsSpecialCharacters(string s)
        {
            if (s == null)
                return false;
            Regex reg = new Regex("[^A-Za-z0-9]");
            Match mat = reg.Match(s);
            return !mat.Success;
        }

        private bool ContainsDigit(string s)
        {
            foreach (char c in s.ToCharArray())
            {
                if (Char.IsDigit(c))
                    return true;
            }
            return false;
        }
    }
}
