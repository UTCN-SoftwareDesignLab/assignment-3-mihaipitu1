using ClinicWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicWebAPI.Repositories.Consultations
{
    public interface IConsultationRepository : IBaseRepository<Consultation>
    {
        List<Consultation> FindByPatient(Patient patient);

        List<Consultation> FindByDoctor(User user);
    }
}
