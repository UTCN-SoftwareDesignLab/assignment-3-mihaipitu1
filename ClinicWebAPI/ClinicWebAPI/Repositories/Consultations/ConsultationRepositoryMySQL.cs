using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicWebAPI.Database;
using ClinicWebAPI.Models;
using ClinicWebAPI.Models.Builders;
using MySql.Data.MySqlClient;

namespace ClinicWebAPI.Repositories.Consultations
{
    public class ConsultationRepositoryMySQL : IConsultationRepository
    {
        private DBConnectionWrapper connectionWrapper;

        public ConsultationRepositoryMySQL(DBConnectionWrapper connectionWrapper)
        {
            this.connectionWrapper = connectionWrapper;
        }

        public bool Create(Consultation t)
        {
            if (t == null)
                return false;
            using (MySqlConnection connection = connectionWrapper.GetConnection())
            {
                connection.Open();
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = String.Format("Insert into consultation (id, appointmentDate, user_id, patient_id) VALUES('{0}', '{1}', '{2}', '{3}'); ", t.GetId(), t.GetAppointmentDate().ToString("yyyy-MM-dd HH:mm:ss"), t.GetDoctor().Id, t.GetPatient().Id);
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
            return true;
        }

        public bool Delete(Consultation t)
        {
            if (t == null)
                return false;
            using (MySqlConnection connection = connectionWrapper.GetConnection())
            {
                connection.Open();
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = String.Format("Delete from consultation where id = '{0}';", t.GetId());
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
            return true;
        }

        public List<Consultation> FindAll()
        {
            List<Consultation> consultations = new List<Consultation>();
            using (MySqlConnection connection = connectionWrapper.GetConnection())
            {
                connection.Open();
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = String.Format("Select * from consultation");
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        consultations.Add(BuildFromReader(reader));
                    }
                }
                connection.Close();
            }
            return consultations;
        }

        public List<Consultation> FindByDoctor(User user)
        {
            List<Consultation> consultations = new List<Consultation>();
            using (MySqlConnection connection = connectionWrapper.GetConnection())
            {
                connection.Open();
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = String.Format("Select * from consultation where user_id = '{0}'",user.GetId());
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        consultations.Add(BuildFromReader(reader));
                    }
                }
                connection.Close();
            }
            return consultations;
        }

        public Consultation FindById(long id)
        {
            Consultation consultation = new Consultation();
            using (MySqlConnection connection = connectionWrapper.GetConnection())
            {
                connection.Open();
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = String.Format("Select * from consultation where id = '{0}'",id);
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        consultation = BuildFromReader(reader);
                    }
                }
                connection.Close();
            }
            return consultation;
        }

        public List<Consultation> FindByPatient(Patient patient)
        {
            List<Consultation> consultations = new List<Consultation>();
            using (MySqlConnection connection = connectionWrapper.GetConnection())
            {
                connection.Open();
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = String.Format("Select * from consultation where patient_id = '{0}'",patient.GetId());
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        consultations.Add(BuildFromReader(reader));
                    }
                }
                connection.Close();
            }
            return consultations;
        }

        public bool Update(Consultation t)
        {
            if (t == null)
                return false;
            using (MySqlConnection connection = connectionWrapper.GetConnection())
            {
                connection.Open();
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = String.Format("Update consultation SET appointmentDate = '{0}', user_id ='{1}', patient_id='{2}' where id='{3}'; ", t.GetAppointmentDate().ToString("yyyy-MM-dd HH:mm:ss"), t.GetPatientId(), t.GetDoctorId(), t.GetId());
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
            return true;
        }

        private Consultation BuildFromReader(MySqlDataReader reader)
        {
            return new ConsultationBuilder()
                .SetId(reader.GetInt64(0))
                .SetAppointmentDate(reader.GetDateTime(1))
                .SetDoctorId(reader.GetInt64(2))
                .SetPatientId(reader.GetInt64(3))
                .Build();
        }
    }
}
