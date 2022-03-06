using Models.Framework;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace IUseLipstickShop.Controllers
{
    public class OrderController : Controller
    {
        private LipstickDbContext db = new LipstickDbContext();
        // GET: Order
        public ActionResult Index()
        {
            return View();
        }
        private void makeDetail(string cartUser, string orderID)
        {
            var jsoncart = new JavaScriptSerializer().Deserialize<List<Cart>>(cartUser);
            var findOrder = db.Orders.Where(x => x.OrderID == orderID).FirstOrDefault();
            var date = DateTime.UtcNow;
            int i = 0;
            foreach (var item in jsoncart)
            {
                i = i + 1;
                var orderDetail = new OrderDetail()
                {
                    ID =date.ToString()+i,
                    OrderID = findOrder.OrderID,
                    Name = item.Name,
                    Images = "",
                    Price = item.Price,
                    Size = item.Size,
                    Colour = item.Colour,
                };
                db.OrderDetails.Add(orderDetail);
                try
                {
                    db.SaveChanges();
                }
                catch (DbEntityValidationException e)
                {
                    Console.WriteLine(e);
                }
            }
        }
        public JsonResult MakeOrder(string cartUser, string addRess,int phone)
        {
            var jsoncart = new JavaScriptSerializer().Deserialize<List<Cart>>(cartUser);
            decimal tong = 0;
            foreach (var item in jsoncart)
            {
                tong = tong + (decimal)item.QuanityPice;
            }
            var date =  DateTime.UtcNow;
            var order = new Order()
            {
                OrderID= addRess + date.ToString()+phone+tong,
                Price = tong,
                Phone = phone,
                Address = addRess + date.ToString(),
            };
            db.Orders.Add(order);
            db.SaveChanges();
            makeDetail(cartUser,order.OrderID);
            return Json(new { status = true });
        }
    }
}