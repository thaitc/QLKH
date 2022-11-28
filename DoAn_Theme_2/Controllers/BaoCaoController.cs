using DoAn.Models;
using DoAn_Theme_2.Shared.BaoCaos.Param;
using DoAn_Theme_2.Shared.BaoCaos.Respon;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace DoAn_Theme_2.Controllers
{
    public class BaoCaoController : Controller
    {
        private readonly DoAnContext _db;
        public BaoCaoController(DoAnContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult BaoCaoDoanhThu(BaoCaoDoanhThuParam param)
        {
            var result = new BaoCaoDoanhThuRespon();

            if (param.DonVi == Shared.BaoCaos.Enums.BaoCaoDoanhThuEnum.Ngay)
            {
                result.DoanhThu = _db.DonHangs
                    .Where(x => x.NgayTao.Date == System.DateTime.Now.Date)
                    .Sum(x => x.TongTien);
            }

            if (param.DonVi == Shared.BaoCaos.Enums.BaoCaoDoanhThuEnum.Thang)
            {
                result.DoanhThu = _db.DonHangs
                    .Where(x => x.NgayTao.Month == System.DateTime.Now.Month)
                    .Sum(x => x.TongTien);
            }

            if (param.DonVi == Shared.BaoCaos.Enums.BaoCaoDoanhThuEnum.Nam)
            {
                result.DoanhThu = _db.DonHangs
                    .Where(x => x.NgayTao.Year == System.DateTime.Now.Year)
                    .Sum(x => x.TongTien);
            }

            return Json(result);
        }
    }
}
