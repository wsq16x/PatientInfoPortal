using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PatientInfoPortal.Api.Repositories;

namespace PatientInfoPortal.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiseaseController : ControllerBase
    {
        private readonly IDiseaseRepository _diseaseRepository;

        public DiseaseController(IDiseaseRepository diseaseRepository)
        {
            _diseaseRepository = diseaseRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetDiseases()
        {
            var result = await _diseaseRepository.GetDiseases();
            return Ok(result);
        }
    }
}
