using DoAn.Models;
using DoAn_Theme_2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace DoAn_Theme_2.Controllers
{
    public class ThuocTinhSanPhamController : Controller
    {
        private readonly DoAnContext _db;
        public ThuocTinhSanPhamController(DoAnContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var result = _db.ThuocTinhSanPhams.ToList();
            return Json(result);
        }

        [HttpPost]
        public IActionResult Create([FromBody]ThuocTinhSanPham param)
        {
            _db.ThuocTinhSanPhams.Add(param);
            _db.SaveChanges();
            return Json(param.Id);
        }
    }
}
