namespace API_QLHocVien.Entites
{
    public class KhoaHoc
    {
        public int KhoaHocID { get; set; }
        public string TenKhoaHoc { get; set; }
        public int ThoiGianHoc { get; set; }
        public string GioiThieu { get; set; }
        public string NoiDung { get; set; }
        public float HocPhi { get; set; }
        public int SoHocVien { get; set; } = 0;
        public int SoLuongMon { get; set; }
        public string HinhAnh { get; set; }
        public int LoaiKhoaHocID { get; set; }
        public LoaiKhoaHoc LoaiKhoaHoc { get; set; }
    }
}
