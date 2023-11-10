using API_QLHocVien.Context;
using API_QLHocVien.Entites;
using API_QLHocVien.Payloads.DTOs;

namespace API_QLHocVien.Payloads.Converters
{
    public class LoaiKhoaHocConverter
    {
        private readonly AppDbContext dbContext;

        public LoaiKhoaHocConverter()
        {
            dbContext = new AppDbContext(); 
        }
        public LoaiKhoaHocDTO EntityToDTO(LoaiKhoaHoc loaiKhoaHoc)
        {
            return new LoaiKhoaHocDTO
            {
                TenLoai = loaiKhoaHoc.TenLoai,
            };
        }
    }
}
