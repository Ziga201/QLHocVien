using API_QLHocVien.Entites;
using API_QLHocVien.Helper;
using API_QLHocVien.Payloads.DTOs;
using API_QLHocVien.Payloads.Requests.BaiViet;
using API_QLHocVien.Payloads.Responses;

namespace API_QLHocVien.IServices
{
    public interface IBaiVietServices
    {
        Task<ResponseObject<BaiVietDTO>> ThemBaiViet(ThemBaiVietRequest request);
        Task<ResponseObject<BaiVietDTO>> SuaBaiViet(SuaBaiVietRequest request);
        ResponseObject<BaiVietDTO> XoaBaiViet(int id);
        PageResult<BaiViet> LayDSBaiViet(Pagination pagination);
        PageResult<BaiViet> TimKiemBaiViet(Pagination pagination, string? key);
    }
}
