namespace API_QLHocVien.Entites
{
    public class TaiKhoan
    {
        public int TaiKhoanID { get; set; }
        public string TenNguoiDung { get; set; }
        public string TaiKhoanDN { get; set; }
        public string MatKhau { get; set; }
        public int QuyenHanID { get; set; }
        public QuyenHan QuyenHan { get; set; }
    }
}
