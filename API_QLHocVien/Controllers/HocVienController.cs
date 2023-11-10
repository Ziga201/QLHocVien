using API_QLHocVien.Helper;
using API_QLHocVien.IServices;
using API_QLHocVien.Payloads.Requests.HocVien;
using API_QLHocVien.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_QLHocVien.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HocVienController : ControllerBase
    {
        private readonly IHocVienServices hocVienServices;

        public HocVienController()
        {
            hocVienServices = new HocVienServices();
        }
        [HttpPost("ThemHocVien")]
        public async Task<IActionResult> ThemHocVien([FromForm]ThemHocVienRequest request)
        {
            return Ok(await hocVienServices.ThemHocVien(request));
        }
        [HttpPut("SuaHocVien")]
        public async Task<IActionResult> SuaHocVien([FromForm] SuaHocVienRequest request)
        {
            return Ok( await hocVienServices.SuaHocVien(request));
        }
        [HttpDelete("XoaHocVien")]
        public IActionResult XoaHocVien(int idHocVien)
        {
            return Ok(hocVienServices.XoaHocVien(idHocVien));
        }
        [HttpGet("LayDSHocVien")]
        public IActionResult LayDSHocVien([FromQuery]Pagination pagination)
        {
            return Ok(hocVienServices.LayDSHocVien(pagination));
        }
        [HttpGet("TimKiemHocVien")]
        public IActionResult TimKiemHocVien([FromQuery] Pagination pagination, string? name, string? email)
        {
            return Ok(hocVienServices.TimKiemHocVien(pagination, name, email));
        }
    }
}
