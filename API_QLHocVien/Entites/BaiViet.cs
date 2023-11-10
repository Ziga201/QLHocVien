namespace API_QLHocVien.Entites
{
    public class BaiViet
    {
        public int BaiVietID { get; set; }
        public string TenBaiViet { get; set; }
        public DateTime ThoiGianTao { get; set; } = DateTime.Now;
        public string TenTacGia { get; set; }
        public string NoiDung { get; set; }
        public string NoiDungNgan { get; set; }
        public string HinhAnh { get; set; }
        public int ChuDeID { get; set; }
        public int TaiKhoanID { get; set; }
        public ChuDe ChuDe { get; set; }
        public TaiKhoan TaiKhoan { get; set; }
    }
}
