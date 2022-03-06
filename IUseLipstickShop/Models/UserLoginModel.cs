using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IUseLipstickShop.Models
{
    public class UserLoginModel
    {
        [Required]
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public bool Remember { get; set; }
    }
}