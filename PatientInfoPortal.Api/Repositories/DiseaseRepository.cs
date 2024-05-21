using Microsoft.EntityFrameworkCore;
using PatientInfoPortal.Api.Data;
using PatientInfoPortal.Shared.Dtos;

namespace PatientInfoPortal.Api.Repositories
{
    public class DiseaseRepository : IDiseaseRepository
    {
        private readonly PatientInfoPortalContext _context;

        public DiseaseRepository(PatientInfoPortalContext context)
        {
            _context = context;
        }

        public async Task<List<DiseaseInformationDto>> GetDiseases()
        {
            var diseases = await _context.DiseaseInformations.Select(x => new DiseaseInformationDto { Id = x.Id, Name = x.Name }).ToListAsync();

            return diseases;
        }
    }
}
