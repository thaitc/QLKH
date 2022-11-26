using DoAn_Theme_2.Models;
using System.Collections.Generic;

namespace DoAn_Theme_2.Shared.HoaDons.Respon
{
    public class DonHangDetail
    {
        public int Id { get; set; }
        public int TongTien { get; set; }
        public string NgayTao { get; set; }
        public int SoSanPham { get; set; }
        public KhachHang KhachHangInfo { get; set; }
        public List<ChiTietDonHangDto> ChiTietDonHangs { get; set; } = new List<ChiTietDonHangDto>();
    }
}
