using API_QLHocVien.Entites;
using API_QLHocVien.Helper;
using API_QLHocVien.Payloads.DTOs;
using API_QLHocVien.Payloads.Requests.KhoaHoc;
using API_QLHocVien.Payloads.Responses;

namespace API_QLHocVien.IServices
{
    public interface IKhoaHocServices
    {
        
        Task<ResponseObject<KhoaHocDTO>> ThemKhoaHoc(ThemKhoaHocRequest request);
        Task<ResponseObject<KhoaHocDTO>> SuaKhoaHoc(SuaKhoaHocRequest request);
        ResponseObject<KhoaHocDTO> XoaKhoaHoc(int idKhoaHoc);
        PageResult<KhoaHoc>GetDSKhoaHoc(Pagination pagination);
        PageResult<KhoaHoc>TimKiemKhoaHoc(Pagination pagination, string? key);

    }
}
