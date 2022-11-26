using DoAn.Models;
using DoAn_Theme_2.Models;
using DoAn_Theme_2.Shared.ThuocTinhSanPhams.Respon;
using System.Collections.Generic;

namespace DoAn_Theme_2.Shared.SanPhams.Respon
{
    public class SanPhamDetail : SanPham
    {
        public string TenNhomHang { get; set; }
        public List<string> ListImg { get; set; }
        public List<ThuocTinhSanPhamDto> ListThuocTinh { get; set; }
    }
}
