using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoAn_Theme_2.Models
{
    public class ThuocTinhOfSanPham
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int IdThuocTinh { get; set; }
        public int IdSanPham { get; set; }
        public string GiaTri { get; set; }
    }
}
