using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PDHClient.DTO;
using PDHClient.Models;

namespace PDHClient.Controllers
{
    public class PatientController : Controller
    {
        private readonly string apiUrl = "https://localhost:44335/";
        private HttpResponseMessage response;

        public PatientController() { }


        HttpClient client = new HttpClient();

        public async Task<IActionResult> Index()
        {
            try
            {
                List<PatientsDTO> patient = new List<PatientsDTO>();
                response = client.GetAsync(apiUrl + APIAddress.AllPatients).Result;

                if (response.IsSuccessStatusCode)
                {
                    patient = JsonConvert.DeserializeObject<List<PatientsDTO>>(response.Content.ReadAsStringAsync().Result);
                }

                return View(patient);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home");
            }

        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new PatientsDTO();
            MapDropDown(model);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(PatientsDTO model)
        {
            try
            {
                if (model == null)
                {
                    return BadRequest("Enter required fields");
                }

                response = await client.PostAsJsonAsync(apiUrl + APIAddress.CreatePatients, model);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }

                return View();
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }

        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                PatientsDTO model = new PatientsDTO();

                response = await client.GetAsync(apiUrl + APIAddress.PatientEdit + id);
                if (response.IsSuccessStatusCode)
                {
                    model = response.Content.ReadFromJsonAsync<PatientsDTO>().Result;
                }

                MapDropDown(model);

                return View(model);

            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }
        }



        [HttpGet]
        public async Task<JsonResult> Delete(int id)
        {
            int result = 0;
            string message = string.Empty;
            try
            {

                if (id == null)
                {
                    message = "Id not found";
                }


                //response = await client.DeleteAsync(apiUrl + APIAddress.DeletePatients + "?id=" + id);
                response = await client.GetAsync(apiUrl + APIAddress.DeletePatients + "?id=" + id);
                if (response.IsSuccessStatusCode)
                {
                    //result = 1;
                    //message = "Delete Successfully";
                    Redirect("Index");
                }


            }
            catch (Exception ex)
            {
                message = "Update Denied";
            }

            return Json(new { result = result, message = message });
        }



        //[HttpPost]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    try
        //    {
        //        if (id == null)
        //        {
        //            return BadRequest();
        //        }

        //        response = await client.PostAsJsonAsync(apiUrl + APIAddress.DeletePatients, id);

        //        if (response.IsSuccessStatusCode)
        //        {
        //            return RedirectToAction("Index");
        //        }

        //        return View();
        //    }
        //    catch (Exception)
        //    {
        //        return RedirectToAction("Error", "Home");
        //    }



        //}


        private async void MapDropDown(PatientsDTO model)
        {
            using HttpResponseMessage response = client.GetAsync(apiUrl + APIAddress.AllDiseases).Result;
            if (response.IsSuccessStatusCode)
            {
                model.DisesesNameList = JsonConvert.DeserializeObject<List<DiseasesInfo>>(response.Content.ReadAsStringAsync().Result);
            }

            HttpResponseMessage ncdResponse = client.GetAsync(apiUrl + APIAddress.AllNCDDiseases).Result;
            if (ncdResponse.IsSuccessStatusCode)
            {
                model.NCDDisesesNameList = JsonConvert.DeserializeObject<List<DiseasesInfo>>(ncdResponse.Content.ReadAsStringAsync().Result);
            }

            HttpResponseMessage allergiesResponse = client.GetAsync(apiUrl + APIAddress.AllAllergiesDiseases).Result;
            if (allergiesResponse.IsSuccessStatusCode)
            {
                model.AllergiesDisesesList = JsonConvert.DeserializeObject<List<DiseasesInfo>>(allergiesResponse.Content.ReadAsStringAsync().Result);
            }

        }

    }
}
