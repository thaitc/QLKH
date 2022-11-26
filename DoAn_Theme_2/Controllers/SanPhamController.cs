using DoAn.Models;
using DoAn_Theme_2.Commom;
using DoAn_Theme_2.Models;
using DoAn_Theme_2.Shared.SanPhams.Param;
using DoAn_Theme_2.Shared.SanPhams.Respon;
using DoAn_Theme_2.Shared.ThuocTinhSanPhams.Respon;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DoAn.Controllers
{
    public class SanPhamController : Controller
    {
        private readonly DoAnContext _db;
        public SanPhamController(DoAnContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var listProduct = _db.SanPhams.ToList();

            return Json(listProduct);
        }

        [HttpPost]
        public IActionResult Create([FromBody] SanPhamAddParam param)
        {
            _db.SanPhams.Add(param.sanPham);
            _db.SaveChanges();

            foreach (var item in param.thuocTinhs)
                item.IdSanPham = param.sanPham.Id;

            _db.ThuocTinhOfSanPhams.AddRange(param.thuocTinhs);
            _db.SaveChanges();

            return Json(param.sanPham.Id);
        }

        public IActionResult GetSanPhamDropList()
        {
            var reuslt = (from sp in _db.SanPhams
                              //join tl in _db.TaiLieuSanPhams
                              //on sp.Id equals tl.IdSanPham
                              //into tls
                              //from gj in tls.DefaultIfEmpty()
                          let p = _db.TaiLieuSanPhams.FirstOrDefault(p2 => sp.Id == p2.IdSanPham)
                          select new SanPhamDropRespon
                          {
                              Id = sp.Id,
                              GiaBan = Convert.ToInt32(sp.GiaBan),
                              Path = p == null ? "" : p.DuongDan,
                              Ten = sp.Ten
                          }).ToList();

            return Json(reuslt);
        }

        public IActionResult GetDetail(int SanPhamId)
        {
            var result = new SanPhamDetail();

            var sanPham = _db.SanPhams.Find(SanPhamId);

            if (sanPham != null)
            {
                result.Id = sanPham.Id;
                result.Ten = sanPham.Ten;
                result.GiaBan = sanPham.GiaBan;
                result.GiaVon = sanPham.GiaVon;
                result.GhiChu = sanPham.GhiChu;
                result.Ma = sanPham.Ma;
                result.TonKho = sanPham.TonKho;

                var nhomHang = _db.NhomHangs.Find(sanPham.IdNhomHang);
                if (nhomHang != null)
                {
                    result.TenNhomHang = nhomHang.Ten;
                }

                result.ListThuocTinh = (from sptt in _db.ThuocTinhSanPhams
                                       join tt in _db.ThuocTinhOfSanPhams
                                       on sptt.Id equals tt.IdThuocTinh
                                       where tt.IdSanPham == SanPhamId
                                       select new ThuocTinhSanPhamDto
                                       {
                                           TenThuocTinh = sptt.Ten,
                                           GiaTri = tt.GiaTri,
                                           Id = tt.Id
                                       })
                                       .ToList();

                result.ListImg = _db.TaiLieuSanPhams.Where(x => x.IdSanPham == SanPhamId).Select(X => X.DuongDan).ToList();
            }

            return Json(result);
        }
    }
}
