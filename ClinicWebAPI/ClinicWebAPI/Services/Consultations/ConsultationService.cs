using ClinicWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicWebAPI.Services.Consultations
{
    public interface IConsultationService
    {
        bool CreateConsultation(Consultation consultation);

        bool UpdateConsultation(Consultation consultation);

        bool DeleteConsultation(Consultation consultation);

        List<Consultation> GetConsultations();

        Consultation GetConsultationById(long id);

        List<Consultation> GetConsultationsByDoctor(User doctor);

        List<Consultation> GetConsultationsByPatient(Patient patient);
    }
}
