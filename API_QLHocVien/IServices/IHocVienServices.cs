using API_QLHocVien.Entites;
using API_QLHocVien.Helper;
using API_QLHocVien.Payloads.DTOs;
using API_QLHocVien.Payloads.Requests.HocVien;
using API_QLHocVien.Payloads.Responses;

namespace API_QLHocVien.IServices
{
    public interface IHocVienServices
    {
        Task<ResponseObject<HocVien>> ThemHocVien(ThemHocVienRequest request);
        Task<ResponseObject<HocVien>> SuaHocVien(SuaHocVienRequest request);
        ResponseObject<HocVien> XoaHocVien(int idHocVien);
        PageResult<HocVien> LayDSHocVien(Pagination pagination);
        PageResult<HocVien> TimKiemHocVien(Pagination pagination, string? name, string? email);
    }
}
