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
using Models.Admin;
using PagedList;
using PagedList.Mvc;
namespace LipstickShop.Controllers
{
    public class CategoriesController : Controller
    {
        private LipstickDbContext db = new LipstickDbContext();

        // GET: Categories
        public async Task<ActionResult> Index(int? page)
        {
            if (page == null) page = 1;
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            var result = await new CategoryModel().Index();
            return View(result.ToPagedList(pageNumber,pageSize));
        }

        // GET: Categories/Details/5
        public async Task<ActionResult> Details(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var result = await new CategoryModel().Details(id);
            if (result.Id == 0)
            {
                return HttpNotFound();
            }
            return View(result);
        }

        // GET: Categories/Create
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Category request)
        {
            if (ModelState.IsValid)
            {
                var result = await new CategoryModel().Create(request);
                if (result > 0)
                {
                    return RedirectToAction("Index");
                }
            }

            return View();
        }

        // GET: Categories/Edit/5
        [HttpGet]
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var category = await new CategoryModel().GetEdit(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Category request)
        {
            if (ModelState.IsValid)
            {
                var result = await new CategoryModel().Update(request);
                if (result == 1)
                {
                    return RedirectToAction("Index");
                }
            }
            return View();
        }

        // GET: Categories/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = await db.Categories.FindAsync(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Category category = await db.Categories.FindAsync(id);
            db.Categories.Remove(category);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
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
