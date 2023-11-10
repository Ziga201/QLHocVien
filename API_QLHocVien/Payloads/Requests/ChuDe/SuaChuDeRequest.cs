namespace API_QLHocVien.Payloads.Requests.ChuDe
{
    public class SuaChuDeRequest
    {
        public int ChuDeID { get; set; }
        public string TenChuDe { get; set; }
        public string NoiDung { get; set; }
        public int LoaiBaiVietID { get; set; }
    }
}
