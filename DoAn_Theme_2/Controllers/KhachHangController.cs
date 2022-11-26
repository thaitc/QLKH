using DoAn.Models;
using DoAn_Theme_2.Models;
using DoAn_Theme_2.Shared.KhachHangs.Param;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace DoAn_Theme_2.Controllers
{
    public class KhachHangController : Controller
    {
        private readonly DoAnContext _db;
        public KhachHangController(DoAnContext db)
        {
            _db = db;
        }

        [HttpPost]
        public IActionResult Index([FromBody]FilterCustomerParam param)
        {
            var result = _db.KhachHangs.ToList();
            if (!string.IsNullOrWhiteSpace(param.Ten))
                result = result.Where(x => x.Ten.ToLower().Contains(param.Ten.ToLower())).ToList();

            if (!string.IsNullOrWhiteSpace(param.SoDienThoai))
            {
                result = result
                    .Where(x => !string.IsNullOrWhiteSpace(x.SoDienThoai) 
                     && x.SoDienThoai.Contains(x.SoDienThoai))
                    .ToList();
            }

            if (!string.IsNullOrWhiteSpace(param.Email))
            {
                result = result
                    .Where(x => !string.IsNullOrWhiteSpace(x.Email)
                     && x.Email.ToLower().Contains(x.Email.ToLower()))
                    .ToList();
            }

            return Json(result);
        }

        [HttpPost]
        public IActionResult Create([FromBody]KhachHang param)
        {
            _db.KhachHangs.Add(param);
            _db.SaveChanges();
            return Json(param.Id);
        }

        public IActionResult GetByCode(string maKhachHang)
        {
            var customer = _db.KhachHangs.FirstOrDefault(x => x.Ma == maKhachHang);
            return Json(customer);
        }
    }
}
