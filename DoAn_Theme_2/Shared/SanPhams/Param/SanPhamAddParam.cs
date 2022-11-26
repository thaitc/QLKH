using DoAn.Models;
using DoAn_Theme_2.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace DoAn_Theme_2.Shared.SanPhams.Param
{
    public class SanPhamAddParam
    {
        public SanPham sanPham { get; set; }
        public List<ThuocTinhOfSanPham> thuocTinhs { get; set; }
    }
}
