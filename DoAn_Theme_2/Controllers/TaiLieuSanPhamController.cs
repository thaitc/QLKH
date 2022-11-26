using DoAn.Models;
using DoAn_Theme_2.Commom;
using DoAn_Theme_2.Models;
using DoAn_Theme_2.Shared.TaiLieuSanPham.Param;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;

namespace DoAn_Theme_2.Controllers
{
    public class TaiLieuSanPhamController : Controller
    {
        private readonly DoAnContext _db;
        public TaiLieuSanPhamController(DoAnContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UploadTaiLieu([FromForm]TaiLieuUploadParam param)
        {
            var listTaiLieu = new List<TaiLieuSanPham>();

            foreach (var item in param.files)
            {
                var path = Path.Combine(
                            Directory.GetCurrentDirectory(), "wwwroot",
                            "Uploads", item.FileName);

                FileHelper.UploadFile(item, path);

                var taiLieu = new TaiLieuSanPham();
                taiLieu.TenFile = item.FileName;
                taiLieu.DuongDan = $"Upload/{item.FileName}";
                taiLieu.IdSanPham = param.IdSanPham;

                listTaiLieu.Add(taiLieu);
            }

            _db.TaiLieuSanPhams.AddRange(listTaiLieu);
            _db.SaveChanges();
            return Json("Upload thành công");
        }
    }
}
