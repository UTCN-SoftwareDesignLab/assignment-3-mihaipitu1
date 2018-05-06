using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicWebAPI.Repositories
{
    public interface IBaseRepository<T>
    {
        List<T> FindAll();

        T FindById(long id);

        bool Create(T t);

        bool Update(T t);

        bool Delete(T t);
    }
}
