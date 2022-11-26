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
    }
}
