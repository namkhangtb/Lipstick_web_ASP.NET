using Models.Framework;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class AccountModels
    {
        private LipstickDbContext _context =null;
        public AccountModels()
        {
            _context = new LipstickDbContext();
        }
        public bool Login(string userName, string passWord)
        {
            

            /*var user = context.Database.ExecuteSqlCommand("select COUNT(*) from AppUser where UserName = @UserName and PassWord = @PassWord", sqlParams);*/
            var user = _context.AppUsers.Where(u => u.UserName==userName&&u.PassWord==passWord&&u.UserRole=="admin").Count();
            if (user == 0)
            {
                return false;
            }
            return true;
        }
    }
}
