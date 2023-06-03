using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using skbnjayapura.Server.Service.AuthService;
using skbnjayapura.Shared;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace skbnjayapura.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService accountService;

        public AccountController(IAccountService _accountService)
        {
            accountService = _accountService;
        }
        // POST api/<AccountController>
        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] LoginRequest value)
        {
            try
            {
                var response = await accountService.Login(value);
                ArgumentNullException.ThrowIfNull(response);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register([FromBody] RegisterRequest value)
        {
            try
            {
                var response = await accountService.Register(value);
                ArgumentNullException.ThrowIfNull(response);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }


        [Authorize]
        [HttpGet("profile")]
        public async Task<ActionResult> GetProfile()
        {
            try
            {

                var userid = User.Claims.First(x => x.Type == "id").Value;
                Profile response = await accountService.GetProfile(userid);
                ArgumentNullException.ThrowIfNull(response);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [Authorize(Roles ="Pemohon")]
        [HttpPost("profile")]
        public async Task<ActionResult> PostProfile([FromBody] Profile value)
        {
            try
            {
                var userid = User.Claims.First(x => x.Type == "id").Value;
                value.UserId = userid;
                Profile response = await accountService.PostProfile(value);
                ArgumentNullException.ThrowIfNull(response);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [Authorize(Roles = "Pemohon")]
        [HttpPut("profile/{id}")]
        public async Task<ActionResult> PutProfile(int id, [FromBody] Profile value)
        {
            try
            {
                Profile response = await accountService.PutProfile(id, value);
                ArgumentNullException.ThrowIfNull(response);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
