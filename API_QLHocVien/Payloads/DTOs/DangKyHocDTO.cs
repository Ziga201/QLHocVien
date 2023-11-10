using API_QLHocVien.Context;

namespace API_QLHocVien.Payloads.DTOs
{
    public class DangKyHocDTO
    {
        public string TenKhoaHoc { get; set; }
        public string HoTen { get; set; }
        public DateTime? NgayDangKy { get; set; }
        public DateTime? NgayBatDau { get; set; }
        public DateTime? NgayKetThuc { get; set; }
        public string TenTinhTrang { get; set; }
        public string TaiKhoanDN { get; set; }
    }
}
