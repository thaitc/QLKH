using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoAn.Models
{
    public class SanPham
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Ma { get; set; }
        public string Ten { get; set; }
        public string MaVach { get; set; }
        public double GiaBan { get; set; }
        public double GiaVon { get; set; }
        public int TonKho { get; set; }
        public string MoTa { get; set; }
        public string GhiChu { get; set; }
        public string ThanhPhan { get; set; }
        public int IdNhomHang { get; set; }
        public int IdThuongHieu { get; set; }
        public int IdDonVi { get; set; }
    }
}
