using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicWebAPI.Models
{
    public class Consultation
    {
        private long id;
        private DateTime appointmentDate;
        private long patientId;
        private long doctorId;
        private Patient patient;
        private User doctor;

        public long GetId()
        {
            return id;
        }
        public void SetId(long id)
        {
            this.id = id;
        }
        public long Id
        {
            get { return GetId(); }
            set { SetId(value); }
        }

        public DateTime GetAppointmentDate()
        {
            return appointmentDate;
        }
        public void SetAppointmentDate(DateTime appointmentDate)
        {
            this.appointmentDate = appointmentDate;
        }
        public DateTime AppointmentDate
        {
            get {return GetAppointmentDate(); }
            set { SetAppointmentDate(value); }
        }

        public long GetPatientId()
        {
            return id;
        }
        public void SetPatientId(long id)
        {
            this.id = id;
        }
        public long GetDoctorId()
        {
            return id;
        }
        public void SetDoctorId(long id)
        {
            this.id = id;
        }

        public Patient GetPatient()
        {
            return patient;
        }
        public void SetPatient(Patient patient)
        {
            this.patient = patient;
        }
        public Patient Patient
        {
            get { return GetPatient(); }
            set { SetPatient(value); }
        }

        public User GetDoctor()
        {
            return doctor;
        }
        public void SetDoctor(User doctor)
        {
            this.doctor = doctor;
        }
        public User Doctor
        {
            get { return GetDoctor(); }
            set { SetDoctor(value); }
        }
    }
}
