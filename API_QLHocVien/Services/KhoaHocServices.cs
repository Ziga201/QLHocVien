using API_QLHocVien.Context;
using API_QLHocVien.Entites;
using API_QLHocVien.Handle.Image;
using API_QLHocVien.Helper;
using API_QLHocVien.IServices;
using API_QLHocVien.Payloads.Converters;
using API_QLHocVien.Payloads.DTOs;
using API_QLHocVien.Payloads.Requests.KhoaHoc;
using API_QLHocVien.Payloads.Responses;
using Azure.Core;
using Microsoft.IdentityModel.Tokens;

namespace API_QLHocVien.Services
{
    public class KhoaHocServices : BaseServices, IKhoaHocServices
    {
        private readonly ResponseObject<KhoaHocDTO> responseObjectKhoaHoc;
        private readonly KhoaHocConverter khoaHocConverter;

        public KhoaHocServices()
        {
            responseObjectKhoaHoc = new ResponseObject<KhoaHocDTO>();
            khoaHocConverter = new KhoaHocConverter();
        }

        public PageResult<KhoaHoc> GetDSKhoaHoc(Pagination pagination)
        {
            var khoaHoc = dbContext.KhoaHoc.ToList();
            var result = PageResult<KhoaHoc>.ToPageResult(pagination, khoaHoc);
            pagination.TotalCount = result.Count();
            return new PageResult<KhoaHoc>(pagination, result);
        }

        public async Task<ResponseObject<KhoaHocDTO>> SuaKhoaHoc(SuaKhoaHocRequest request)
        {
            var khoaHocCanSua = dbContext.KhoaHoc.FirstOrDefault(x => x.KhoaHocID == request.KhoaHocID);
            if (khoaHocCanSua == null)
                return responseObjectKhoaHoc.ResponseError(StatusCodes.Status404NotFound, "Khong tim thay khoa hoc", null);
            if (!dbContext.LoaiKhoaHoc.Any(x => x.LoaiKhoaHocID == request.LoaiKhoaHocID))
                return responseObjectKhoaHoc.ResponseError(StatusCodes.Status404NotFound, "Khong tim thay loai khoa hoc", null);
            khoaHocCanSua.TenKhoaHoc = request.TenKhoaHoc;
            khoaHocCanSua.ThoiGianHoc = request.ThoiGianHoc;
            khoaHocCanSua.GioiThieu = request.GioiThieu;
            khoaHocCanSua.NoiDung = request.NoiDung;
            khoaHocCanSua.HocPhi = request.HocPhi;
            //khoaHocCanSua.SoHocVien = request.SoHocVien;
            khoaHocCanSua.SoLuongMon = request.SoLuongMon;
            var avatarFile = await UploadImage.Upfile(request.HinhAnh);
            khoaHocCanSua.HinhAnh = avatarFile == "" ? "https://inkythuatso.com/uploads/thumbnails/800/2023/03/9-anh-dai-dien-trang-inkythuatso-03-15-27-03.jpg" : avatarFile;

            khoaHocCanSua.LoaiKhoaHocID = request.LoaiKhoaHocID;
            dbContext.Update(khoaHocCanSua);
            dbContext.SaveChanges();
            return responseObjectKhoaHoc.ResponseSucess("Sua khoa hoc thanh cong", khoaHocConverter.EntityToDTO(khoaHocCanSua));
        }

        

        public async Task<ResponseObject<KhoaHocDTO>> ThemKhoaHoc(ThemKhoaHocRequest request)
        {
            if (!dbContext.LoaiKhoaHoc.Any(x => x.LoaiKhoaHocID == request.LoaiKhoaHocID))
                return responseObjectKhoaHoc.ResponseError(StatusCodes.Status404NotFound, "Khong tim thay loai khoa hoc", null);
            KhoaHoc khoaHoc = new KhoaHoc();
            khoaHoc.TenKhoaHoc = request.TenKhoaHoc;
            khoaHoc.ThoiGianHoc = request.ThoiGianHoc;
            khoaHoc.GioiThieu = request.GioiThieu;
            khoaHoc.NoiDung = request.NoiDung;
            khoaHoc.HocPhi = request.HocPhi;
            //khoaHoc.SoHocVien = request.SoHocVien;
            khoaHoc.SoLuongMon = request.SoLuongMon;
            var avatarFile = await UploadImage.Upfile(request.HinhAnh);
            khoaHoc.HinhAnh = avatarFile == "" ? "https://inkythuatso.com/uploads/thumbnails/800/2023/03/9-anh-dai-dien-trang-inkythuatso-03-15-27-03.jpg" : avatarFile;

            khoaHoc.LoaiKhoaHocID = request.LoaiKhoaHocID;
            dbContext.Add(khoaHoc);
            dbContext.SaveChanges();
            return responseObjectKhoaHoc.ResponseSucess("Them khoa hoc thanh cong", khoaHocConverter.EntityToDTO(khoaHoc));
        }

        

        public PageResult<KhoaHoc> TimKiemKhoaHoc(Pagination pagination, string? key)
        {
            var listKhoaHoc = dbContext.KhoaHoc.AsQueryable();
            if (!string.IsNullOrEmpty(key))
            {
                listKhoaHoc = listKhoaHoc.Where(x => x.TenKhoaHoc.ToLower().Contains(key.ToLower()));
            }
            var result = PageResult<KhoaHoc>.ToPageResult(pagination, listKhoaHoc);
            pagination.TotalCount = result.Count();
            return new PageResult<KhoaHoc>(pagination, result);
        }

        public ResponseObject<KhoaHocDTO> XoaKhoaHoc(int idKhoaHoc)
        {
            var khoaHocCanXoa= dbContext.KhoaHoc.FirstOrDefault(x => x.KhoaHocID == idKhoaHoc);
            if (khoaHocCanXoa == null)
                return responseObjectKhoaHoc.ResponseError(StatusCodes.Status404NotFound, "Khong tim thay khoa hoc", null);
            dbContext.Remove(khoaHocCanXoa);
            dbContext.SaveChanges();
            return responseObjectKhoaHoc.ResponseSucess("Xoa khoa hoc thanh cong", khoaHocConverter.EntityToDTO(khoaHocCanXoa));
        }

        
    }
}
