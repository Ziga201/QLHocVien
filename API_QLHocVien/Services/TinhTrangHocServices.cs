using API_QLHocVien.Context;
using API_QLHocVien.Entites;
using API_QLHocVien.Helper;
using API_QLHocVien.IServices;
using API_QLHocVien.Payloads.Requests.TinhTrangHoc;
using API_QLHocVien.Payloads.Responses;
using Azure.Core;

namespace API_QLHocVien.Services
{
    public class TinhTrangHocServices : BaseServices, ITinhTrangHocServices
    {
        private readonly ResponseObject<TinhTrangHoc> responseObject;

        public TinhTrangHocServices()
        {
            responseObject = new ResponseObject<TinhTrangHoc>();
        }

        public List<TinhTrangHoc> LayDSTinhTrangHoc()
        {
            var dsTinhTrangHoc = dbContext.TinhTrangHoc.ToList();
            return dsTinhTrangHoc;
        }

        public ResponseObject<TinhTrangHoc> SuaTinhTrangHoc(SuaTinhTrangHocRequest request)
        {
            var tinhTrangHoc = dbContext.TinhTrangHoc.FirstOrDefault(x => x.TinhTrangHocID == request.TinhTrangHocID);
            if(tinhTrangHoc == null)
                return responseObject.ResponseError(StatusCodes.Status404NotFound,"Tình trạng học Không tồn tại", null);
            tinhTrangHoc.TenTinhTrang = request.TenTinhTrang;
            dbContext.Update(tinhTrangHoc);
            dbContext.SaveChanges();
            return responseObject.ResponseSucess("Sửa tình trạng học thành công", tinhTrangHoc);
        }

        public ResponseObject<TinhTrangHoc> ThemTinhTrangHoc(ThemTinhTrangHocRequest request)
        {
            TinhTrangHoc tinhTrangHoc = new TinhTrangHoc();
            tinhTrangHoc.TenTinhTrang = request.TenTinhTrang;
            dbContext.Add(tinhTrangHoc);
            dbContext.SaveChanges();
            return responseObject.ResponseSucess("Thêm tình trạng học thành công", tinhTrangHoc);
        }

        public ResponseObject<TinhTrangHoc> XoaTinhTrangHoc(int id)
        {
            var tinhTrangHoc = dbContext.TinhTrangHoc.FirstOrDefault(x => x.TinhTrangHocID == id);
            if (tinhTrangHoc == null)
                return responseObject.ResponseError(StatusCodes.Status404NotFound, "Tình trạng học Không tồn tại", null);
            dbContext.Remove(tinhTrangHoc);
            dbContext.SaveChanges();
            return responseObject.ResponseSucess("Xoá tình trạng học thành công", tinhTrangHoc);
        }
    }
}
