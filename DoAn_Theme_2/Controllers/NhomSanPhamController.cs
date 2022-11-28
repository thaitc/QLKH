using DoAn.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace DoAn_Theme_2.Controllers
{
    public class NhomSanPhamController : Controller
    {
        private readonly DoAnContext _db;
        public NhomSanPhamController(DoAnContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var result = _db.NhomHangs.ToList();
            return Json(result);
        }

        [HttpPost]
        public IActionResult Create([FromBody] NhomHang param)
        {
            _db.NhomHangs.Add(param);
            _db.SaveChanges();
            return Json(param.Id);
        }

        public IActionResult GetDetail(int IdNhomSp)
        {
            var result = new NhomHang();
            result = _db.NhomHangs.Find(IdNhomSp);
            return Json(result);
        }

        [HttpPost]
        public IActionResult Update([FromBody]NhomHang param)
        {
            var sanPham = _db.NhomHangs.Find(param.Id);
            if (sanPham != null)
            {
                sanPham.Ten = param.Ten;
                _db.SaveChanges();
            }
           
            return Json(param);
        }

        public IActionResult Delete(int IdNhomSp)
        {
            var sanPham = _db.NhomHangs.Find(IdNhomSp);
            if (sanPham != null)
            {
                _db.NhomHangs.Remove(sanPham);
                _db.SaveChanges();
            }

            return Json(IdNhomSp);
        }
    }
}
