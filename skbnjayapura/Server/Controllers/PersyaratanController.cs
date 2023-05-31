using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using skbnjayapura.Server.Services.AuthService;
using skbnjayapura.Shared;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace skbnjayapura.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController,Authorize]
    public class PersyaratanController : ControllerBase
    {
        private readonly IPersyaratanService persyaratanService;

        // GET: api/<PersyaratanController>

        public PersyaratanController(IPersyaratanService _persyaratanService)
        {
            persyaratanService = _persyaratanService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await persyaratanService.Get());
        }

        // GET api/<PersyaratanController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                return Ok(await persyaratanService.GetById(id));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // POST api/<PersyaratanController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Persyaratan value)
        {
            try
            {
                return Ok(await persyaratanService.Post(value));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // PUT api/<PersyaratanController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Persyaratan value)
        {
            try
            {
                return Ok(await persyaratanService.Put(id, value));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<PersyaratanController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                return Ok(await persyaratanService.Delete(id));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
