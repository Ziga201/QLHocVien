using API_QLHocVien.Entites;
using API_QLHocVien.Helper;
using API_QLHocVien.Payloads.Requests.TinhTrangHoc;
using API_QLHocVien.Payloads.Responses;

namespace API_QLHocVien.IServices
{
    public interface ITinhTrangHocServices
    {
        ResponseObject<TinhTrangHoc> ThemTinhTrangHoc(ThemTinhTrangHocRequest request);
        ResponseObject<TinhTrangHoc> SuaTinhTrangHoc(SuaTinhTrangHocRequest request);
        ResponseObject<TinhTrangHoc> XoaTinhTrangHoc(int id);
        List<TinhTrangHoc> LayDSTinhTrangHoc();
    }
}
