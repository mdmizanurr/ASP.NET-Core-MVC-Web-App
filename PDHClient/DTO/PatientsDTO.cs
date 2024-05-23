using Microsoft.AspNetCore.Mvc.Rendering;
using PDHClient.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PDHClient.DTO
{
    public class PatientsDTO
    {
        public PatientsDTO()
        {
            DisesesNameList = new List<DiseasesInfo>();
            NCDDisesesNameList = new List<DiseasesInfo>();
            AllergiesDisesesList = new List<DiseasesInfo>();
        }
        public int Id { get; set; }

        [Required]
        [DisplayName("Patient Name")]
        public string patientName { get; set; }

        [Required]
        public bool epilepsy { get; set; }

        [Required]
        [DisplayName("Diseases Name")]
        public int diseasesID { get; set; }
        public int? ncdid { get; set; }
        public int? allergiesID { get; set; }

        public List<DiseasesInfo> DisesesNameList { get; set; }
        public List<DiseasesInfo> NCDDisesesNameList { get; set; }
        public List<DiseasesInfo> AllergiesDisesesList { get; set; }

        public IEnumerable<SelectListItem> DiseasesNameListItems => new SelectList(DisesesNameList, "Id", "DiseaseName");
        public IEnumerable<SelectListItem> NCDDiseasesNameListItems => new SelectList(NCDDisesesNameList, "Id", "DiseaseName");
        public IEnumerable<SelectListItem> AllergiesDiseasesListItems => new SelectList(AllergiesDisesesList, "Id", "DiseaseName");



    }
}
