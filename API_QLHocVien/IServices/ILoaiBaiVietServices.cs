using API_QLHocVien.Entites;
using API_QLHocVien.Helper;
using API_QLHocVien.Payloads.Requests.LoaiBaiViet;
using API_QLHocVien.Payloads.Responses;

namespace API_QLHocVien.IServices
{
    public interface ILoaiBaiVietServices
    {
        ResponseObject<LoaiBaiViet> ThemLoaiBaiViet(ThemLoaiBaiVietRequest request);
        ResponseObject<LoaiBaiViet> SuaLoaiBaiViet(SuaLoaiBaiVietRequest request);
        ResponseObject<LoaiBaiViet> XoaLoaiBaiViet(int idBaiViet);
        PageResult<LoaiBaiViet> LayDSLoaiBaiViet(Pagination pagination);
    }
}
