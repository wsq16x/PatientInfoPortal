using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PatientInfoPortal.Api.Repositories;

namespace PatientInfoPortal.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AllergiesController : ControllerBase
    {
        private readonly IAllergyRepository _allergyRepository;

        public AllergiesController(IAllergyRepository allergyRepository)
        {
            _allergyRepository = allergyRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllergies()
        {
            var result = await _allergyRepository.GetAllergies();
            return Ok(result);
        }
    }
}
