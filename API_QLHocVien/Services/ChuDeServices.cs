using API_QLHocVien.Context;
using API_QLHocVien.Entites;
using API_QLHocVien.Helper;
using API_QLHocVien.IServices;
using API_QLHocVien.Payloads.Converters;
using API_QLHocVien.Payloads.DTOs;
using API_QLHocVien.Payloads.Requests.ChuDe;
using API_QLHocVien.Payloads.Responses;
using Azure.Core;

namespace API_QLHocVien.Services
{
    public class ChuDeServices:BaseServices, IChuDeServices
    {
        private readonly ResponseObject<ChuDeDTO> responseObject;
        private readonly ChuDeConverter converter;

        public ChuDeServices()
        {
            responseObject = new ResponseObject<ChuDeDTO>();
            converter = new ChuDeConverter();
        }

        public PageResult<ChuDe> LayDSChuDe(Pagination pagination)
        {
            var dsChuDe = dbContext.ChuDe.AsQueryable();
            var result = PageResult<ChuDe>.ToPageResult(pagination, dsChuDe);
            return new PageResult<ChuDe>(pagination, result);
        }

        public ResponseObject<ChuDeDTO> SuaChuDe(SuaChuDeRequest request)
        {
            var chuDe = dbContext.ChuDe.FirstOrDefault(x => x.ChuDeID == request.ChuDeID);
            if (chuDe == null)
                return responseObject.ResponseError(StatusCodes.Status404NotFound, "Chủ đề không tồn tại", null);
            if (!dbContext.LoaiBaiViet.Any(x => x.LoaiBaiVietID == request.LoaiBaiVietID))
                return responseObject.ResponseError(StatusCodes.Status404NotFound, "Loại bài biết không tồn tại", null);
            chuDe.TenChuDe = request.TenChuDe;
            chuDe.NoiDung = request.NoiDung;
            chuDe.LoaiBaiVietID = request.LoaiBaiVietID;
            dbContext.Update(chuDe);
            dbContext.SaveChanges();
            return responseObject.ResponseSucess("Sửa chủ đề thành công", converter.EntityToDTO(chuDe));
        }

        public ResponseObject<ChuDeDTO> ThemChuDe(ThemChuDeRequest request)
        {
            if (!dbContext.LoaiBaiViet.Any(x => x.LoaiBaiVietID == request.LoaiBaiVietID))
                return responseObject.ResponseError(StatusCodes.Status404NotFound, "Loại bài biết không tồn tại", null);
            ChuDe chuDe = new ChuDe();
            chuDe.TenChuDe = request.TenChuDe;
            chuDe.NoiDung = request.NoiDung;
            chuDe.LoaiBaiVietID = request.LoaiBaiVietID;
            dbContext.Add(chuDe);
            dbContext.SaveChanges();
            return responseObject.ResponseSucess("Thêm chủ đề thành công",converter.EntityToDTO(chuDe));

        }

        public ResponseObject<ChuDeDTO> XoaChuDe(int id)
        {
            var chuDe = dbContext.ChuDe.FirstOrDefault(x => x.ChuDeID == id);
            if (chuDe == null)
                return responseObject.ResponseError(StatusCodes.Status404NotFound, "Chủ đề không tồn tại", null);
            dbContext.Remove(chuDe);
            dbContext.SaveChanges();
            return responseObject.ResponseSucess("Xoá chủ đề thành công", converter.EntityToDTO(chuDe));
        }
    }
}
