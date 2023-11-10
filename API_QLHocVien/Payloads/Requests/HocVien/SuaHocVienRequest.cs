namespace API_QLHocVien.Payloads.Requests.HocVien
{
    public class SuaHocVienRequest
    {
        public int HocVienID { get; set; }
        public IFormFile HinhAnh { get; set; }
        public string HoTen { get; set; }
        public DateTime NgaySinh { get; set; }
        public string SDT { get; set; }
        public string Email { get; set; }
        public string TinhThanh { get; set; }
        public string QuanHuyen { get; set; }
        public string PhuongXa { get; set; }
        public string SoNha { get; set; }
    }
}
