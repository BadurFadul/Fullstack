using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Controllers;
using backend.Entities;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace backend.Database
{
    public class DatabaseContext: DbContext
    {
        private readonly IConfiguration _configuration;
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categorys { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Shipping> Shippings { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }

        public DatabaseContext( IConfiguration configuration)
        {
            _configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new NpgsqlDataSourceBuilder(_configuration.GetConnectionString("DefaultConnection"));
            builder.MapEnum<Role>();
            optionsBuilder.UseNpgsql(builder.Build());
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresEnum<Role>();

            modelBuilder.Entity<User>()
            .HasOne(u => u.shoppingCart)
            .WithOne(a => a.user)
            .HasForeignKey<ShoppingCart>(u => u.Id);

            modelBuilder.Entity<Order>()
            .HasOne(o => o.shipping)
            .WithOne(o => o.order)
            .HasForeignKey<Shipping>(u => u.Id);
        }
    }
}