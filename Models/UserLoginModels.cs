using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class UserLoginModels
    {
        private LipstickDbContext _context = null;
        public UserLoginModels()
        {
            _context = new LipstickDbContext();
        }
        public bool Login(string userName, string passWord)
        {
            /*var user = context.Database.ExecuteSqlCommand("select COUNT(*) from AppUser where UserName = @UserName and PassWord = @PassWord", sqlParams);*/
            var user = _context.AppUsers.Where(u => u.UserName == userName && u.PassWord == passWord && u.UserRole == "user").Count();
            if (user == 0)
            {
                return false;
            }
            return true;
        }
    }
}
