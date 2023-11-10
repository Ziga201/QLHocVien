namespace API_QLHocVien.Entites
{
    public class ChuDe
    {
        public int ChuDeID { get; set; }
        public string TenChuDe { get; set; }
        public string NoiDung { get; set; }
        public int LoaiBaiVietID { get; set; }
        public LoaiBaiViet LoaiBaiViet { get; set; }
        public List<BaiViet> BaiViets { get; set; }
    }
}
