using API_QLHocVien.Context;
using API_QLHocVien.Entites;
using API_QLHocVien.Payloads.DTOs;

namespace API_QLHocVien.Payloads.Converters
{
    public class DangKyHocConverter
    {
        private readonly AppDbContext dbContext;

        public DangKyHocConverter()
        {
            dbContext = new AppDbContext();
        }
        public DangKyHocDTO EntityToDTO(DangKyHoc dangKyHoc)
        {
            return new DangKyHocDTO()
            {
                TenKhoaHoc = dbContext.KhoaHoc.FirstOrDefault(x => x.KhoaHocID == dangKyHoc.KhoaHocID).TenKhoaHoc,
                HoTen = dbContext.HocVien.FirstOrDefault(x => x.HocVienID == dangKyHoc.HocVienID).HoTen,
                NgayDangKy = dangKyHoc.NgayDangKy,
                NgayBatDau = dangKyHoc.NgayBatDau,
                NgayKetThuc = dangKyHoc.NgayKetThuc,
                TenTinhTrang = dbContext.TinhTrangHoc.FirstOrDefault(x => x.TinhTrangHocID == dangKyHoc.TinhTrangHocID).TenTinhTrang,
                TaiKhoanDN = dbContext.TaiKhoan.FirstOrDefault(x => x.TaiKhoanID == dangKyHoc.TaiKhoanID).TaiKhoanDN,

            };
        }
    }
}
