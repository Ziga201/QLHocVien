using API_QLHocVien.Entites;
using API_QLHocVien.Helper;
using API_QLHocVien.IServices;
using API_QLHocVien.Payloads.Requests.KhoaHoc;
using API_QLHocVien.Payloads.Requests.QuyenHan;
using API_QLHocVien.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_QLHocVien.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuyenHanController : ControllerBase
    {
        private readonly IQuyenHanServices services;

        public QuyenHanController()
        {
            services = new QuyenHanServices();
        }
        [HttpPost("ThemQuyenHan")]
        public IActionResult ThemQuyenHan(ThemQuyenHanRequest request)
        {
            return Ok(services.ThemQuyenHan(request));
        }
        [HttpPut("SuaQuyenHan")]
        public IActionResult SuaQuyenHan(SuaQuyenHanRequest request)
        {
            return Ok(services.SuaQuyenHan(request));
        }
        [HttpDelete("XoaQuyenHan")]
        public IActionResult XoaQuyenHan(int id)
        {
            return Ok(services.XoaQuyenHan(id));
        }

        [HttpGet("LayDSQuyenHan")]
        public IActionResult LayDSQuyenHan([FromQuery] Pagination pagination)
        {
            return Ok(services.LayDSQuyenHan(pagination));
        }
    }
}
