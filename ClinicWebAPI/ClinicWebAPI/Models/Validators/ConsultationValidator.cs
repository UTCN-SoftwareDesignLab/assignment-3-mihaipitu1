using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicWebAPI.Models.Validators
{
    public class ConsultationValidator
    {
        private List<string> errors;
        private Consultation consultation;

        public ConsultationValidator(Consultation consultation)
        {
            this.consultation = consultation;
            errors = new List<string>();
        }

        public List<string> GetErrors()
        {
            return errors;
        }

        public bool Validate()
        {
            ValidateDoctor(consultation.GetDoctor());
            ValidatePatient(consultation.GetPatient());
            return errors.Count == 0;
        }

        private void ValidateDoctor(User user)
        {
            if(user.GetType() == null || !user.GetType().Equals("doctor"))
            {
                errors.Add("Error! The user you chose is not a doctor.");
            }
        }

        private void ValidatePatient(Patient patient)
        {
            if(patient.GetName() == null)
            {
                errors.Add("The patient does not exist in the clinic database.");
            }
        }
    }
}
