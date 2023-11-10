namespace API_QLHocVien.Payloads.Requests.BaiViet
{
    public class ThemBaiVietRequest
    {
        public string TenBaiViet { get; set; }
        public string TenTacGia { get; set; }
        public string NoiDung { get; set; }
        public string NoiDungNgan { get; set; }
        public IFormFile HinhAnh { get; set; }
        public int ChuDeID { get; set; }
        public int TaiKhoanID { get; set; }
    }
}
