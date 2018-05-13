using ClinicWebAPI.Models;
using ClinicWebAPI.Models.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicWebAPI.Services.Consultations
{
    public interface IConsultationService
    {
        Notification<bool> CreateConsultation(Consultation consultation);

        bool UpdateConsultation(Consultation consultation);

        bool DeleteConsultation(Consultation consultation);

        List<Consultation> GetConsultations();

        Consultation GetConsultationById(long id);

        List<Consultation> GetConsultationsByDoctor(User doctor);

        List<Consultation> GetConsultationsByPatient(Patient patient);
    }
}
