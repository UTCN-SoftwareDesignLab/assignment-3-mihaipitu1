using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicWebAPI.Models.Builders
{
    public class ConsultationBuilder
    {
        private Consultation consultation;

        public ConsultationBuilder()
        {
            consultation = new Consultation();
        }

        public ConsultationBuilder SetId(long id)
        {
            consultation.SetId(id);
            return this;
        }

        public ConsultationBuilder SetAppointmentDate(DateTime appointmentDate)
        {
            consultation.SetAppointmentDate(appointmentDate);
            return this;
        }

        public ConsultationBuilder SetPatientId(long patientId)
        {
            consultation.SetPatientId(patientId);
            return this;
        }

        public ConsultationBuilder SetDoctorId(long doctorId)
        {
            consultation.SetDoctorId(doctorId);
            return this;
        }

        public Consultation Build()
        {
            return consultation;
        }
    }
}
