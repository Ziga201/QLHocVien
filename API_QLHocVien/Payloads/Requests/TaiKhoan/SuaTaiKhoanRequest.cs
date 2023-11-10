namespace API_QLHocVien.Payloads.Requests.TaiKhoan
{
    public class SuaTaiKhoanRequest
    {
        public int TaiKhoanID { get; set; }
        public string TenNguoiDung { get; set; }
        public string TaiKhoanDN { get; set; }
        public string MatKhau { get; set; }
        public int QuyenHanID { get; set; }
    }
}
