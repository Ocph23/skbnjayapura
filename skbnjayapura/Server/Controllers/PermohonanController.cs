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
    public class PermohonanController : ControllerBase
    {
        private readonly IPermohonanService permohonaService;
        private readonly IAccountService accountService;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment env;

        // GET: api/<PermohonanController>

        public PermohonanController(IPermohonanService _permohonaService,
            IAccountService _accountService,
            Microsoft.AspNetCore.Hosting.IHostingEnvironment _env)
        {
            permohonaService = _permohonaService;
            accountService = _accountService;
            env = _env;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await permohonaService.Get());
        }

        [Authorize(Roles = "Pemohon")]
        [HttpGet("byuser")]
        public async Task<IActionResult> GetByUser()
        {
            var userid = User.Claims.First(x => x.Type == "id").Value;
            Profile profile = await accountService.GetProfile(userid);
            ArgumentNullException.ThrowIfNull(profile, "Profile Anda Tidak Ditemukan !, Silahkan Lengkapi Profile Anda");
            IEnumerable<Permohonan> data = permohonaService.GetByProfile(profile.Id);
            return Ok(data);
        }


        [HttpGet("skbn")]
        public async Task<IActionResult> GetSKBN()
        {
            IEnumerable<SKBNModel> data = permohonaService.GetSKBN();
            return Ok(data);
        }

        // GET api/<PermohonanController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                return Ok(await permohonaService.GetById(id));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // POST api/<PermohonanController>



        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Permohonan value)
        {
            try
            {
                return Ok(await permohonaService.Post(value));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }



        [HttpPost("pengambilan")]
        public async Task<IActionResult> PostPengambilan([FromBody] Pengambilan value)
        {
            try
            {
                return Ok(await permohonaService.PostPengambilan(value));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "Pimpinan")]
        [HttpPost("persetujuan/{id}")]
        public async Task<IActionResult> PostPersetujuan(int id,[FromBody] Pimpinan value)
        {
            try
            {
                return Ok(await permohonaService.PostPersetujuan(id,value));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<PermohonanController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Permohonan value)
        {
            try
            {
                return Ok(await permohonaService.Put(id, value));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<PermohonanController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                return Ok(await permohonaService.Delete(id));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }


        [HttpPost("verifikasipersyaratan")]
        public async Task<IActionResult> VerifikasiPersyaratan(ItemPersyaratan model)
        {
            try
            {
                return Ok(await permohonaService.VerifikasiPersyaratan(model));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPost("upload/{id}")]
        [RequestSizeLimit(100 * 1024 * 1024)]
        [RequestFormLimits(MultipartBodyLengthLimit = 10 * 1024 * 1024)]
        public async Task<IActionResult> Upload(int id, IFormFile file)
        {
            try
            {
                ItemPersyaratan itemPersyaratan = await permohonaService.GetItemPersyaratan(id);
                var httprequest = HttpContext.Request.Form.Files;
                string filex = string.Empty;
                var filemm = httprequest.FirstOrDefault();
                var fileType = Path.GetExtension(filemm.FileName);
                //var ext = file.;
                if (fileType.ToLower() == ".pdf" || fileType.ToLower() == ".jpg" || fileType.ToLower() == ".png" || fileType.ToLower() == ".jpeg")
                {
                    var filePath = Path.Combine(env.ContentRootPath, "wwwroot/files");
                    if (!Directory.Exists(filePath))
                        Directory.CreateDirectory(filePath);
                    var docName = Path.GetFileName(filemm.FileName);
                    if (filemm != null && filemm.Length > 0)
                    {
                        var Id = Guid.NewGuid();
                        var DocType = fileType;
                        filex = Id.ToString() + DocType;
                        var DocUrl = Path.Combine(filePath, filex);
                        using (var stream = new FileStream(DocUrl, FileMode.Create))
                        {
                            await filemm.CopyToAsync(stream);
                        }

                        if (!string.IsNullOrEmpty(itemPersyaratan.FileName) && itemPersyaratan.FileName != filex)
                        {
                            System.IO.File.Delete(Path.Combine(filePath, itemPersyaratan.FileName));
                        }
                        itemPersyaratan.FileName = filex;
                        ItemPersyaratan result = await permohonaService.UpdatePersyaratan(id, itemPersyaratan);
                        return Ok(filex);
                    }
                    else
                        throw new SystemException("Periksa Kembali Dokumen  Anda !");
                }
                else
                    throw new SystemException($"Jenis File {fileType} Tidak Diterima !");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
