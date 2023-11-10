using API_QLHocVien.Helper;
using API_QLHocVien.IServices;
using API_QLHocVien.Payloads.Requests.ChuDe;
using API_QLHocVien.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_QLHocVien.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChuDeController : ControllerBase
    {
        private readonly IChuDeServices services;

        public ChuDeController()
        {
            services = new ChuDeServices();
        }
        [HttpPost("ThemChuDe")]
        public IActionResult ThemChuDe(ThemChuDeRequest request)
        {
            return Ok(services.ThemChuDe(request));
        }
        [HttpPut("SuaChuDe")]
        public IActionResult SuaChuDe(SuaChuDeRequest request)
        {
            return Ok(services.SuaChuDe(request));
        }
        [HttpDelete("XoaChuDe")]
        public IActionResult XoaChuDe(int id)
        {
            return Ok(services.XoaChuDe(id));
        }

        [HttpGet("LayDSChuDe")]
        public IActionResult LayDSChuDe([FromQuery] Pagination pagination)
        {
            return Ok(services.LayDSChuDe(pagination));
        }
    }
}
