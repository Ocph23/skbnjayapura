using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using skbnjayapura.Server.Service.AuthService;
using skbnjayapura.Server.Services.AuthService;
using skbnjayapura.Shared;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace skbnjayapura.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController, Authorize]
    public class PimpinanController : ControllerBase
    {
        private readonly IPimpinanService PimpinanService;
        private readonly IAccountService accountService;

        // GET: api/<PimpinanController>

        public PimpinanController(
            IPimpinanService _PimpinanService,
            IAccountService _accountService
        )
        {
            PimpinanService = _PimpinanService;
            accountService = _accountService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await PimpinanService.Get());
        }

        // GET api/<PimpinanController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                return Ok(await PimpinanService.GetById(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "Pimpinan")]
        [HttpGet("byuser")]
        public async Task<IActionResult> GetByUser()
        {
            var userid = User.Claims.First(x => x.Type == "id").Value;
            Pimpinan data = await PimpinanService.GetPimpinan(userid);
            ArgumentNullException.ThrowIfNull(
                data,"Profile Anda Tidak Ditemukan !, Silahkan Hubungi Administror"
            );
            return Ok(data);
        }

        // POST api/<PimpinanController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PimpinanRegisterRequest value)
        {
            try
            {
                var user = await accountService.CreateUser(
                    new RegisterRequest(value.Pimpinan.Email, value.Password, "Pimpinan")
                );
                value.Pimpinan.UserId = user.Id;
                return Ok(await PimpinanService.Post(value.Pimpinan));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<PimpinanController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Pimpinan value)
        {
            try
            {
                return Ok(await PimpinanService.Put(id, value));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<PimpinanController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                return Ok(await PimpinanService.Delete(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
