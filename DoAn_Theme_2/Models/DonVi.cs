using DoAn_Theme_2.Shared.DonVi.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoAn_Theme_2.Models
{
    public class DonVi
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Ten { get; set; }
        public LoaiDonViEnum LoaiDonVi { get; set; }

    }
}
