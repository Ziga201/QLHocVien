using API_QLHocVien.Helper;
using API_QLHocVien.IServices;
using API_QLHocVien.Payloads.Requests.QuyenHan;
using API_QLHocVien.Payloads.Requests.TaiKhoan;
using API_QLHocVien.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_QLHocVien.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaiKhoanController : ControllerBase
    {
        private readonly ITaiKhoanServices services;

        public TaiKhoanController()
        {
            services = new TaiKhoanServices();
        }
        [HttpPost("ThemTaiKhoan")]
        public IActionResult ThemTaiKhoan(ThemTaiKhoanRequest request)
        {
            return Ok(services.ThemTaiKhoan(request));
        }
        [HttpPut("SuaTaiKhoan")]
        public IActionResult SuaTaiKhoan(SuaTaiKhoanRequest request)
        {
            return Ok(services.SuaTaiKhoan(request));
        }
        [HttpDelete("XoaTaiKhoan")]
        public IActionResult XoaTaiKhoan(int id)
        {
            return Ok(services.XoaTaiKhoan(id));
        }

        [HttpGet("LayDSTaiKhoan")]
        public IActionResult LayDSTaiKhoan([FromQuery] Pagination pagination)
        {
            return Ok(services.LayDSTaiKhoan(pagination));
        }
        [HttpGet("TimKiemTaiKhoan")]
        public IActionResult TimKiemTaiKhoan([FromQuery] Pagination pagination, string? key)
        {
            return Ok(services.TimKiemTaiKhoan(pagination, key));
        }
    }
}
