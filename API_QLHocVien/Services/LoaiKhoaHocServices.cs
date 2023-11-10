using API_QLHocVien.Context;
using API_QLHocVien.Entites;
using API_QLHocVien.IServices;
using API_QLHocVien.Payloads.Converters;
using API_QLHocVien.Payloads.DTOs;
using API_QLHocVien.Payloads.Requests.KhoaHoc;
using API_QLHocVien.Payloads.Responses;

namespace API_QLHocVien.Services
{
    public class LoaiKhoaHocServices : BaseServices, ILoaiKhoaHocServices
    {
        private readonly ResponseObject<LoaiKhoaHocDTO> responseObject;
        private readonly LoaiKhoaHocConverter loaiKhoaHocConverter;

        public LoaiKhoaHocServices()
        {
            responseObject = new ResponseObject<LoaiKhoaHocDTO>();
            loaiKhoaHocConverter = new LoaiKhoaHocConverter();
        }
        public ResponseObject<LoaiKhoaHocDTO> SuaLoaiKhoaHoc(SuaLoaiKhoaHocRequest request)
        {
            var loaiKhoaHocCanSua = dbContext.LoaiKhoaHoc.FirstOrDefault(x => x.LoaiKhoaHocID == request.LoaiKhoaHocID);
            if (loaiKhoaHocCanSua != null)
            {
                loaiKhoaHocCanSua.TenLoai = request.TenLoai;
                dbContext.Update(loaiKhoaHocCanSua);
                dbContext.SaveChanges();
                return responseObject.ResponseSucess("Sửa khoá học thành công", loaiKhoaHocConverter.EntityToDTO(loaiKhoaHocCanSua));
            }
            else return responseObject.ResponseError(StatusCodes.Status404NotFound, "Không tìm thấy loại khoá học", null);
        }
        public ResponseObject<LoaiKhoaHocDTO> ThemLoaiKhoaHoc(ThemLoaiKhoaHocRequest request)
        {
            LoaiKhoaHoc loaiKhoaHoc = new LoaiKhoaHoc();
            loaiKhoaHoc.TenLoai = request.TenLoai;
            dbContext.LoaiKhoaHoc.Add(loaiKhoaHoc);
            dbContext.SaveChanges();
            return responseObject.ResponseSucess("Thêm loại khoá học thành công", loaiKhoaHocConverter.EntityToDTO(loaiKhoaHoc));
        }
        public ResponseObject<LoaiKhoaHocDTO> XoaLoaiKhoaHoc(int idLoaiKhoaHoc)
        {
            var loaiKhoaHoc = dbContext.LoaiKhoaHoc.FirstOrDefault(x => x.LoaiKhoaHocID == idLoaiKhoaHoc);
            if (loaiKhoaHoc != null)
            {
                dbContext.Remove(loaiKhoaHoc);
                dbContext.SaveChanges();
                return responseObject.ResponseSucess("Xoá thành công", loaiKhoaHocConverter.EntityToDTO(loaiKhoaHoc));
            }
            else return responseObject.ResponseError(StatusCodes.Status404NotFound, "Không tìm thấy loại khoá học", null);
        }

    }
}
