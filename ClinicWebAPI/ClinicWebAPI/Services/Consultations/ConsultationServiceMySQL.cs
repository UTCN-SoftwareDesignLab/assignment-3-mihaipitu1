using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicWebAPI.Models;
using ClinicWebAPI.Models.Validators;
using ClinicWebAPI.Repositories;
using ClinicWebAPI.Repositories.Consultations;
using ClinicWebAPI.Repositories.Users;

namespace ClinicWebAPI.Services.Consultations
{
    public class ConsultationServiceMySQL : IConsultationService
    {
        private IConsultationRepository consultationRepo;
        private IBaseRepository<Patient> patientRepo;
        private IUserRepository userRepo;

        public ConsultationServiceMySQL(IConsultationRepository consultationRepo,IBaseRepository<Patient> patientRepo, IUserRepository userRepo)
        {
            this.consultationRepo = consultationRepo;
            this.patientRepo = patientRepo;
            this.userRepo = userRepo;
        }

        public Notification<bool> CreateConsultation(Consultation consultation)
        {
            consultation.SetId(GetMaxId() + 1);
            consultation.SetDoctorId(consultation.GetDoctor().Id);
            consultation.SetPatientId(consultation.GetPatient().Id);
            consultation.SetDoctor(userRepo.FindById(consultation.GetDoctorId()));
            consultation.SetPatient(patientRepo.FindById(consultation.GetPatientId()));
            ConsultationValidator validator = new ConsultationValidator(consultation);
            Notification<bool> notifier = new Notification<bool>();
            bool validity = validator.Validate();
            if (!validity)
            {
                foreach (var error in validator.GetErrors())
                {
                    notifier.AddError(error);
                }
                notifier.SetResult(false);
            }
            else
            {
                consultationRepo.Create(consultation);
            }
            return notifier;
        }

        public bool DeleteConsultation(Consultation consultation)
        {
            return consultationRepo.Delete(consultation);
        }

        public Consultation GetConsultationById(long id)
        {
            Consultation consultation = consultationRepo.FindById(id);
            consultation.SetDoctor(userRepo.FindById(consultation.GetDoctorId()));
            consultation.SetPatient(patientRepo.FindById(consultation.GetPatientId()));
            return consultation;
        }

        public List<Consultation> GetConsultations()
        {
            List<Consultation> consultations = consultationRepo.FindAll();
            foreach(var consultation in consultations)
            {
                consultation.SetDoctor(userRepo.FindById(consultation.GetDoctorId()));
                consultation.SetPatient(patientRepo.FindById(consultation.GetPatientId()));
            }
            return consultations;
        }

        public List<Consultation> GetConsultationsByDoctor(User doctor)
        {
            List<Consultation> consultations = consultationRepo.FindByDoctor(doctor);
            foreach (var consultation in consultations)
            {
                consultation.SetDoctor(userRepo.FindById(consultation.GetDoctorId()));
                consultation.SetPatient(patientRepo.FindById(consultation.GetPatientId()));
            }
            return consultations;
        }

        public List<Consultation> GetConsultationsByPatient(Patient patient)
        {
            List<Consultation> consultations = consultationRepo.FindByPatient(patient);
            foreach (var consultation in consultations)
            {
                consultation.SetDoctor(userRepo.FindById(consultation.GetDoctorId()));
                consultation.SetPatient(patientRepo.FindById(consultation.GetPatientId()));
            }
            return consultations;
        }

        public bool UpdateConsultation(Consultation consultation)
        {
            return consultationRepo.Update(consultation);
        }

        private long GetMaxId()
        {
            List<Consultation> consultations = consultationRepo.FindAll();
            long id = 0;
            foreach(var consultation in consultations)
            {
                if (id < consultation.Id)
                    id = consultation.Id;
            }
            return id;
        }
    }
}
