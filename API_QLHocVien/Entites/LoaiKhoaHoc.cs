namespace API_QLHocVien.Entites
{
    public class LoaiKhoaHoc
    {
        public int LoaiKhoaHocID { get; set; }
        public string TenLoai { get; set; }
        public List<KhoaHoc> KhoaHocs { get; set; }
    }
}
