using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IUseLipstickShop.Models
{
    public class ContactModel
    {
        [Display(Name = "Tên")]
        [Required(ErrorMessage = "Yêu cầu nhập tên")]
        public string Name { get; set; }

        [Display(Name = "Gmail")]
        [Required(ErrorMessage = "Yêu cầu nhập gmail")]
        public string Gmail { get; set; }

        [Display(Name = "Message")]
        [Required(ErrorMessage = "Yêu cầu nhập tin nhắn")]
        public string Message { get; set; }
    }
}