using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using skbnjayapura.Server.Services.AuthService;
using skbnjayapura.Shared;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace skbnjayapura.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController,Authorize]
    public class ProfileController : ControllerBase
    {
        private readonly IProfileService profileService;

        // GET: api/<ProfileController>

        public ProfileController(IProfileService _profileService)
        {
            profileService = _profileService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await profileService.Get());
        }

        // GET api/<ProfileController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                return Ok(await profileService.GetById(id));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // POST api/<ProfileController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Profile value)
        {
            try
            {
                return Ok(await profileService.Post(value));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // PUT api/<ProfileController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Profile value)
        {
            try
            {
                return Ok(await profileService.Put(id, value));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<ProfileController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                return Ok(await profileService.Delete(id));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
