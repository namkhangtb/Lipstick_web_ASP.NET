using IUseLipstickShop.Models;
using Models.Framework;
using Models.UserContact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IUseLipstickShop.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        [HttpGet]
        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Contact(ContactModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserContactDao();
                if (dao.CheckUserName(model.Gmail))
                {
                    ModelState.AddModelError("", "Gmail đã tồn tại");
                }
                else
                {
                    var user = new Contact();
                    user.Name = model.Name;
                    user.Gmail = model.Gmail;
                    user.Message = model.Message;
 
                    var result = dao.InsertContact(user);
                    if (result != null)
                    {
                        ViewBag.Success = "Gửi thành công";
                        model = new ContactModel();
                    }
                    else
                    {
                        ModelState.AddModelError("", "Gửi không thành công");
                    }
                }
            }
            return RedirectToAction("Contact", "Contact");
        }
    }
}