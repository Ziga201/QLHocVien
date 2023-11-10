using API_QLHocVien.Context;
using API_QLHocVien.Entites;
using API_QLHocVien.Payloads.DTOs;

namespace API_QLHocVien.Payloads.Converters
{
    public class BaiVietConverter
    {
        private readonly AppDbContext dbContext;

        public BaiVietConverter()
        {
            dbContext = new AppDbContext();
        }
        public BaiVietDTO EntityToDTO(BaiViet baiViet)
        {
            return new BaiVietDTO()
            {
                TenBaiViet = baiViet.TenBaiViet,
                ThoiGianTao = DateTime.Now,
                TenTacGia = baiViet.TenTacGia,
                NoiDung = baiViet.NoiDung,
                NoiDungNgan = baiViet.NoiDungNgan,
                HinhAnh = baiViet.HinhAnh,
                TenChuDe = dbContext.ChuDe.FirstOrDefault(x => x.ChuDeID == baiViet.ChuDeID).TenChuDe,
                TaiKhoanDN = dbContext.TaiKhoan.FirstOrDefault(x => x.TaiKhoanID == baiViet.TaiKhoanID).TaiKhoanDN,
            };
        }
    }
}
