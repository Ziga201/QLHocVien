using API_QLHocVien.Entites;
using API_QLHocVien.Helper;
using API_QLHocVien.Payloads.DTOs;
using API_QLHocVien.Payloads.Requests.QuyenHan;
using API_QLHocVien.Payloads.Responses;

namespace API_QLHocVien.IServices
{
    public interface IQuyenHanServices
    {
        ResponseObject<QuyenHan> ThemQuyenHan(ThemQuyenHanRequest request);
        ResponseObject<QuyenHan> SuaQuyenHan(SuaQuyenHanRequest request);
        ResponseObject<QuyenHan> XoaQuyenHan(int id);
        PageResult<QuyenHan> LayDSQuyenHan(Pagination pagination);
    }
}
