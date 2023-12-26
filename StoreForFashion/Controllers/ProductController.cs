using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StoreForFashion.Models;

namespace StoreForFashion.Controllers
{
    public class ProductController : Controller
    {
        private StoreForFashionDB db = new StoreForFashionDB();

        public ActionResult ProductDetail(int id)
        {
            SanPham sp = db.SanPhams.Include("DanhMuc").Where(s => s.MaSP.Equals(id)).FirstOrDefault();
            List<SanPhamChiTiet> list = db.SanPhamChiTiets.Include("KichCo").Where(s => s.MaSP.Equals(id)).ToList();
            ViewBag.SPCT = list;
            ViewBag.Exitst = list[0];
            return View(sp);
        }
    }
}
