using Microsoft.EntityFrameworkCore;
using ProiectDAW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectDAW.Data
{
    public class ProiectDAWContext: DbContext
    {
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public ProiectDAWContext(DbContextOptions<ProiectDAWContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            // One to many
            builder.Entity<Category>()
                .HasMany(category => category.Products)
                .WithOne(product => product.Category);

            builder.Entity<Product>()
                .HasOne(product => product.Category)
                .WithMany(category => category.Products);

            builder.Entity<User>()
                .HasMany(user => user.Orders)
                .WithOne(order => order.User);

            builder.Entity<Order>()
                .HasOne(order => order.User)
                .WithMany(user => user.Orders);

            // One to one
            builder.Entity<User>()
                .HasOne(user => user.Address)
                .WithOne(address => address.User)
                .HasForeignKey<Address>(address => address.UserId);

            //Many to many
            builder.Entity<Cart>().HasKey(cart => new { cart.UserId, cart.ProductId });
            builder.Entity<Cart>()
                .HasOne<User>(cart => cart.User)
                .WithMany(user => user.Carts)
                .HasForeignKey(cart => cart.UserId);
            builder.Entity<Cart>()
                .HasOne<Product>(cart => cart.Product)
                .WithMany(product => product.Carts)
                .HasForeignKey(cart => cart.ProductId);


            builder.Entity<OrderDetail>().HasKey(orderDetail => new { orderDetail.OrderId, orderDetail.ProductId });
            builder.Entity<OrderDetail>()
                .HasOne<Order>(orderDetail => orderDetail.Order)
                .WithMany(order => order.OrderDetails)
                .HasForeignKey(orderDetail => orderDetail.OrderId);
            builder.Entity<OrderDetail>()
                .HasOne<Product>(orderDetail => orderDetail.Product)
                .WithMany(product => product.OrderDetails)
                .HasForeignKey(orderDetail => orderDetail.ProductId);


            base.OnModelCreating(builder);
        }
    }
}
