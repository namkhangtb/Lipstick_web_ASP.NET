using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace IUseLipstickShop.Models
{
    public class UserRegistrationModel
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Tên đăng nhập")]
        [Required(ErrorMessage = "Yêu cầu nhập tên đăng nhập")]
        public string UserName { get; set; }
        [Display(Name = "Mật khẩu")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Độ dài mật khẩu ít nhất 3 kí tự")]
        [Required(ErrorMessage = "Yêu cầu nhập mật khẩu")]
        public string PassWord { get; set; }
        [Display(Name = "Xác nhận mật khẩu")]
        [Compare("PassWord", ErrorMessage = "Xác nhận mật khẩu không đúng")]
        public string ConfirmPassWord { get; set; }
        [Display(Name = "Số điện thoại")]
        [Required(ErrorMessage = "Yêu cầu nhập số điện thoại")]
        public int Phone { get; set; }
        [Display(Name = "Họ")]
        public string FirstName { get; set; }
        [Display(Name = "Tên")]
        [Required(ErrorMessage = "Yêu cầu nhập tên")]
        public string LastName { get; set; }
    }
}