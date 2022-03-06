using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.User
{
    public class CartModels
    {
        private LipstickDbContext _context = null;
        public CartModels()
        {
            _context = new LipstickDbContext();
        }
        public List<Cart> GetCart(string name)
        {
            var findID = _context.AppUsers.Where(x => x.UserName == name).FirstOrDefault();
            var result = _context.Carts.Where(x => x.CartID == findID.CartID).ToList();
            return result;
        }
        public int AddCart(int id, int colour, int size,string name)
        {
            var findcID = _context.AppUsers.Where(x => x.UserName == name).FirstOrDefault();
           
            /*Cart findID = (Cart)(from c in _context.Carts
                         where c.Id == id && c.CartID == findcID.CartID
                         select c);*/
            var findsz = _context.Sizes.Find(size);
            var findcl = _context.Colours.Find(colour);
            var findID = _context.Carts.Where(x => x.Id == id && x.CartID == findcID.CartID && x.Colour == findcl.colour1 && x.Size== findsz.C_size).FirstOrDefault();
            if (findID!=null)
            {
                if (findID.Id == id && findID.Size == findsz.C_size && findID.Colour == findcl.colour1&&findID.CartID== findcID.CartID)
                {
                    findID.Quanity = findID.Quanity + 1;
                    findID.QuanityPice = findID.QuanityPice + findID.Price;
                    _context.SaveChanges();
                    return (int)findID.Id;
                }
                else
                {
                     findcID = _context.AppUsers.Where(x => x.UserName == name).FirstOrDefault();
                    var find = _context.Products.Find(id);
                    findsz = _context.Sizes.Find(size);
                    findcl = _context.Colours.Find(colour);

                    var cart = new Cart
                    {
                        Id = find.Id,
                        Name = find.Name,
                        Alias = find.Alias,
                        CategoryId = find.CategoryId,
                        Images = find.Images,
                        Createdate = find.Createdate,
                        Price = find.Price,
                        Detail = find.Detail,
                        Status = find.Status,
                        Colour = findcl.colour1,
                        Size = findsz.C_size,
                        CartID = findcID.CartID,
                        Quanity = 1,
                        QuanityPice = find.Price,

                    };
                    _context.Carts.Add(cart);
                    _context.SaveChangesAsync();
                    return (int)cart.Id;
                }
            }
            else
            {
                 findcID = _context.AppUsers.Where(x => x.UserName == name).FirstOrDefault();
                var find = _context.Products.Find(id);
                 findsz = _context.Sizes.Find(size);
                 findcl = _context.Colours.Find(colour);

                var cart = new Cart
                {
                    Id = find.Id,
                    Name = find.Name,
                    Alias = find.Alias,
                    CategoryId = find.CategoryId,
                    Images = find.Images,
                    Createdate = find.Createdate,
                    Price = find.Price,
                    Detail = find.Detail,
                    Status = find.Status,
                    Colour = findcl.colour1,
                    Size = findsz.C_size,
                    CartID = findcID.CartID,
                    Quanity = 1,
                    QuanityPice = find.Price,
                    
                };
                _context.Carts.Add(cart);
                _context.SaveChangesAsync();
                return (int)cart.Id;
            }
        }
        public decimal Checkout(string cartUser)
        {
            var findUser = _context.AppUsers.Where(x => x.UserName == cartUser).FirstOrDefault();
            //var findCartID = _context.Carts.Where(x => x.CartID == findUser.CartID).FirstOrDefault();
            /*var sum = from c in _context.Carts
                      group c by c.CartID into check
                      select check.Sum(x => x.QuanityPice);*/
            var sum = _context.Carts.AsEnumerable().Where(x=>x.CartID==findUser.CartID).Sum(x => x.QuanityPice);
            return (decimal)sum;
        }
        public bool Remove(int prime)
        {
            try
            {
                var cart = _context.Carts.Find(prime);
                _context.Carts.Remove(cart);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public decimal ChangePrice(int Prime,int Quanity)
        {
            var result = _context.Carts.Find(Prime);
            result.Quanity = Quanity;
            result.QuanityPice = result.Price * Quanity;
            _context.SaveChanges();
            return (decimal)result.QuanityPice;
        }
    }
}
