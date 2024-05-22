using Humanizer.Localisation.TimeToClockNotation;
using PatientInfoPortal.Shared.Dtos;

namespace PatientInfoPortal.App.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<PatientsInformationDto>> GetPatients()
        {
            var response = await _httpClient.GetFromJsonAsync<List<PatientsInformationDto>>("api/patient");
            return response;
        }

        public async Task<PatientsInformationDto> GetPatientById(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<PatientsInformationDto>($"api/patient/{id}");
            return response;
        }

        public async Task AddPatient(PatientCreateDto patient)
        {
            await _httpClient.PostAsJsonAsync<PatientCreateDto>("api/patient", patient);
        }

        public async Task EditPatient(PatientUpdateDto patient)
        {
            await _httpClient.PutAsJsonAsync<PatientUpdateDto>("api/patient", patient);
        }

        public async Task DeletePatient(int id)
        {
            await _httpClient.DeleteAsync($"api/patient/{id}");
        }

        public async Task<List<DiseaseInformationDto>> GetDiseases()
        {
            var response = await _httpClient.GetFromJsonAsync<List<DiseaseInformationDto>>("api/Disease");
            return response;
        }

        public async Task<List<AllergyDto>> GetAllergies()
        {
            var response = await _httpClient.GetFromJsonAsync<List<AllergyDto>>("api/allergies");

            return response;
        }

        public async Task<List<NcdDto>> GetNcds()
        {
            var response = await _httpClient.GetFromJsonAsync<List<NcdDto>>("api/ncd");

            return response;
        }


    }
}
