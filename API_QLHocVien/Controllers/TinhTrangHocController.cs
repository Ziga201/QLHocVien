using API_QLHocVien.Helper;
using API_QLHocVien.IServices;
using API_QLHocVien.Payloads.Requests.TinhTrangHoc;
using API_QLHocVien.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_QLHocVien.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TinhTrangHocController : ControllerBase
    {
        private readonly ITinhTrangHocServices services;

        public TinhTrangHocController()
        {
            services = new TinhTrangHocServices();
        }
        [HttpPost("ThemTinhTrangHoc")]
        public IActionResult ThemTinhTrangHoc(ThemTinhTrangHocRequest request)
        {
            return Ok(services.ThemTinhTrangHoc(request));
        }
        [HttpPut("SuaTinhTrangHoc")]
        public IActionResult SuaTinhTrangHoc(SuaTinhTrangHocRequest request)
        {
            return Ok(services.SuaTinhTrangHoc(request));
        }
        [HttpDelete("XoaTinhTrangHoc")]
        public IActionResult XoaTinhTrangHoc(int id)
        {
            return Ok(services.XoaTinhTrangHoc(id));
        }

        [HttpGet("LayDSTinhTrangHoc")]
        public IActionResult LayDSTinhTrangHoc()
        {
            return Ok(services.LayDSTinhTrangHoc());
        }
    }
}
