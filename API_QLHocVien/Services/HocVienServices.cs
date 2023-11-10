using API_QLHocVien.Context;
using API_QLHocVien.Entites;
using API_QLHocVien.Handle.Image;
using API_QLHocVien.Helper;
using API_QLHocVien.IServices;
using API_QLHocVien.Payloads.Converters;
using API_QLHocVien.Payloads.DTOs;
using API_QLHocVien.Payloads.Requests.HocVien;
using API_QLHocVien.Payloads.Responses;
using Azure.Core;

namespace API_QLHocVien.Services
{
    public class HocVienServices : BaseServices, IHocVienServices
    {
        private readonly ResponseObject<HocVien> responseObject;

        public HocVienServices()
        {
            responseObject = new ResponseObject<HocVien>();
        }

        public PageResult<HocVien> LayDSHocVien(Pagination pagination)
        {
            var dsHocVien = dbContext.HocVien.ToList();
            var result = PageResult<HocVien>.ToPageResult(pagination, dsHocVien);
            pagination.TotalCount = result.Count();
            return new PageResult<HocVien>(pagination, result);
        }

        public async Task<ResponseObject<HocVien>> SuaHocVien(SuaHocVienRequest request)
        {
            var hocVienCanSua = dbContext.HocVien.FirstOrDefault(x => x.HocVienID == request.HocVienID);
            if (hocVienCanSua == null)
                return responseObject.ResponseError(StatusCodes.Status404NotFound, "Khong tim thay hoc vien", null);
            if (dbContext.HocVien.Any(x => x.Email == request.Email))
                return responseObject.ResponseError(StatusCodes.Status400BadRequest, "Email da ton tai", null);
            if (dbContext.HocVien.Any(x => x.SDT == request.SDT))
                return responseObject.ResponseError(StatusCodes.Status400BadRequest, "So dien thoai da ton tai", null);
            var avatarFile = await UploadImage.Upfile(request.HinhAnh);
            hocVienCanSua.HinhAnh = avatarFile == "" ? "https://inkythuatso.com/uploads/thumbnails/800/2023/03/9-anh-dai-dien-trang-inkythuatso-03-15-27-03.jpg" : avatarFile;
            hocVienCanSua.HoTen = request.HoTen;
            hocVienCanSua.NgaySinh = request.NgaySinh;
            hocVienCanSua.SDT = request.SDT;
            hocVienCanSua.Email = request.Email;
            hocVienCanSua.TinhThanh = request.TinhThanh;
            hocVienCanSua.QuanHuyen = request.QuanHuyen;
            hocVienCanSua.PhuongXa = request.PhuongXa;
            hocVienCanSua.SoNha = request.SoNha;
            dbContext.Update(hocVienCanSua);
            dbContext.SaveChanges();
            return responseObject.ResponseSucess("Sua hoc vien thanh cong", hocVienCanSua);
        }

        public async Task<ResponseObject<HocVien>> ThemHocVien(ThemHocVienRequest request)
        {
            if (dbContext.HocVien.Any(x => x.Email == request.Email))
                return responseObject.ResponseError(StatusCodes.Status400BadRequest, "Email da ton tai", null);
            if (dbContext.HocVien.Any(x => x.SDT == request.SDT))
                return responseObject.ResponseError(StatusCodes.Status400BadRequest, "So dien thoai da ton tai", null);
            if (request.HinhAnh == null)
                return responseObject.ResponseError(StatusCodes.Status400BadRequest, "Không có hình ảnh", null);
            HocVien hocVien = new HocVien();
            hocVien.HoTen = request.HoTen;
            hocVien.NgaySinh = request.NgaySinh;
            hocVien.SDT = request.SDT;
            hocVien.Email = request.Email;
            hocVien.TinhThanh = request.TinhThanh;
            hocVien.QuanHuyen = request.QuanHuyen;
            hocVien.PhuongXa = request.PhuongXa;
            hocVien.SoNha = request.SoNha;

            var avatarFile = await UploadImage.Upfile(request.HinhAnh);
            hocVien.HinhAnh = avatarFile == "" ? "https://inkythuatso.com/uploads/thumbnails/800/2023/03/9-anh-dai-dien-trang-inkythuatso-03-15-27-03.jpg" : avatarFile;
            dbContext.Add(hocVien);
            dbContext.SaveChanges();
            return responseObject.ResponseSucess("Them hoc vien thanh cong", hocVien);
        }

        public PageResult<HocVien> TimKiemHocVien(Pagination pagination, string? name, string? email)
        {
            var dsHocVien = dbContext.HocVien.AsQueryable();
            if (!string.IsNullOrEmpty(name))
                dsHocVien = dsHocVien.Where(x => x.HoTen.ToLower().Contains(name.ToLower()));
            if (!string.IsNullOrEmpty(email))
                dsHocVien = dsHocVien.Where(x => x.Email.ToLower().Contains(email.ToLower()));
            var result = PageResult<HocVien>.ToPageResult(pagination, dsHocVien);
            return new PageResult<HocVien>(pagination, result);
        }

        public ResponseObject<HocVien> XoaHocVien(int idHocVien)
        {
            var hocVienCanXoa = dbContext.HocVien.FirstOrDefault(x => x.HocVienID == idHocVien);
            if (hocVienCanXoa == null)
                return responseObject.ResponseError(StatusCodes.Status404NotFound, "Khong tim thay hoc vien", null);
            dbContext.Remove(hocVienCanXoa);
            dbContext.SaveChanges(true);
            return responseObject.ResponseSucess("Sua hoc vien thanh cong", hocVienCanXoa);
        }
    }
}
