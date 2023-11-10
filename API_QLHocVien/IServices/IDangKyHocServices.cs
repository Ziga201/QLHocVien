using API_QLHocVien.Entites;
using API_QLHocVien.Helper;
using API_QLHocVien.Payloads.DTOs;
using API_QLHocVien.Payloads.Requests.DangKyHoc;
using API_QLHocVien.Payloads.Responses;

namespace API_QLHocVien.IServices
{
    public interface IDangKyHocServices
    {
        ResponseObject<DangKyHocDTO> ThemDangKyHoc(ThemDangKyHocRequest request);
        ResponseObject<DangKyHocDTO> SuaDangKyHoc(SuaDangKyHocRequest request);
        ResponseObject<DangKyHocDTO> XoaDangKyHoc(int id);
        PageResult<DangKyHoc> LayDSDangKyHoc(Pagination pagination);
        ResponseObject<DangKyHocDTO> CapNhatTrangThaiHoc(int idDangKyHoc, int tinhTrangHocId);
        public void CapNhatTrangThaiHocXong();
    }
}
