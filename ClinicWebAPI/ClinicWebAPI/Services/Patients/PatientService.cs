using ClinicWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicWebAPI.Services.Patients
{
    public interface IPatientService
    {
        bool CreatePatient(Patient patient);

        bool UpdatePatient(Patient patient);

        bool DeletePatient(Patient patient);

        List<Patient> GetPatients();

        Patient GetPatientById(long id);
    }
}
