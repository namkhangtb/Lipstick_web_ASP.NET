using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Models.Framework
{
    public partial class LipstickDbContext : DbContext
    {
        public LipstickDbContext()
            : base("name=LipstickDbContext")
        {
        }

        public virtual DbSet<AppUser> AppUsers { get; set; }
        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Colour> Colours { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Size> Sizes { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cart>()
                .Property(e => e.Alias)
                .IsUnicode(false);

            modelBuilder.Entity<Cart>()
                .Property(e => e.Price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Cart>()
                .Property(e => e.Size)
                .IsUnicode(false);

            modelBuilder.Entity<Cart>()
                .Property(e => e.Colour)
                .IsUnicode(false);

            modelBuilder.Entity<Cart>()
                .Property(e => e.QuanityPice)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Category>()
                .Property(e => e.Alias)
                .IsUnicode(false);

            modelBuilder.Entity<Order>()
                .Property(e => e.Price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<OrderDetail>()
                .Property(e => e.Price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Product>()
                .Property(e => e.Alias)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.Price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Product>()
                .Property(e => e.Size)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.Colour)
                .IsUnicode(false);
        }
    }
}
