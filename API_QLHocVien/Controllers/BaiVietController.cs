using API_QLHocVien.Helper;
using API_QLHocVien.IServices;
using API_QLHocVien.Payloads.Requests.BaiViet;
using API_QLHocVien.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_QLHocVien.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaiVietController : ControllerBase
    {
        private readonly IBaiVietServices services;

        public BaiVietController()
        {
            services = new BaiVietServices();
        }
        [HttpPost("ThemBaiViet")]
        public async Task<IActionResult> ThemBaiViet(ThemBaiVietRequest request)
        {
            return Ok(await services.ThemBaiViet(request));
        }
        [HttpPut("SuaBaiViet")]
        public async Task<IActionResult> SuaBaiViet(SuaBaiVietRequest request)
        {
            return Ok(await services.SuaBaiViet(request));
        }
        [HttpDelete("XoaBaiViet")]
        public IActionResult XoaBaiViet(int id)
        {
            return Ok(services.XoaBaiViet(id));
        }

        [HttpGet("LayDSBaiViet")]
        public IActionResult LayDSBaiViet([FromQuery] Pagination pagination)
        {
            return Ok(services.LayDSBaiViet(pagination));
        }
        [HttpGet("TimKiemBaiViet")]
        public IActionResult TimKiemBaiViet([FromQuery] Pagination pagination, string? key)
        {
            return Ok(services.TimKiemBaiViet(pagination, key));
        }
    }
}
