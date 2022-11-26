using DoAn.Models;
using DoAn_Theme_2.Models;
using DoAn_Theme_2.Shared.DonVi.Enum;
using DoAn_Theme_2.Shared.DonVi.Respon;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace DoAn_Theme_2.Controllers
{
    public class DonViController : Controller
    {
        private readonly DoAnContext _db;
        public DonViController(DoAnContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var result = new List<DonViListRespon>();
            var listDB = _db.DonVis.ToList();

            foreach (var item in listDB)
            {
                var obj = new DonViListRespon();
                obj.Id = item.Id;
                obj.Ten = item.Ten;
                if (item.LoaiDonVi == LoaiDonViEnum.SanPham)
                    obj.LoaiDonVi = "Sản phẩm";

                if (item.LoaiDonVi == LoaiDonViEnum.TrietKhau)
                    obj.LoaiDonVi = "Triết khấu";

                if (item.LoaiDonVi == LoaiDonViEnum.Tien)
                    obj.LoaiDonVi = "Tiền tệ";

                result.Add(obj);
            }

            return Json(result);
        }

        [HttpPost]
        public IActionResult Create([FromBody]DonVi param)
        {
            _db.DonVis.Add(param);
            _db.SaveChanges();
            return Json(param.Id);
        }
    }
}
