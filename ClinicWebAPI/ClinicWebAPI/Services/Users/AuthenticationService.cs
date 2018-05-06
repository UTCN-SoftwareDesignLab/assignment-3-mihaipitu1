using ClinicWebAPI.Models;
using ClinicWebAPI.Models.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicWebAPI.Services.Users
{
    public interface IAuthenticationService
    {
        Notification<User> Login(string username, string password);
    }
}
