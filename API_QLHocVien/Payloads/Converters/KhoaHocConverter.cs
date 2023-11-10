using API_QLHocVien.Context;
using API_QLHocVien.Entites;
using API_QLHocVien.Payloads.DTOs;

namespace API_QLHocVien.Payloads.Converters
{
    public class KhoaHocConverter
    {
        private readonly AppDbContext dbContext;

        public KhoaHocConverter()
        {
            dbContext = new AppDbContext();
        }
        public KhoaHocDTO EntityToDTO(KhoaHoc khoaHoc)
        {
            return new KhoaHocDTO
            {
                TenKhoaHoc = khoaHoc.TenKhoaHoc,
                ThoiGianHoc = khoaHoc.ThoiGianHoc,
                GioiThieu = khoaHoc.GioiThieu,
                NoiDung = khoaHoc.NoiDung,
                HocPhi = khoaHoc.HocPhi,
                SoHocVien = dbContext.KhoaHoc.FirstOrDefault(x => x.KhoaHocID == khoaHoc.KhoaHocID).SoHocVien,
                SoLuongMon = khoaHoc.SoLuongMon,
                HinhAnh = khoaHoc.HinhAnh,
                TenLoaiKhoaHoc = dbContext.LoaiKhoaHoc.FirstOrDefault(x => x.LoaiKhoaHocID == khoaHoc.LoaiKhoaHocID).TenLoai
            };
        }
    }
}
