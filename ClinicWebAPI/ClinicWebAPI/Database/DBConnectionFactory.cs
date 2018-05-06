using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicWebAPI.Database
{
    public class DBConnectionFactory
    {
        public DBConnectionWrapper GetConnectionWrapper(bool test)
        {
            if (test)
            {
                return new DBConnectionWrapper("clinic_test");
            }
            return new DBConnectionWrapper("clinic");
        }
    }
}
