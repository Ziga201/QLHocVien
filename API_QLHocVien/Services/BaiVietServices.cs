using API_QLHocVien.Context;
using API_QLHocVien.Entites;
using API_QLHocVien.Handle.Image;
using API_QLHocVien.Helper;
using API_QLHocVien.IServices;
using API_QLHocVien.Payloads.Converters;
using API_QLHocVien.Payloads.DTOs;
using API_QLHocVien.Payloads.Requests.BaiViet;
using API_QLHocVien.Payloads.Responses;
using Azure.Core;

namespace API_QLHocVien.Services
{
    public class BaiVietServices : BaseServices, IBaiVietServices
    {
        private readonly ResponseObject<BaiVietDTO> responseObject;
        private readonly BaiVietConverter converter;

        public BaiVietServices()
        {
            responseObject = new ResponseObject<BaiVietDTO>();
            converter = new BaiVietConverter();
        }

        public PageResult<BaiViet> LayDSBaiViet(Pagination pagination)
        {
            var dsBaiViet = dbContext.BaiViet.AsQueryable();
            var result = PageResult<BaiViet>.ToPageResult(pagination, dsBaiViet);
            return new PageResult<BaiViet>(pagination, result);
        }

        public async Task<ResponseObject<BaiVietDTO>> SuaBaiViet(SuaBaiVietRequest request)
        {
            var baiViet = dbContext.BaiViet.FirstOrDefault(x => x.BaiVietID == request.BaiVietID);
            if(baiViet == null)
                return responseObject.ResponseError(StatusCodes.Status404NotFound, "Bài viết không tồn tại", null); ;
            if (!dbContext.ChuDe.Any(x => x.ChuDeID == request.ChuDeID))
                return responseObject.ResponseError(StatusCodes.Status404NotFound, "Chủ đề không tồn tại", null);
            if (!dbContext.TaiKhoan.Any(x => x.TaiKhoanID == request.TaiKhoanID))
                return responseObject.ResponseError(StatusCodes.Status404NotFound, "Tài khoản không tồn tại", null);
            var avatarFile = await UploadImage.Upfile(request.HinhAnh);

            baiViet.TenBaiViet = request.TenBaiViet;
            baiViet.TenTacGia = request.TenTacGia;
            baiViet.NoiDung = request.NoiDung;
            baiViet.NoiDungNgan = request.NoiDungNgan;
            baiViet.HinhAnh = avatarFile == "" ? "https://inkythuatso.com/uploads/thumbnails/800/2023/03/9-anh-dai-dien-trang-inkythuatso-03-15-27-03.jpg" : avatarFile;
            baiViet.ChuDeID = request.ChuDeID;
            baiViet.TaiKhoanID = request.TaiKhoanID;
            dbContext.Update(baiViet);
            dbContext.SaveChanges();
            return responseObject.ResponseSucess("Sửa bài viết thành công", converter.EntityToDTO(baiViet));
        }

        public async Task<ResponseObject<BaiVietDTO>> ThemBaiViet(ThemBaiVietRequest request)
        {
            if (!dbContext.ChuDe.Any(x => x.ChuDeID == request.ChuDeID))
                return responseObject.ResponseError(StatusCodes.Status404NotFound, "Chủ đề không tồn tại", null);
            if (!dbContext.TaiKhoan.Any(x => x.TaiKhoanID == request.TaiKhoanID))
                return responseObject.ResponseError(StatusCodes.Status404NotFound, "Tài khoản không tồn tại", null);
            var avatarFile = await UploadImage.Upfile(request.HinhAnh);
            BaiViet baiViet = new BaiViet();
            baiViet.TenBaiViet = request.TenBaiViet;
            baiViet.ThoiGianTao = DateTime.Now;
            baiViet.TenTacGia = request.TenTacGia;
            baiViet.NoiDung = request.NoiDung;
            baiViet.NoiDungNgan = request.NoiDungNgan;
            baiViet.HinhAnh = avatarFile == "" ? "https://inkythuatso.com/uploads/thumbnails/800/2023/03/9-anh-dai-dien-trang-inkythuatso-03-15-27-03.jpg" : avatarFile;
            baiViet.ChuDeID = request.ChuDeID;
            baiViet.TaiKhoanID = request.TaiKhoanID;
            dbContext.Add(baiViet);
            dbContext.SaveChanges();
            return responseObject.ResponseSucess("Thêm bài viết thành công",converter.EntityToDTO(baiViet));
        }

        public PageResult<BaiViet> TimKiemBaiViet(Pagination pagination, string? key)
        {
            var dsBaiViet = dbContext.BaiViet.AsQueryable();
            if(!string.IsNullOrEmpty(key))
                dsBaiViet = dsBaiViet.Where(x => x.TenBaiViet.ToLower().Contains(key.ToLower()));
            var result = PageResult<BaiViet>.ToPageResult(pagination, dsBaiViet);
            return new PageResult<BaiViet>(pagination, result);
        }

        public ResponseObject<BaiVietDTO> XoaBaiViet(int id)
        {
            var baiViet = dbContext.BaiViet.FirstOrDefault(x => x.BaiVietID == id);
            if (baiViet == null)
                return responseObject.ResponseError(StatusCodes.Status404NotFound, "Bài viết không tồn tại", null); ;
            dbContext.Remove(baiViet);
            dbContext.SaveChanges();
            return responseObject.ResponseSucess("Xoá bài viết thành công", converter.EntityToDTO(baiViet));
        }
    }
}
