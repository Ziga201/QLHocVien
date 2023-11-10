using API_QLHocVien.Entites;
using API_QLHocVien.Helper;
using API_QLHocVien.IServices;
using API_QLHocVien.Payloads.Requests.KhoaHoc;
using API_QLHocVien.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_QLHocVien.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KhoaHocController : ControllerBase
    {
        private readonly IKhoaHocServices khoaHocServices;

        public KhoaHocController()
        {
            khoaHocServices = new KhoaHocServices();
        }

        [HttpPost("ThemKhoaHoc")]
        public async Task<IActionResult> ThemKhoaHoc([FromForm] ThemKhoaHocRequest request)
        {
            return Ok(await khoaHocServices.ThemKhoaHoc(request));
        }
        [HttpPut("SuaKhoaHoc")]
        public async Task<IActionResult> SuaKhoaHoc([FromForm] SuaKhoaHocRequest request)
        {
            return Ok(await khoaHocServices.SuaKhoaHoc(request));
        }
        [HttpDelete("XoaKhoaHoc")]
        public IActionResult XoaKhoaHoc(int idKhoaHoc)
        {
            return Ok(khoaHocServices.XoaKhoaHoc(idKhoaHoc));
        }

        [HttpGet("GetDSKhoaHoc")]
        public IActionResult GetDSKhoaHoc([FromQuery] Pagination pagination)
        {
            return Ok(khoaHocServices.GetDSKhoaHoc(pagination));
        }
        [HttpGet("TimKiemKhoaHoc")]
        public IActionResult TimKiemKhoaHoc([FromQuery] Pagination pagination, [FromQuery] string? key)
        {
            return Ok(khoaHocServices.TimKiemKhoaHoc(pagination, key));
        }
    }
}
