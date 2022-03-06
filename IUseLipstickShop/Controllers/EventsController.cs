using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Models.Framework;
using PagedList;
using PagedList.Mvc;
using Models;
using Models.User;

namespace IUseLipstickShop.Controllers
{
    public class EventsController : Controller
    {
        private LipstickDbContext db = new LipstickDbContext();

        // GET: Events
        public async Task<ActionResult> Index(int? page)
        {
            if (page == null) page = 1;
            int pageSize = 12;
            int pageNumber = (page ?? 1);
            
            var result = await db.Products.ToListAsync();
            return View((result.ToPagedList(pageNumber, pageSize)));
        }

        // GET: Events/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            SetViewBag();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = await db.Products.FindAsync(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }
        public void SetViewBag(int? selectedId = null)
        {
            
            var dao = new EventsModels(); 
            ViewBag.Colour = new SelectList(dao.ListAll(),"Id","colour1", selectedId);
            ViewBag.Size = new SelectList(dao.ListAllSize(), "Id", "C_size", selectedId);
        }
        
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }


    }
}
