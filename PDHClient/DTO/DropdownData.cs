using Newtonsoft.Json;
using PDHClient.Models;

namespace PDHClient.DTO
{
    public static class DropdownData
    {


        public static async Task<List<DiseasesInfo>> GetAllDiseases(this CallApi _callApi)
        {

            try
            {
                string apiUrl = "https://localhost:44335/";
                var client = new HttpClient();

                var resMsg = client.GetAsync(apiUrl + APIAddress.AllDiseases).Result;
                var result = JsonConvert.DeserializeObject<List<DiseasesInfo>>(resMsg.Content.ReadAsStringAsync().Result);

                return result;
            }
            catch (Exception)
            {
                return new List<DiseasesInfo>();
            }
        }

    }


    public static class APIAddress
    {
        public const string AllDiseases = "API/Patients/All-Diseases";
        public const string AllNCDDiseases = "API/Patients/All-NCD-Diseases";
        public const string AllAllergiesDiseases = "API/Patients/All-Allergies-Diseases";
        public const string AllPatients = "API/Patients/All-Patients";
        public const string CreatePatients = "API/Patients/Add-Patient";
        public const string DeletePatients = "API/Patients/Delete-PatientById";
        public const string PatientEdit = "API/Patients/Patient-Details?id=";


    }
}
