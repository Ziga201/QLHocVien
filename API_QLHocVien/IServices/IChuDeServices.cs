using API_QLHocVien.Entites;
using API_QLHocVien.Helper;
using API_QLHocVien.Payloads.DTOs;
using API_QLHocVien.Payloads.Requests.ChuDe;
using API_QLHocVien.Payloads.Responses;

namespace API_QLHocVien.IServices
{
    public interface IChuDeServices
    {
        ResponseObject<ChuDeDTO> ThemChuDe(ThemChuDeRequest request);
        ResponseObject<ChuDeDTO> SuaChuDe(SuaChuDeRequest request);
        ResponseObject<ChuDeDTO> XoaChuDe(int id);
        PageResult<ChuDe> LayDSChuDe(Pagination pagination);
    }
}
