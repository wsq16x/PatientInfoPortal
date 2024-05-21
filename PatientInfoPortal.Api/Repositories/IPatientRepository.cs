using Microsoft.Identity.Client;
using PatientInfoPortal.Api.Data;
using PatientInfoPortal.Api.Models;
using PatientInfoPortal.Shared.Dtos;
using System.Collections;

namespace PatientInfoPortal.Api.Repositories
{
    public interface IPatientRepository
    {
        Task<List<PatientsInformationDto>> GetPatients();
        Task<PatientsInformationDto> GetPatientById (int id);
        Task AddPatient(PatientCreateDto patientCreateDto);
        Task UpdatePatient(PatientUpdateDto patientUpdateDto);
        Task DeletePatient(int id);
    }
}
