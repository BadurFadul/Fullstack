using Microsoft.EntityFrameworkCore;
using WebApi.Domain.Src.Entities;
using Npgsql;

namespace WebApi.WebApi.Database
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
        static DatabaseContext()
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new NpgsqlDataSourceBuilder(_configuration.GetConnectionString("DefaultConnection"));
            optionsBuilder.AddInterceptors(new TimeStampInterceptor());
            builder.MapEnum<Role>();
            //builder.MapEnum<OrderStatus>();
            optionsBuilder.UseNpgsql(builder.Build()).UseSnakeCaseNamingConvention();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasPostgresEnum<Role>();

            modelBuilder.Entity<Product>()
            .HasOne(p => p.category)
            .WithMany(p => p.Products)
            .HasForeignKey(p => p.CategoryId)
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Order>()
            .HasOne(p => p.User)
            .WithMany(p => p.Orders)
            .HasForeignKey(p => p.UserId)
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Review>()
            .HasOne(p => p.User)
            .WithMany(P => P.Reviews)
            .HasForeignKey(p => p.UserId)
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Payment>()
            .HasOne(p => p.User)
            .WithMany(p => p.payments)
            .HasForeignKey(p => p.UserId)
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<OrderDetail>()
            .HasOne(p => p.Order)
            .WithMany(p => p.OrderDetails)
            .HasForeignKey(p => p.OrderId)
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Payment>()
            .HasOne(p => p.Order)
            .WithMany(p => p.Payments)
            .HasForeignKey(p => p.OrderId)
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Review>()
            .HasOne(p => p.Product)
            .WithMany(p => p.Reviews)
            .HasForeignKey(p => p.ProductId)
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CartItem>()
            .HasOne(p => p.Product)
            .WithMany(p => p.cartItems)
            .HasForeignKey(p => p.ProductId)
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CartItem>()
            .HasOne(p => p.shoppingCart)
            .WithMany(p => p.cartItems)
            .HasForeignKey(p => p.ShoppingCartId)
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ShoppingCart>()
            .HasOne(p => p.User)
            .WithOne(p => p.shoppingCart)
            .HasForeignKey<ShoppingCart>(p => p.UserId)
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Shipping>()
            .HasOne(p => p.Order)
            .WithOne(p => p.shipping)
            .HasForeignKey<Shipping>(p => p.OrderId)
            .OnDelete(DeleteBehavior.Cascade);
    
            //modelBuilder.HasPostgresEnum<OrderStatus>();

            // modelBuilder.Entity<User>()
            // .HasOne(u => u.shoppingCart)
            // .WithOne(a => a.User)
            // .HasForeignKey<ShoppingCart>(u => u.ShoppingCartId);

            // modelBuilder.Entity<Order>()
            // .HasOne(o => o.shipping)
            // .WithOne(o => o.order)
            // .HasForeignKey<Shipping>(u => u.ShippingId);

            modelBuilder.Entity<User>()
            .HasIndex(u => u.Email).IsUnique();
        }
    }
}