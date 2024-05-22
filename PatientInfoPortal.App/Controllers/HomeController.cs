using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using PatientInfoPortal.App.Models;
using PatientInfoPortal.App.Services;
using PatientInfoPortal.Shared.Dtos;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

namespace PatientInfoPortal.App.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HttpClient _httpClient;
        private readonly ApiService _apiService;

        public HomeController(ILogger<HomeController> logger, HttpClient httpClient, ApiService apiService)
        {
            _logger = logger;
            _httpClient = httpClient;
            _apiService = apiService;
        }

        public async Task<IActionResult> Index()
        {
            var patients = await _apiService.GetPatients();

            return View(patients);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> Create()
        {
            var diseases = await _apiService.GetDiseases();
            var allergies = await _apiService.GetAllergies();
            var ncds = await _apiService.GetNcds();

            var diseaseSelectList = diseases.Select(d =>
                new SelectListItem
                {
                    Value = d.Id.ToString(),
                    Text = d.Name
                }
            );

            var allergiesSelectList = allergies.Select(a =>
                new SelectListItem
                {
                    Value = a.Id.ToString(),
                    Text = a.Name
                }
            );

            var ncdsSelectList = ncds.Select(n =>
                new SelectListItem
                {
                    Value = n.Id.ToString(),
                    Text = n.Name
                }
            );

            var createVm = new CreateViewModel
            {
                Diseases = diseaseSelectList,
                Allergies = allergiesSelectList,
                Ncds = ncdsSelectList
                
            };


            return View(createVm);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateViewModel cvm)
        {
            var newPatient = new PatientCreateDto
            {
                PatientName = cvm.PatientName,
                DiseaseId = cvm.DiseaseId,
                NcdIds = cvm.NcdIds,
                AllergyIds = cvm.AllergyIds,
                Epilepsy = cvm.EpilepsyVal == 0 ? false : true,    
            };

            await _apiService.AddPatient(newPatient);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var patient = await _apiService.GetPatientById(id);
            var allergies = await _apiService.GetAllergies();
            var ncds = await _apiService.GetNcds();
            var diseases = await _apiService.GetDiseases();

            var selectedNcdIds = patient.NCDs.Select(x => x.Id).ToList();
            var selectedAllergiesIds = patient.Allergies.Select(x => x.Id).ToList();

            var diseaseList = diseases.Select(d =>
                new SelectListItem
                {
                    Value = d.Id.ToString(),
                    Text = d.Name
                }
            );

            var availableNcds = ncds.Where(n => !selectedNcdIds.Contains(n.Id))
                        .Select(n => new SelectListItem
                        {
                            Value = n.Id.ToString(),
                            Text = n.Name
                        }).ToList();

            var availableAllergies = allergies.Where(n => !selectedAllergiesIds.Contains(n.Id))
            .Select(n => new SelectListItem
            {
                Value = n.Id.ToString(),
                Text = n.Name
            }).ToList();

            var selectedNcds = patient.NCDs
            .Select(n => new SelectListItem
            {
                Value = n.Id.ToString(),
                Text = n.Name
            }).ToList();

            var selectedAllergies = patient.Allergies.Select(a => 
                new SelectListItem
                {
                    Value = a.Id.ToString(),
                    Text = a.Name
                }
            ).ToList();

            var patientEditVm = new EditViewModel
            {
                Id = patient.ID,
                PatientName = patient.Name,
                DiseaseId = patient.Disease.Id,
                EpilepsyVal = patient.Epilepsy == true ? EpilepsyEnum.YES : EpilepsyEnum.NO,
                SelectedAllergies = selectedAllergies,
                SelectedNcds = selectedNcds,
                Allergies = availableAllergies,
                Ncds = availableNcds,
                Diseases = diseaseList

            };

            return View(patientEditVm);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditViewModel evm)
        {
            var editPatient = new PatientUpdateDto
            {
                PatientId = evm.Id,
                PatientName = evm.PatientName,
                DiseaseId = evm.DiseaseId,
                NcdIds = evm.NcdIds,
                AllergyIds = evm.AllergyIds,
                Epilepsy = evm.EpilepsyVal == 0 ? false : true,
            };

            await _apiService.EditPatient(editPatient);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var patient = await _apiService.GetPatientById(id);
            return View(patient);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _apiService.DeletePatient(id); 
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
