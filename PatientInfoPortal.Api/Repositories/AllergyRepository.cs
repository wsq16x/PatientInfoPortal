using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using PatientInfoPortal.Api.Data;
using PatientInfoPortal.Shared.Dtos;

namespace PatientInfoPortal.Api.Repositories
{
    public class AllergyRepository : IAllergyRepository
    {
        private readonly PatientInfoPortalContext _context;

        public AllergyRepository(PatientInfoPortalContext context)
        {
            _context = context;
        }

        public async Task<List<AllergyDto>> GetAllergies()
        {
            var allergies = await _context.Allergies.Select(x => new AllergyDto { Id = x.Id, Name = x.Name}).ToListAsync();

            return allergies;
        }
    }
}
