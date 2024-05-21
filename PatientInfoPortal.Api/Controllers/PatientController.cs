using Microsoft.AspNetCore.Mvc;
using PatientInfoPortal.Api.Repositories;
using PatientInfoPortal.Shared.Dtos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PatientInfoPortal.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientRepository _patientRepository;

        public PatientController(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        // GET: api/<PatientController>
        [HttpGet]
        public async Task<IActionResult> GetPatients()
        {
            var result = await _patientRepository.GetPatients();
            return Ok(result);
        }


        // GET api/<PatientController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPatientById(int id)
        {
            var result = await _patientRepository.GetPatientById(id);

            return Ok(result);
        }

        // POST api/<PatientController>
        [HttpPost]
        public async Task<IActionResult> AddPatient([FromBody] PatientCreateDto patient)
        {
            await _patientRepository.AddPatient(patient);

            return Ok();
        }

        // PUT api/<PatientController>/5
        [HttpPut]
        public async Task<IActionResult> UpdatePatient([FromBody] PatientUpdateDto patient)
        {
            await _patientRepository.UpdatePatient(patient);

            return Ok();
        }

        // DELETE api/<PatientController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePatient(int id)
        {
            await _patientRepository.DeletePatient(id);

            return Ok();
        }
    }
}
