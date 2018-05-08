using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicWebAPI.Models;
using ClinicWebAPI.Services.Consultations;
using ClinicWebAPI.Services.Patients;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ClinicWebAPI.Controllers
{
    public class ClinicController : Controller
    {
        private IPatientService patientService;
        private IConsultationService consultationService;

        public ClinicController(IPatientService patientService,IConsultationService consultationService)
        {
            this.patientService = patientService;
            this.consultationService = consultationService;
        }
        // GET: Patient
        public ActionResult Patients()
        {
            var patients = patientService.GetPatients();
            return View(patients);
        }

        public ActionResult Consultations()
        {
            var consultations = consultationService.GetConsultations();
            return View(consultations);
        }

        // GET: Patient/Create
        public ActionResult CreatePatient()
        {
            return View();
        }

        // POST: Patient/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreatePatient(Patient patient)
        {
            patientService.CreatePatient(patient);
            return RedirectToAction("Patients");
        }

        public ActionResult CreateConsultation()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateConsultation(Consultation consultation)
        {
            consultation.SetDoctorId(consultation.GetDoctor().GetId());
            consultation.SetPatientId(consultation.GetPatient().GetId());
            consultationService.CreateConsultation(consultation);
            return RedirectToAction("Consultations");
        }

        // GET: Patient/Edit/5
        public ActionResult EditPatient(int id)
        {
            var patient = patientService.GetPatientById(id);
            return View(patient);
        }

        // POST: Patient/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditPatient(Patient patient)
        {
            patientService.UpdatePatient(patient);
            return RedirectToAction("Patients");
        }

        // GET: Patient/Edit/5
        public ActionResult EditConsultation(int id)
        {
            var consultation = consultationService.GetConsultationById(id);
            return View(consultation);
        }

        // POST: Patient/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditConsultation(Consultation consultation)
        {
            consultationService.UpdateConsultation(consultation);
            return RedirectToAction("Consultations");
        }

        // GET: Patient/Delete/5
        public ActionResult DeletePatient(int id)
        {
            var patient = patientService.GetPatientById(id);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePatient(Patient patient)
        {
            patientService.DeletePatient(patient);
            return RedirectToAction("Patients");
        }

        public ActionResult DeleteConsultation(int id)
        {
            var consultation = consultationService.GetConsultationById(id);
            return View(consultation);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConsultation(Consultation consultation)
        {
            consultationService.DeleteConsultation(consultation);
            return RedirectToAction("Consultations");
        }
    }
}