namespace API_QLHocVien.Entites
{
    public class QuyenHan
    {
        public int QuyenHanID { get; set; }
        public string TenQuyenHan { get; set; }
        public List<TaiKhoan> TaiKhoans { get; set; }
    }
}
