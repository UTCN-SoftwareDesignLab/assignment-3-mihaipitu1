using ClinicWebAPI.Database;
using ClinicWebAPI.Models;
using ClinicWebAPI.Models.Builders;
using ClinicWebAPI.Repositories;
using ClinicWebAPI.Repositories.Patients;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClinicWebAPI.Tests.Repository
{
    [TestClass]
    public class PatientRepositoryTest
    {
        private IBaseRepository<Patient> patientRepo;

        public PatientRepositoryTest()
        {
            patientRepo = new PatientRepositoryMySQL(new DBConnectionFactory().GetConnectionWrapper(true));
        }

        public void RemoveAll()
        {
            List<Patient> users = patientRepo.FindAll();

            foreach (var user in users)
            {
                patientRepo.Delete(user);
            }
        }

        [TestMethod]
        public void TestFindAllUsers()
        {
            RemoveAll();
            List<Patient> users = patientRepo.FindAll();
            Assert.AreEqual(users.Count, 0);
        }

        [TestMethod]
        public void TestCreatePatient()
        {
            RemoveAll();
            Patient patient = new PatientBuilder().Build();
            Assert.IsTrue(patientRepo.Create(patient));
            RemoveAll();
        }

        [TestMethod]
        public void TestUpdatePatient()
        {
            RemoveAll();
            Patient patient = new PatientBuilder().Build();
            patientRepo.Create(patient);
            patient.SetName("name");
            Assert.IsTrue(patientRepo.Update(patient));
            RemoveAll();
        }

        [TestMethod]
        public void TestDeletePatient()
        {
            RemoveAll();
            Patient patient = new PatientBuilder().Build();
            patientRepo.Create(patient);
            Assert.IsTrue(patientRepo.Delete(patient));
            RemoveAll();
        }

        [TestMethod]
        public void TestFindAllUsersById()
        {
            RemoveAll();
            Patient users = patientRepo.FindById(0);
            Assert.IsNull(users);
        }
    }
}
