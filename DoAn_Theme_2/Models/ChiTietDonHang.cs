using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoAn_Theme_2.Models
{
    public class ChiTietDonHang
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int IdDonHang { get; set; }
        public int IdSanPham { get; set; }
        public int SoLuong { get; set; }
        public int DonGia { get; set; }
        public int TrietKhau { get; set; }
        /// <summary>
        /// 1: %
        /// 2: số tiền cố định
        /// </summary>
        public int IdDonViTrietKhau { get; set; }
        public int ThanhTien { get; set; }
    }
}
