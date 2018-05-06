using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicWebAPI.Models.Validators
{
    public class Notification<T>
    {
        private T result;
        private List<string> errors;

        public Notification()
        {
            errors = new List<string>();
        }

        public void AddError(string message)
        {
            errors.Add(message);
        }

        public bool HasErrors()
        {
            return errors.Capacity > 0;
        }

        public void SetResult(T result)
        {
            this.result = result;
        }

        public T GetResult()
        {
            return result;
        }

        public List<string> GetErrors()
        {
            return errors;
        }
    }
}
