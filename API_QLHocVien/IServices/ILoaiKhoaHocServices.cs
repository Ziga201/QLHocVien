using API_QLHocVien.Payloads.DTOs;
using API_QLHocVien.Payloads.Requests.KhoaHoc;
using API_QLHocVien.Payloads.Responses;

namespace API_QLHocVien.IServices
{
    public interface ILoaiKhoaHocServices
    {
        ResponseObject<LoaiKhoaHocDTO> ThemLoaiKhoaHoc(ThemLoaiKhoaHocRequest request);
        ResponseObject<LoaiKhoaHocDTO> SuaLoaiKhoaHoc(SuaLoaiKhoaHocRequest request);
        ResponseObject<LoaiKhoaHocDTO> XoaLoaiKhoaHoc(int idLoaiKhoaHoc);
    }
}
