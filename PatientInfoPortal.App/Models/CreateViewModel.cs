using Microsoft.AspNetCore.Mvc.Rendering;
using PatientInfoPortal.Shared.Dtos;

namespace PatientInfoPortal.App.Models
{
    public class CreateViewModel : PatientCreateDto
    {
        public IEnumerable<SelectListItem>? Diseases { get; set; } 
        public IEnumerable<SelectListItem>? Ncds { get; set; }
        public IEnumerable<SelectListItem>? SelectedNcds { get; set; }

        public IEnumerable<SelectListItem>? Allergies { get; set; }
        public IEnumerable<SelectListItem>? SelectedAllergies { get; set; }

        public EpilepsyEnum EpilepsyVal {  get; set; }

        public IEnumerable<SelectListItem> EpilepsyOptions => new List<SelectListItem>
        {
            new SelectListItem { Value = EpilepsyEnum.NO.ToString(), Text = "NO" },
            new SelectListItem { Value = EpilepsyEnum.YES.ToString(), Text = "YES" }
        };
    }

}
