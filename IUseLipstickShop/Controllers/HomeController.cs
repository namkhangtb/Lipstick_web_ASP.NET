using Models.Framework;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IUseLipstickShop.Controllers
{
    public class HomeController : Controller
    {
        private LipstickDbContext db = new LipstickDbContext();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ProductsJK(int? page)
        {
            if (page == null) page = 1;
            int pageSize = 4;
            int pageNumber = (page ?? 1);

            var lst = db.Products.Where(x => x.Alias == "ao-khoac").ToList();
            return PartialView((lst.ToPagedList(pageNumber, pageSize)));
        }

        public ActionResult ProductsHD(int? page)
        {
            if (page == null) page = 1;
            int pageSize = 4;
            int pageNumber = (page ?? 1);

            var lst = db.Products.Where(x => x.Alias == "hoodie").ToList();
            return PartialView((lst.ToPagedList(pageNumber, pageSize)));
        }
        public ActionResult ProductsJ(int? page)
        {
            if (page == null) page = 1;
            int pageSize = 4;
            int pageNumber = (page ?? 1);

            var lst = db.Products.Where(x => x.Alias == "jean").ToList();
            return PartialView((lst.ToPagedList(pageNumber, pageSize)));
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        [ChildActionOnly]
        public ActionResult RenderMenu(int? id)
        {
            var result = db.Categories.ToList();
            return PartialView("MenuBar");
        }
        public ActionResult Search(string TenSP)
        {
            if (TenSP == null)
            {
                return RedirectToAction("Index", "Home");
            }
            var lst = db.Products.Where(x => x.Name.Contains(TenSP)).ToList();
            return View(lst);
        }

    }
}