using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicWebAPI.Models;
using ClinicWebAPI.Models.Builders;
using ClinicWebAPI.Services.Consultations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ClinicWebAPI.Controllers
{
    public class DoctorController : Controller
    {
        private IConsultationService consultationService;

        public DoctorController(IConsultationService consultationService)
        {
            this.consultationService = consultationService;
        }

        public ActionResult Consultations()
        {
            if (TempData["user"] != null)
            {
                var userJson = JsonConvert.DeserializeObject(TempData["user"].ToString());
                JToken token = JObject.Parse(userJson.ToString());
                var user = new UserBuilder()
                    .SetId((long)token.SelectToken("Id"))
                    .Build();
                var consultations = consultationService.GetConsultationsByDoctor(user);
                return View(consultations);
            }
            return StatusCode(404);
        }

        public ActionResult PatientConsultations(int id)
        {
            Patient patient = new PatientBuilder()
                .SetId(id)
                .Build();
            var consultations = consultationService.GetConsultationsByPatient(patient);
            TempData["user"] = JsonConvert.SerializeObject(consultations.ElementAt(0).GetDoctor());
            return View(consultations);
        }
    }
}