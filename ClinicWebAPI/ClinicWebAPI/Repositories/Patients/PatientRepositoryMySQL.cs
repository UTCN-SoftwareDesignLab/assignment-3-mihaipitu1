using ClinicWebAPI.Database;
using ClinicWebAPI.Models;
using ClinicWebAPI.Models.Builders;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicWebAPI.Repositories.Patients
{
    public class PatientRepositoryMySQL : IBaseRepository<Patient>
    {
        private DBConnectionWrapper connectionWrapper;

        public PatientRepositoryMySQL(DBConnectionWrapper connectionWrapper)
        {
            this.connectionWrapper = connectionWrapper;
        }

        public bool Create(Patient t)
        {
            if(t == null)
                return false;
            using (MySqlConnection connection = connectionWrapper.GetConnection())
            {
                connection.Open();
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = String.Format("Insert into patient (id, name, idCardNo, address, birthDate) VALUES('{0}', '{1}', '{2}', '{3}', '{4}'); ", t.GetId(), t.GetName(), t.GetIdCardNo(), t.GetAddress(), t.GetBirthDate().ToString("yyyy-MM-dd HH:mm:ss"));
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
            return true;
        }

        public bool Delete(Patient t)
        {
            if (t == null)
                return false;
            using (MySqlConnection connection = connectionWrapper.GetConnection())
            {
                connection.Open();
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = String.Format("Delete from patient where id = {0};", t.GetId());
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
            return true;
        }

        public List<Patient> FindAll()
        {
            List<Patient> patients = new List<Patient>();
            using (MySqlConnection connection = connectionWrapper.GetConnection())
            {
                connection.Open();
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = String.Format("Select * from patient");
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        patients.Add(BuildFromReader(reader));
                    }
                }
                connection.Close();
            }
            return patients;
        }

        public Patient FindById(long id)
        {
            Patient patient = null;
            using (MySqlConnection connection = connectionWrapper.GetConnection())
            {
                connection.Open();
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = String.Format("Select * from patient where id = '{0}'",id);
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        patient = BuildFromReader(reader);
                    }
                }
                connection.Close();
            }
            return patient;
        }

        public bool Update(Patient t)
        {
            if (FindById(t.GetId()) == null)
                return false;
            else
            {
                using (MySqlConnection connection = connectionWrapper.GetConnection())
                {
                    connection.Open();
                    using (MySqlCommand command = connection.CreateCommand())
                    {
                        command.CommandText = String.Format("UPDATE patient SET name = '{0}' ,idCardNo = '{1}' ,address = '{2}' ,birthDate = '{3}' WHERE id = '{4}';", t.GetName(), t.GetIdCardNo(), t.GetAddress(), t.GetBirthDate().ToString("yyyy-MM-dd HH:mm:ss"), t.GetId());
                        command.ExecuteNonQuery();
                    }
                    connection.Close();
                }
                return true;
            }
        }

        private Patient BuildFromReader(MySqlDataReader reader)
        {
            return new PatientBuilder()
                .SetId(reader.GetInt64(0))
                .SetName(reader.GetString(1))
                .SetIdCardNo(reader.GetString(2))
                .SetAddress(reader.GetString(3))
                .SetBirthDate(reader.GetDateTime(4))
                .Build();
        }
    }
}
