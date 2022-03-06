using IUseLipstickShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace IUseLipstickShop.Controllers
{
    public class UserLoginController : Controller
    {
        // GET: UserLogin       
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(UserLoginModel model)
        {
            if (Membership.ValidateUser(model.UserName, model.PassWord) && ModelState.IsValid)
            {
                FormsAuthentication.SetAuthCookie(model.UserName, model.Remember);
                
                HttpContext.User.Identity.Name.Contains(model.UserName);
                return RedirectToAction("Index", "Events");
            }
            else
            {
                ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu không đúng");
            }
            return View(model);
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "UserLogin");
        }
    }
}