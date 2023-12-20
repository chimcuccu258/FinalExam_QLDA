using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StoreForFashion.Areas.Admin.Data;
using StoreForFashion.Session;
using StoreForFashion.Models;

namespace StoreForFashion.Controllers
{
    public class HomeController : Controller
    {
        StoreForFashionDB db = new StoreForFashionDB();
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.SanPhamMoi = db.SanPhams.Select(p => p).OrderByDescending(p => p.NgayTao).Take(5);
            ViewBag.GiaTot = db.SanPhams.Select(p => p).OrderBy(p => p.Gia).Take(5);
            return View();
        }

        [ChildActionOnly]
        public ActionResult SearchBox()
        {
            IEnumerable<DanhMuc> danhmucs = db.DanhMucs.Select(p => p);
            return PartialView(danhmucs);
        }

        [ChildActionOnly]
        public ActionResult DropdownCategories()
        {
            IEnumerable<DanhMuc> danhmucs = db.DanhMucs.Select(p => p);
            return PartialView(danhmucs);
        }

        [ChildActionOnly]
        public ActionResult SelectOptionSize()
        {
            IEnumerable<KichCo> kichCos = db.KichCoes.Select(p => p);
            return PartialView(kichCos);
        }

        [ChildActionOnly]
        public ActionResult CartCount()
        {
            List<ChiTietHoaDon> list = new List<ChiTietHoaDon>();
            list = (List<ChiTietHoaDon>)Session[StoreForFashion.Session.ConstainCart.CART];
            return PartialView(list);
        }

    }
}