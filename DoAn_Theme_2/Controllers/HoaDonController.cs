using DoAn.Models;
using DoAn_Theme_2.Models;
using DoAn_Theme_2.Shared.HoaDons.Param;
using DoAn_Theme_2.Shared.HoaDons.Respon;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace DoAn_Theme_2.Controllers
{
    public class HoaDonController : Controller
    {
        private readonly DoAnContext _db;
        public HoaDonController(DoAnContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var resutl = (from bill in _db.DonHangs
                          join kh in _db.KhachHangs
                          on bill.IdKhachHang equals kh.Id
                          select new DonHangListRespon
                          {
                              Id = bill.Id,
                              NgayTao = bill.NgayTao.ToString("dd/MM/yyyy"),
                              TenKhachHang = kh.Ten,
                              SoSanPham = bill.SoLuongSanPham,
                              TongTien = Convert.ToInt32(bill.TongTien)
                          })
                          .ToList();

            return Json(resutl);
        }
        [HttpPost]
        public IActionResult Create([FromBody] HoaDonAddParam param)
        {
            var donHang = new DonHang();
            donHang.TongTien = param.ChiTietDonHangs.Sum(x => x.ThanhTien);
            donHang.SoLuongSanPham = param.ChiTietDonHangs.Count;
            donHang.IdKhachHang = param.IdKhachHang;
            //donHang.GhiChu = param.GhiChu;
            //donHang.Ma = param.Ma;

            _db.DonHangs.Add(donHang);
            _db.SaveChanges();

            foreach (var item in param.ChiTietDonHangs)
            {
                item.IdDonHang = donHang.Id;
                var sanPham = _db.SanPhams.Find(item.IdSanPham);
                if (sanPham != null)
                {
                    sanPham.TonKho -= item.SoLuong;
                }
            }    
                
            _db.ChiTietDonHangs.AddRange(param.ChiTietDonHangs);
            _db.SaveChanges();

            return Json(donHang.Id);
        }


        public IActionResult GetDetail(int IdHoaDon)
        {
            var result = new DonHangDetail();

            var hoaDon = _db.DonHangs.Find(IdHoaDon);
            if (hoaDon == null)
                return Json(null);

            result.NgayTao = hoaDon.NgayTao.ToString("dd/MM/yyyy");
            result.TongTien = (int)hoaDon.TongTien;
            result.KhachHangInfo = _db.KhachHangs.Find(hoaDon.IdKhachHang);
            var chitTietDonHangs = _db.ChiTietDonHangs.Where(x => x.IdDonHang == IdHoaDon).ToList();

            foreach (var item in chitTietDonHangs)
            {
                var chiTietDhObj = new ChiTietDonHangDto();
                chiTietDhObj.ThanhTien = item.ThanhTien;
                chiTietDhObj.TrietKhau = item.TrietKhau;
                chiTietDhObj.IdDonViTrietKhau = item.IdDonViTrietKhau;
                chiTietDhObj.SoLuong = item.SoLuong;
                chiTietDhObj.DonGia = item.DonGia;

                var sanPham = _db.SanPhams.Find(item.IdSanPham);
                if (sanPham != null)
                {
                    chiTietDhObj.TenSanPham = sanPham.Ten;
                }

                var anhSp = _db.TaiLieuSanPhams.FirstOrDefault(x => x.IdSanPham == item.IdSanPham);
                if (anhSp != null)
                {
                    chiTietDhObj.AnhSanPham = anhSp.DuongDan;
                }

                result.ChiTietDonHangs.Add(chiTietDhObj);
            }

            return Json(result);
        }
    }
}
