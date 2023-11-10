using System.Diagnostics.CodeAnalysis;

namespace API_QLHocVien.Entites
{
    public class DangKyHoc
    {
        public int ID { get; set; }
        public int KhoaHocID { get; set; }
        public int HocVienID { get; set; }
        public DateTime? NgayDangKy { get; set; }
        [MaybeNull]
        public DateTime? NgayBatDau { get; set; }
        [MaybeNull]
        public DateTime? NgayKetThuc { get; set; }
        public int TinhTrangHocID { get; set; }
        public int TaiKhoanID { get; set; }
        public KhoaHoc KhoaHoc { get; set; }
        public HocVien HocVien { get; set; }
        public TinhTrangHoc TinhTrangHoc { get; set; }
        public TaiKhoan TaiKhoan { get; set; }
    }
}
