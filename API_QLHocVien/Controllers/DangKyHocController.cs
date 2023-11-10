using API_QLHocVien.Entites;
using API_QLHocVien.Helper;
using API_QLHocVien.IServices;
using API_QLHocVien.Payloads.Requests.DangKyHoc;
using API_QLHocVien.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_QLHocVien.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DangKyHocController : ControllerBase
    {
        private readonly IDangKyHocServices services;

        public DangKyHocController()
        {
            services = new DangKyHocServices();
        }
        [HttpPost("ThemDangKyHoc")]
        public IActionResult ThemDangKyHoc(ThemDangKyHocRequest request)
        {
            return Ok(services.ThemDangKyHoc(request));
        }
        [HttpPut("SuaDangKyHoc")]
        public IActionResult SuaDangKyHoc(SuaDangKyHocRequest request)
        {
            return Ok(services.SuaDangKyHoc(request));
        }
        [HttpPut("CapNhatTrangThaiHoc")]
        public IActionResult CapNhatTrangThaiHoc(int idDangKyHoc, int tinhTrangHocId)
        {
            return Ok(services.CapNhatTrangThaiHoc(idDangKyHoc, tinhTrangHocId));
        }

        [HttpPut("CapNhatTrangThaiHocXong")]
        public IActionResult CapNhatTrangThaiHocXong()
        {
            services.CapNhatTrangThaiHocXong();
            return Ok();
        }
        [HttpDelete("XoaDangKyHoc")]
        public IActionResult XoaDangKyHoc(int id)
        {
            return Ok(services.XoaDangKyHoc(id));
        }

        [HttpGet("LayDSDangKyHoc")]
        public IActionResult LayDSDangKyHoc([FromQuery] Pagination pagination)
        {
            return Ok(services.LayDSDangKyHoc(pagination));
        }
    }
}
