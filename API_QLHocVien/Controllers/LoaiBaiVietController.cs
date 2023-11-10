using API_QLHocVien.Helper;
using API_QLHocVien.IServices;
using API_QLHocVien.Payloads.Requests.KhoaHoc;
using API_QLHocVien.Payloads.Requests.LoaiBaiViet;
using API_QLHocVien.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_QLHocVien.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoaiBaiVietController : ControllerBase
    {
        private readonly ILoaiBaiVietServices services;

        public LoaiBaiVietController()
        {
            services = new LoaiBaiVietServices();
        }

        [HttpPost("ThemLoaiBaiViet")]
        public IActionResult ThemLoaiBaiViet(ThemLoaiBaiVietRequest request)
        {
            return Ok(services.ThemLoaiBaiViet(request));
        }
        [HttpPut("SuaLoaiBaiViet")]
        public IActionResult SuaLoaiBaiViet(SuaLoaiBaiVietRequest request)
        {
            return Ok(services.SuaLoaiBaiViet(request));
        }
        [HttpDelete("XoaLoaiBaiViet")]
        public IActionResult XoaLoaiBaiViet(int idLoaiBaiViet)
        {
            return Ok(services.XoaLoaiBaiViet(idLoaiBaiViet));
        }
        [HttpGet("LayDSLoaiBaiViet")]
        public IActionResult LayDSLoaiBaiViet([FromQuery] Pagination pagination)
        {
            return Ok(services.LayDSLoaiBaiViet(pagination));
        }
    }
}
