using PatientInfoPortal.Shared.Dtos;

namespace PatientInfoPortal.Api.Repositories
{
    public interface INcdRepository
    {
        Task<List<NcdDto>> GetNcds();
    }
}
