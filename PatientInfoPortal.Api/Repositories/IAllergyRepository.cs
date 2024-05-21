using PatientInfoPortal.Shared.Dtos;

namespace PatientInfoPortal.Api.Repositories
{
    public interface IAllergyRepository
    {
        Task<List<AllergyDto>> GetAllergies();
    }
}
