using API_QLHocVien.Context;
using API_QLHocVien.Entites;
using API_QLHocVien.Helper;
using API_QLHocVien.IServices;
using API_QLHocVien.Payloads.Converters;
using API_QLHocVien.Payloads.DTOs;
using API_QLHocVien.Payloads.Requests.DangKyHoc;
using API_QLHocVien.Payloads.Responses;
using Azure.Core;

namespace API_QLHocVien.Services
{
    public class DangKyHocServices : BaseServices, IDangKyHocServices
    {
        private readonly ResponseObject<DangKyHocDTO> responseObject;
        private readonly DangKyHocConverter converter;

        public DangKyHocServices()
        {
            responseObject = new ResponseObject<DangKyHocDTO>();
            converter = new DangKyHocConverter();
        }

        public PageResult<DangKyHoc> LayDSDangKyHoc(Pagination pagination)
        {
            var dsDangKyHoc = dbContext.DangKyHoc.AsQueryable();
            var result = PageResult<DangKyHoc>.ToPageResult(pagination, dsDangKyHoc);
            return new PageResult<DangKyHoc>(pagination, result);
        }

        public ResponseObject<DangKyHocDTO> SuaDangKyHoc(SuaDangKyHocRequest request)
        {
            var dangKyHoc = dbContext.DangKyHoc.FirstOrDefault(x => x.ID == request.ID);
            if (dangKyHoc == null)
                return responseObject.ResponseError(StatusCodes.Status404NotFound, "Đăng ký học không tồn tại", null);
            if (!dbContext.KhoaHoc.Any(x => x.KhoaHocID == request.KhoaHocID))
                return responseObject.ResponseError(StatusCodes.Status404NotFound, "Khoá học không tồn tại", null);
            if (!dbContext.HocVien.Any(x => x.HocVienID == request.HocVienID))
                return responseObject.ResponseError(StatusCodes.Status404NotFound, "Học viên không tồn tại", null);
            if (!dbContext.TaiKhoan.Any(x => x.TaiKhoanID == request.TaiKhoanID))
                return responseObject.ResponseError(StatusCodes.Status404NotFound, "Tài khoản không tồn tại", null);

            dangKyHoc.KhoaHocID = request.KhoaHocID;
            dangKyHoc.HocVienID = request.HocVienID;
            dangKyHoc.NgayDangKy = request.NgayDangKy;
            dangKyHoc.NgayBatDau = request.NgayBatDau;
            dangKyHoc.NgayKetThuc = request.NgayKetThuc;


            dangKyHoc.TaiKhoanID = request.TaiKhoanID;
            dbContext.Update(dangKyHoc);
            dbContext.SaveChanges();
            CapNhatSoLuong(request.KhoaHocID);
            return responseObject.ResponseSucess("Sửa đăng ký học thành công", converter.EntityToDTO(dangKyHoc));
        }

        public ResponseObject<DangKyHocDTO> CapNhatTrangThaiHoc(int idDangKyHoc, int tinhTrangHocId)
        {
            var dangKyHoc = dbContext.DangKyHoc.FirstOrDefault(x => x.ID == idDangKyHoc);
            if (dangKyHoc == null)
                return responseObject.ResponseError(StatusCodes.Status404NotFound, "Đăng ký học không tồn tại", null);
            if (!dbContext.TinhTrangHoc.Any(x => x.TinhTrangHocID == tinhTrangHocId))
                return responseObject.ResponseError(StatusCodes.Status404NotFound, "Tình trạng học không tồn tại", null);
            var khoaHoc = dbContext.KhoaHoc.FirstOrDefault(x => x.KhoaHocID == dangKyHoc.KhoaHocID);
            switch (tinhTrangHocId)
            {
                case 1: //chờ duyệt
                    dangKyHoc.TinhTrangHocID = 1;
                    dbContext.Update(dangKyHoc);
                    dbContext.SaveChanges();
                    break;
                case 2: // đang học chính
                    if (dangKyHoc.NgayBatDau == null && dangKyHoc.NgayKetThuc == null)
                    {
                        dangKyHoc.NgayBatDau = DateTime.Now;
                        dangKyHoc.NgayKetThuc = DateTime.Now.AddMonths(khoaHoc.ThoiGianHoc);
                        dbContext.Update(dangKyHoc);
                    }
                    dangKyHoc.TinhTrangHocID = 2;
                    dbContext.Update(dangKyHoc);
                    dbContext.SaveChanges();
                    break;
                case 3://học xong
                    dangKyHoc.TinhTrangHocID = 3;
                    dbContext.Update(dangKyHoc);
                    dbContext.SaveChanges();
                    break;
                case 4://chưa hoàn thành
                    dangKyHoc.TinhTrangHocID = 4;
                    dbContext.Update(dangKyHoc);
                    dbContext.SaveChanges();
                    break;
                default:
                    break;
            }
            CapNhatSoLuong(dangKyHoc.KhoaHocID);
            return responseObject.ResponseSucess("Cập nhật trạng thái học thành công", converter.EntityToDTO(dangKyHoc));
        }

        private void CapNhatSoLuong(int idKhoaHoc)
        {
            
            try
            {
                var khoaHoc = dbContext.KhoaHoc.FirstOrDefault(x => x.KhoaHocID == idKhoaHoc);
                khoaHoc.SoHocVien = dbContext.DangKyHoc.Where(x => x.KhoaHocID == khoaHoc.KhoaHocID
                && (x.TinhTrangHocID == 2 || x.TinhTrangHocID == 3 || x.TinhTrangHocID == 4)).Count();
                dbContext.Update(khoaHoc);
                dbContext.SaveChanges();
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void CapNhatTrangThaiHocXong()
        {
            var dangKyHoc = dbContext.DangKyHoc.ToList();
            dangKyHoc.ForEach(x =>
            {
                if (x.TinhTrangHocID != 4)
                {
                    x.TinhTrangHocID = x.NgayKetThuc < DateTime.Now ? 3 : x.TinhTrangHocID;
                    dbContext.Update(x);
                }
            });
            dbContext.SaveChanges();
        }

        public ResponseObject<DangKyHocDTO> ThemDangKyHoc(ThemDangKyHocRequest request)
        {
            if (!dbContext.KhoaHoc.Any(x => x.KhoaHocID == request.KhoaHocID))
                return responseObject.ResponseError(StatusCodes.Status404NotFound, "Khoá học không tồn tại", null);
            if (!dbContext.HocVien.Any(x => x.HocVienID == request.HocVienID))
                return responseObject.ResponseError(StatusCodes.Status404NotFound, "Học viên không tồn tại", null);
            if (!dbContext.TaiKhoan.Any(x => x.TaiKhoanID == request.TaiKhoanID))
                return responseObject.ResponseError(StatusCodes.Status404NotFound, "Tài khoản không tồn tại", null);
            DangKyHoc dangKyHoc = new DangKyHoc();
            dangKyHoc.KhoaHocID = request.KhoaHocID;
            dangKyHoc.HocVienID = request.HocVienID;
            dangKyHoc.NgayDangKy = DateTime.Now;
            dangKyHoc.NgayBatDau = null;
            dangKyHoc.NgayKetThuc = null;
            dangKyHoc.TinhTrangHocID = 1;
            dangKyHoc.TaiKhoanID = request.TaiKhoanID;
            
            dbContext.Add(dangKyHoc);
            dbContext.SaveChanges();
            return responseObject.ResponseSucess("Thêm đăng ký học thành công", converter.EntityToDTO(dangKyHoc));
        }

        

        public ResponseObject<DangKyHocDTO> XoaDangKyHoc(int id)
        {
            var dangKyHoc = dbContext.DangKyHoc.FirstOrDefault(x => x.ID == id);
            if (dangKyHoc == null)
                return responseObject.ResponseError(StatusCodes.Status404NotFound, "Đăng ký học không tồn tại", null);
            dbContext.Remove(dangKyHoc);
            dbContext.SaveChanges();
            return responseObject.ResponseSucess("Xoá đăng ký học thành công", converter.EntityToDTO(dangKyHoc));
        }
    }
}
