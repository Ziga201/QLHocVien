using API_QLHocVien.Entites;
using API_QLHocVien.Helper;
using API_QLHocVien.Payloads.DTOs;
using API_QLHocVien.Payloads.Requests.TaiKhoan;
using API_QLHocVien.Payloads.Responses;

namespace API_QLHocVien.IServices
{
    public interface ITaiKhoanServices
    {
        ResponseObject<TaiKhoanDTO> ThemTaiKhoan(ThemTaiKhoanRequest request);
        ResponseObject<TaiKhoanDTO> SuaTaiKhoan(SuaTaiKhoanRequest request);
        ResponseObject<TaiKhoanDTO> XoaTaiKhoan(int id);
        PageResult<TaiKhoan> LayDSTaiKhoan(Pagination pagination);
        PageResult<TaiKhoan> TimKiemTaiKhoan(Pagination pagination, string? key);

    }
}
