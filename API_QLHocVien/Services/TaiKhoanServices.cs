using API_QLHocVien.Context;
using API_QLHocVien.Entites;
using API_QLHocVien.Handle.Validate;
using API_QLHocVien.Helper;
using API_QLHocVien.IServices;
using API_QLHocVien.Payloads.Converters;
using API_QLHocVien.Payloads.DTOs;
using API_QLHocVien.Payloads.Requests.TaiKhoan;
using API_QLHocVien.Payloads.Responses;
using Azure.Core;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace API_QLHocVien.Services
{
    public class TaiKhoanServices : BaseServices, ITaiKhoanServices
    {
        private readonly ResponseObject<TaiKhoanDTO> responseObject;
        private readonly TaiKhoanConverter converter;

        public TaiKhoanServices()
        {
            responseObject = new ResponseObject<TaiKhoanDTO>();
            converter = new TaiKhoanConverter();
        }

        public PageResult<TaiKhoan> LayDSTaiKhoan(Pagination pagination)
        {
            var dsTaiKhoan = dbContext.TaiKhoan.AsQueryable();
            var result = PageResult<TaiKhoan>.ToPageResult(pagination, dsTaiKhoan);
            return new PageResult<TaiKhoan>(pagination, result);
        }

        public ResponseObject<TaiKhoanDTO> SuaTaiKhoan(SuaTaiKhoanRequest request)
        {
            var taiKhoan = dbContext.TaiKhoan.FirstOrDefault(x => x.TaiKhoanID == request.TaiKhoanID);
            if (taiKhoan == null)
                return responseObject.ResponseError(StatusCodes.Status404NotFound, "Khong tim thay tai khoan", null);
            if (dbContext.TaiKhoan.Any(x => x.TaiKhoanDN == request.TaiKhoanDN))
                return responseObject.ResponseError(StatusCodes.Status400BadRequest, "Tai khoan da ton tai", null);
            taiKhoan.TenNguoiDung = request.TenNguoiDung;
            taiKhoan.TaiKhoanDN = request.TaiKhoanDN;
            taiKhoan.MatKhau = request.MatKhau;
            taiKhoan.QuyenHanID = request.QuyenHanID;
            dbContext.Update(taiKhoan);
            dbContext.SaveChanges();
            return responseObject.ResponseSucess("Sua tai khoan thanh cong", converter.EntityToDTO(taiKhoan));
        }

        public ResponseObject<TaiKhoanDTO> ThemTaiKhoan(ThemTaiKhoanRequest request)
        {
            if (dbContext.TaiKhoan.Any(x => x.TaiKhoanDN == request.TaiKhoanDN))
                return responseObject.ResponseError(StatusCodes.Status400BadRequest, "Tai khoan da ton tai", null);
            if(!ValidatePassword.isValidPassword(request.MatKhau))
                return responseObject.ResponseError(StatusCodes.Status400BadRequest, "Mat khau phai co chu so va ky tu dac biet", null);
            TaiKhoan taiKhoan = new TaiKhoan();
            taiKhoan.TenNguoiDung = request.TenNguoiDung;
            taiKhoan.TaiKhoanDN = request.TaiKhoanDN;
            taiKhoan.MatKhau = request.MatKhau;
            taiKhoan.QuyenHanID = request.QuyenHanID;
            dbContext.Add(taiKhoan);
            dbContext.SaveChanges();
            return responseObject.ResponseSucess("Them tai khoan thanh cong", converter.EntityToDTO(taiKhoan));
        }
        

        public PageResult<TaiKhoan> TimKiemTaiKhoan(Pagination pagination, string? key)
        {
            var dsTaiKhoan = dbContext.TaiKhoan.AsQueryable();
            if (!string.IsNullOrEmpty(key))
                dsTaiKhoan = dsTaiKhoan.Where(x => x.TaiKhoanDN.ToLower().Contains(key.ToLower()));
            var result = PageResult<TaiKhoan>.ToPageResult(pagination, dsTaiKhoan);
            return new PageResult<TaiKhoan>(pagination, result);
        }

        public ResponseObject<TaiKhoanDTO> XoaTaiKhoan(int id)
        {
            var taiKhoan = dbContext.TaiKhoan.FirstOrDefault(x => x.TaiKhoanID == id);
            if (taiKhoan == null)
                return responseObject.ResponseError(StatusCodes.Status404NotFound, "Khong tim thay tai khoan", null);
            dbContext.Remove(taiKhoan);
            dbContext.SaveChanges();
            return responseObject.ResponseSucess("Xoa tai khoan thanh cong", converter.EntityToDTO(taiKhoan));
        }
    }
}
