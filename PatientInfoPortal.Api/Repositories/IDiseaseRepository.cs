using PatientInfoPortal.Shared.Dtos;

namespace PatientInfoPortal.Api.Repositories
{
    public interface IDiseaseRepository
    {
        Task<List<DiseaseInformationDto>> GetDiseases();
    }
}
