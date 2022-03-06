using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using PagedList;
using Models.Framework;

namespace Models.UserRegistration
{
    public class UserRegisterDao
    {
        LipstickDbContext _context = null;
        public UserRegisterDao()
        {
            _context = new LipstickDbContext();
        }
        public int Insert(AppUser entity)
        {
            _context.AppUsers.Add(entity);
            _context.SaveChanges();
            var createIdCart = _context.AppUsers.Where(x => x.UserName == entity.UserName).FirstOrDefault();
            createIdCart.CartID = createIdCart.Id;
            _context.SaveChanges();
            return entity.Id;
        }
        public bool CheckUserName(string userName)
        {
            return _context.AppUsers.Count(x => x.UserName == userName) > 0;
        }
    }
}
