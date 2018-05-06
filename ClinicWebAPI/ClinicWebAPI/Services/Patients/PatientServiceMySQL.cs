﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicWebAPI.Models;
using ClinicWebAPI.Repositories;

namespace ClinicWebAPI.Services.Patients
{
    public class PatientServiceMySQL : IPatientService
    {
        private IBaseRepository<Patient> patientRepo;

        public PatientServiceMySQL(IBaseRepository<Patient> patientRepo)
        {
            this.patientRepo = patientRepo;
        }

        public bool CreatePatient(Patient patient)
        {
            return patientRepo.Create(patient);
        }

        public bool DeletePatient(Patient patient)
        {
            return patientRepo.Delete(patient);
        }

        public Patient GetPatientById(long id)
        {
            return patientRepo.FindById(id);
        }

        public List<Patient> GetPatients()
        {
            return patientRepo.FindAll();
        }

        public bool UpdatePatient(Patient patient)
        {
            return patientRepo.Update(patient);
        }
    }
}
