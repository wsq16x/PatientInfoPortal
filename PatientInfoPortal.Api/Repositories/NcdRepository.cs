using Microsoft.EntityFrameworkCore;
using PatientInfoPortal.Api.Data;
using PatientInfoPortal.Shared.Dtos;

namespace PatientInfoPortal.Api.Repositories
{
    public class NcdRepository : INcdRepository
    {
        private readonly PatientInfoPortalContext _context;

        public NcdRepository(PatientInfoPortalContext context)
        {
            _context = context;
        }

        public async Task<List<NcdDto>> GetNcds()
        {
            var ncds = await _context.Ncds.Select(x => new NcdDto { Id = x.Id, Name = x.Name, }).ToListAsync();

            return ncds;
        }
    }
}
