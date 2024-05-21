using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PatientInfoPortal.Api.Repositories;

namespace PatientInfoPortal.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NcdController : ControllerBase
    {
        private readonly INcdRepository _ncdRepository;

        public NcdController(INcdRepository ncdRepository)
        {
            _ncdRepository = ncdRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetNcds()
        {
            var result = await _ncdRepository.GetNcds();
            return Ok(result);
        }
    }
}
