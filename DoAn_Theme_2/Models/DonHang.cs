using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoAn_Theme_2.Models
{
    public class DonHang
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Ma { get; set; }
        public DateTime NgayTao { get; set; } = DateTime.Now;
        public int IdKhachHang { get; set; }
        public int SoLuongSanPham { get; set; }
        public int TongSoLuongSanPham { get; set; }
        public string GhiChu { get; set; }
        public double TongTien { get; set; }
        public DateTime NgaySuaCuoi { get; set; } = DateTime.Now;

    }
}
