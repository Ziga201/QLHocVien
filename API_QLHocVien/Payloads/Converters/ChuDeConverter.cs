using API_QLHocVien.Context;
using API_QLHocVien.Entites;
using API_QLHocVien.Payloads.DTOs;
using System.Reflection.Metadata.Ecma335;

namespace API_QLHocVien.Payloads.Converters
{
    public class ChuDeConverter
    {
        private readonly AppDbContext dbContext;

        public ChuDeConverter()
        {
            dbContext = new AppDbContext();
        }
        public ChuDeDTO EntityToDTO(ChuDe chuDe)
        {
            return new ChuDeDTO()
            {
                TenChuDe = chuDe.TenChuDe,
                NoiDung = chuDe.NoiDung,
                TenLoaiBaiViet = dbContext.ChuDe.FirstOrDefault(x => x.ChuDeID == chuDe.ChuDeID).TenChuDe,
            };
        }
    }
}
