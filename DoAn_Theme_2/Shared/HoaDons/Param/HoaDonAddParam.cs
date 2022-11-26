using DoAn_Theme_2.Models;
using System.Collections.Generic;

namespace DoAn_Theme_2.Shared.HoaDons.Param
{
    public class HoaDonAddParam
    {
        public int IdKhachHang { get; set; }
        //public string Ma { get; set; }
        //public string GhiChu { get; set; }
        //public int TongTien { get; set; }
        public List<ChiTietDonHang> ChiTietDonHangs { get; set; }
    }
}
