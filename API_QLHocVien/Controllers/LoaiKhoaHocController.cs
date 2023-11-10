using API_QLHocVien.IServices;
using API_QLHocVien.Payloads.Requests.KhoaHoc;
using API_QLHocVien.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_QLHocVien.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoaiKhoaHocController : ControllerBase
    {
        private readonly ILoaiKhoaHocServices services;

        public LoaiKhoaHocController()
        {
            services = new LoaiKhoaHocServices();
        }

        [HttpPost("ThemLoaiKhoaHoc")]
        public IActionResult ThemLoaiKhoaHoc([FromForm] ThemLoaiKhoaHocRequest request)
        {
            return Ok(services.ThemLoaiKhoaHoc(request));
        }
        [HttpPut("SuaLoaiKhoaHoc")]
        public IActionResult SuaLoaiKhoaHoc([FromForm] SuaLoaiKhoaHocRequest request)
        {
            return Ok(services.SuaLoaiKhoaHoc(request));
        }
        [HttpDelete("XoaLoaiKhoaHoc")]
        public IActionResult XoaLoaiKhoaHoc(int idLoaiKhoaHoc)
        {
            return Ok(services.XoaLoaiKhoaHoc(idLoaiKhoaHoc));
        }
    }
}
