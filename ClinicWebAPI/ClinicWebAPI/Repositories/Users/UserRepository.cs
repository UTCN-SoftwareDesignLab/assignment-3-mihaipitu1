using ClinicWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicWebAPI.Repositories.Users
{
    public interface IUserRepository : IBaseRepository<User>
    {
        User FindByUsernameAndPassword(string username, string password);
    }
}
