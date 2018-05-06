using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicWebAPI.Models.Builders
{
    public class PatientBuilder
    {
        private Patient patient;

        public PatientBuilder()
        {
            patient = new Patient();
        }

        public PatientBuilder SetId(long id)
        {
            patient.SetId(id);
            return this;
        }

        public PatientBuilder SetName(string name)
        {
            patient.SetName(name);
            return this;
        }

        public PatientBuilder SetIdCardNo(string idCardNo)
        {
            patient.SetIdCardNo(idCardNo);
            return this;
        }

        public PatientBuilder SetAddress(string address)
        {
            patient.SetAddress(address);
            return this;
        }

        public PatientBuilder SetBirthDate(DateTime birthDate)
        {
            patient.SetBirthDate(birthDate);
            return this;
        }

        public Patient Build()
        {
            return patient;
        }
    }
}
