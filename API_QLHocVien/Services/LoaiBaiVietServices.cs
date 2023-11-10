using API_QLHocVien.Context;
using API_QLHocVien.Entites;
using API_QLHocVien.Helper;
using API_QLHocVien.IServices;
using API_QLHocVien.Payloads.Requests.LoaiBaiViet;
using API_QLHocVien.Payloads.Responses;

namespace API_QLHocVien.Services
{
    public class LoaiBaiVietServices : BaseServices, ILoaiBaiVietServices
    {
        private readonly ResponseObject<LoaiBaiViet> responseObject;

        public LoaiBaiVietServices()
        {
            responseObject = new ResponseObject<LoaiBaiViet>();
        }
        public PageResult<LoaiBaiViet> LayDSLoaiBaiViet(Pagination pagination)
        {
            var dsLoaiBaiViet = dbContext.LoaiBaiViet.AsQueryable();
            var result = PageResult<LoaiBaiViet>.ToPageResult(pagination, dsLoaiBaiViet);
            return new PageResult<LoaiBaiViet>(pagination, result);
        }

        public ResponseObject<LoaiBaiViet> SuaLoaiBaiViet(SuaLoaiBaiVietRequest request)
        {
            var baiViet = dbContext.LoaiBaiViet.FirstOrDefault(x => x.LoaiBaiVietID == request.LoaiBaiVietID);
            if (baiViet == null)
                return responseObject.ResponseError(StatusCodes.Status404NotFound, "Không tìm thấy loại bài viết", null);
            baiViet.TenLoai = request.TenLoai;
            dbContext.Update(baiViet);
            dbContext.SaveChanges();
            return responseObject.ResponseSucess("Sửa bài viết thành công", baiViet);
        }

        public ResponseObject<LoaiBaiViet> ThemLoaiBaiViet(ThemLoaiBaiVietRequest request)
        {
            LoaiBaiViet loaiBaiViet = new LoaiBaiViet();
            loaiBaiViet.TenLoai = request.TenLoai;
            dbContext.Add(loaiBaiViet);
            dbContext.SaveChanges();
            return responseObject.ResponseSucess("Thêm loại bài viết thành công", loaiBaiViet);

        }

        public ResponseObject<LoaiBaiViet> XoaLoaiBaiViet(int idBaiViet)
        {
            var baiViet = dbContext.LoaiBaiViet.FirstOrDefault(x => x.LoaiBaiVietID == idBaiViet);
            if (baiViet == null)
                return responseObject.ResponseError(StatusCodes.Status404NotFound, "Không tìm thấy loại bài viết", null);
            dbContext.Remove(baiViet);
            dbContext.SaveChanges();
            return responseObject.ResponseSucess("Xoá loại bài viết thành công", baiViet);
        }
    }
}
