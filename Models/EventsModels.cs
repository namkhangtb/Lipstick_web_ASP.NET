using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class EventsModels
    {
        private LipstickDbContext _context = null;
        public EventsModels()
        {
            _context = new LipstickDbContext();
        }
        public List<Colour> ListAll()
        {
            return _context.Colours.ToList();
        }
        public List<Size> ListAllSize()
        {
            return _context.Sizes.ToList();
        }
    }
}
