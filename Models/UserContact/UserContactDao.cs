using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.UserContact
{
    public class UserContactDao
    {
        LipstickDbContext _context = null;
        public UserContactDao()
        {
            _context = new LipstickDbContext();
        }
        public string InsertContact(Contact entity)
        {
            _context.Contacts.Add(entity);
            _context.SaveChanges();
            return entity.Gmail;
        }
        public bool CheckUserName(string Gmail)
        {
            return _context.Contacts.Count(x => x.Gmail == Gmail) > 0;
        }

    }
}
