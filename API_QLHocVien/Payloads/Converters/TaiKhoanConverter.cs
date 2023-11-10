using API_QLHocVien.Context;
using API_QLHocVien.Entites;
using API_QLHocVien.Payloads.DTOs;

namespace API_QLHocVien.Payloads.Converters
{
    public class TaiKhoanConverter
    {
        private readonly AppDbContext dbContext;

        public TaiKhoanConverter()
        {
            dbContext = new AppDbContext();
        }
        public TaiKhoanDTO EntityToDTO(TaiKhoan taiKhoan)
        {
            return new TaiKhoanDTO
            {
                TenNguoiDung = taiKhoan.TenNguoiDung,
                TaiKhoanDN = taiKhoan.TaiKhoanDN,
                MatKhau = taiKhoan.MatKhau,
                TenQuyenHan = dbContext.QuyenHan.FirstOrDefault(x => x.QuyenHanID == taiKhoan.QuyenHanID).TenQuyenHan,
            };
        }
    }
}
