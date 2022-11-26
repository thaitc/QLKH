using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace DoAn_Theme_2.Shared.TaiLieuSanPham.Param
{
    public class TaiLieuUploadParam
    {
        public List<IFormFile> files { get; set; }
        public int IdSanPham { get; set; }
    }
}
