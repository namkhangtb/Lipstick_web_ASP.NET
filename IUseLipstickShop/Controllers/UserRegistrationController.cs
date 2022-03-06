using IUseLipstickShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.User;
using Models.UserRegistration;
using Models.Framework;

namespace IUseLipstickShop.Controllers
{
    public class UserRegistrationController : Controller
    {
        // GET: UserRegistration
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(UserRegistrationModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserRegisterDao();
                if (dao.CheckUserName(model.UserName))
                {
                    ModelState.AddModelError("", "Tên đăng nhập đã tồn tại");
                }
                else
                {
                    var user = new AppUser();
                    user.UserName = model.UserName;
                    user.PassWord = model.PassWord;
                    user.Phone = model.Phone;
                    user.FirstName = model.FirstName;
                    user.LastName = model.LastName;
                    user.UserRole = "user";
                    user.CartID = user.Id;
                    var result = dao.Insert(user);
                    if (result > 0)
                    {
                        ViewBag.Success = "Đăng ký thành công";
                        model = new UserRegistrationModel();
                        return RedirectToAction("Index", "UserLogin");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Đăng ký không thành công");
                    }
                }
            }
            return RedirectToAction("Register", "UserRegistration");
        }
    }
}