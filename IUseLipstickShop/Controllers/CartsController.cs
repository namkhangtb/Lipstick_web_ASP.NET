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
using Models.User;
using System.Web.Script.Serialization;
using IUseLipstickShop.Common;

namespace IUseLipstickShop.Controllers
{
    public class CartsController : Controller
    {       
        private LipstickDbContext db = new LipstickDbContext();

        // GET: Carts
        public ActionResult Index()
        {
            var name = User.Identity.Name;
            /*if (name == "")
            {
                return RedirectToAction("Index", "Carts");
            
            var result = new CartModels().GetCart(name);
        }*/
            var cart = Session[CommonConstants.CartSession];
            var list = new List<Cart>();
            if (cart != null)
            {
                list = (List<Cart>)cart;
            }
            return View(list);
        }
        public  ActionResult AddCart(int id, int colour, int size)
        {
            /*var findS = db.Sizes.Where(x => x.Id == size).FirstOrDefault();
            var findC = db.Colours.Where(x => x.Id == colour).FirstOrDefault();
            var find = db.Products.Find(id);
            var cart = Session[CommonConstants.CartSession];
            if (cart != null)
            {
                var list = (List<Cart>)cart;
                if (list.Exists(x => x.Id == id && x.Colour == findC.colour1 && x.Size == findS.C_size))
                {
                    foreach (var item in list)
                    {
                        if (item.Id == id && item.Colour == findC.colour1 && item.Size == findS.C_size)
                        {
                            item.Quanity += 1;
                            item.QuanityPice = item.Quanity * item.Price;
                        }
                    }
                }
                else
                {
                    var item = new Cart();
                    item.Images = find.Images;
                    item.Price = find.Price;
                    item.QuanityPice = find.Price;
                    item.Id = id;
                    item.Quanity = 1;
                    item.Colour = findC.colour1;
                    item.Size = findS.C_size;
                    list.Add(item);
                }
                Session[CommonConstants.CartSession] = list;
            }
            else
            {
                var item = new Cart();
                item.Images = find.Images;
                item.Price = find.Price;
                item.QuanityPice = find.Price;
                item.Id = id;
                item.Quanity = 1;
                item.Colour = findC.colour1;
                item.Size = findS.C_size;
                var list = new List<Cart>();
                list.Add(item);
                Session[CommonConstants.CartSession] = list;
            }*/

            return RedirectToAction("Index");
            /*var cart = Session[CartSession];
            var name = User.Identity.Name;
            var result = new CartModels().AddCart(id, colour, size, name);
            if (result == 0)
            {
                return HttpNotFound();
            }
            return RedirectToAction("Index", "Carts");*/
        }
        [HttpPost]
        
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cart cart = await db.Carts.FindAsync(id);
            if (cart == null)
            {
                return HttpNotFound();
            }
            return View(cart);
        }

        // POST: Carts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Cart cart = await db.Carts.FindAsync(id);
            db.Carts.Remove(cart);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public JsonResult ChangePrice(string cartModel,string storage)
        {
            var jsoncart = new JavaScriptSerializer().Deserialize<List<Cart>>(cartModel);
            var jsoncart2 = new JavaScriptSerializer().Deserialize<List<Cart>>(storage);
            decimal total = 0;
            /*var sessionCart = (List<Cart>)Session[CommonConstants.CartSession];
            
            foreach (var item in sessionCart)
            {
                var jsonitem = jsoncart.SingleOrDefault(x => x.Id == item.Id && x.Colour == item.Colour && x.Size == item.Size);
                if (jsonitem != null)
                {
                    item.Quanity = jsonitem.Quanity;
                    total = (decimal)item.Price;
                    item.QuanityPice = jsonitem.Quanity * item.Price;
                }
            }
            Session[CommonConstants.CartSession] = sessionCart;*/

            return Json(new{
                Price = total
            });
        }
        public JsonResult Checkout(string cartUser)
        {
            /*var result = new CartModels().Checkout(cartUser);*/
            var jsoncart = new JavaScriptSerializer().Deserialize<List<Cart>>(cartUser);
            decimal result = 0;
            foreach (var item in jsoncart)
            {
                result = result + (decimal)item.QuanityPice;
            }
            return Json(new { totalCheck = result });
        }

        public JsonResult Remove(int id,string size, string colour)
        {
            var sessionCart = (List<Cart>)Session[CommonConstants.CartSession];
            /*var finds = db.Sizes.Where(x => x.Id==size).FirstOrDefault();
            var findc = db.Colours.Where(x => x.Id==colour).FirstOrDefault();*/
            sessionCart.RemoveAll(x => x.Id == id && x.Colour == colour && x.Size == size);
            Session[CommonConstants.CartSession] = sessionCart;
            return Json(
                new { 
                    status = true 
                }
            );
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
