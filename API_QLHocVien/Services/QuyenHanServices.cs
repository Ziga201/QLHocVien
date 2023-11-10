using API_QLHocVien.Context;
using API_QLHocVien.Entites;
using API_QLHocVien.Helper;
using API_QLHocVien.IServices;
using API_QLHocVien.Payloads.DTOs;
using API_QLHocVien.Payloads.Requests.QuyenHan;
using API_QLHocVien.Payloads.Responses;

namespace API_QLHocVien.Services
{
    public class QuyenHanServices : BaseServices, IQuyenHanServices
    {
        private readonly ResponseObject<QuyenHan> responseObject;

        public QuyenHanServices()
        {
            responseObject = new ResponseObject<QuyenHan>();
        }

        public PageResult<QuyenHan> LayDSQuyenHan(Pagination pagination)
        {
            var dsQuyenHan = dbContext.QuyenHan.AsQueryable();
            var result = PageResult<QuyenHan>.ToPageResult(pagination, dsQuyenHan);
            return new PageResult<QuyenHan>(pagination, result);
        }

        public ResponseObject<QuyenHan> SuaQuyenHan(SuaQuyenHanRequest request)
        {
            var quyenHanCanSua = dbContext.QuyenHan.FirstOrDefault(x => x.QuyenHanID == request.QuyenHanID);
            if (quyenHanCanSua == null)
                return responseObject.ResponseError(StatusCodes.Status404NotFound, "Khong tim thay quyen han", null);
            quyenHanCanSua.TenQuyenHan = request.TenQuyenHan;
            dbContext.Update(quyenHanCanSua);
            dbContext.SaveChanges();
            return responseObject.ResponseSucess("Sua quyen han thanh cong", quyenHanCanSua);
        }

        public ResponseObject<QuyenHan> ThemQuyenHan(ThemQuyenHanRequest request)
        {
            QuyenHan quyenHan = new QuyenHan();
            quyenHan.TenQuyenHan = request.TenQuyenHan;
            dbContext.Add(quyenHan);
            dbContext.SaveChanges();
            return responseObject.ResponseSucess("Them quyen han thanh cong", quyenHan);
        }

        public ResponseObject<QuyenHan> XoaQuyenHan(int id)
        {
            var quyenHan = dbContext.QuyenHan.FirstOrDefault(x => x.QuyenHanID == id);
            if (quyenHan == null)
                return responseObject.ResponseError(StatusCodes.Status404NotFound, "Khong tim thay quyen han", null);
            dbContext.Remove(quyenHan);
            dbContext.SaveChanges();
            return responseObject.ResponseSucess("Xoa quyen han thanh cong", quyenHan);
        }
    }
}
