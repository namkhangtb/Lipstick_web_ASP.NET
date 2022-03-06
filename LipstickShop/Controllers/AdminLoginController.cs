using LipstickShop.Code;
using LipstickShop.Models;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace LipstickShop.Controllers
{
    public class AdminLoginController : Controller
    {
        // GET: AdminLogin
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(AdminLoginModel model )
        {
            if (Membership.ValidateUser(model.UserName,model.PassWord)&& ModelState.IsValid)
            {
                FormsAuthentication.SetAuthCookie(model.UserName, model.Remember);
                HttpContext.User.Identity.Name.Contains(model.UserName);
                return RedirectToAction("Index", "Home",new { UserName = model.UserName});
            }
            else
            {
                ModelState.AddModelError("", "ten dang nhap hoac mat khau ko dung");
            }
            return View(model);
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "AdminLogin");
        }
    }
}