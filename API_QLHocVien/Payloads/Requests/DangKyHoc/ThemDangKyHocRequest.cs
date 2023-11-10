namespace API_QLHocVien.Payloads.Requests.DangKyHoc
{
    public class ThemDangKyHocRequest
    {
        public int KhoaHocID { get; set; }
        public int HocVienID { get; set; }

        //public int TinhTrangHocID { get; set; }
        public int TaiKhoanID { get; set; }
    }
}
