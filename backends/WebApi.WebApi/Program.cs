using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using WebApi.Business.Src.Abstractions;
using WebApi.Business.Src.Implementations;
using WebApi.Business.Src.Shared;
using WebApi.Domain.Src.Abstractions;
using WebApi.WebApi.Database;
using WebApi.WebApi.Repositores;

var builder = WebApplication.CreateBuilder(args);

// Add Automapper DI
builder.Services.AddAutoMapper(typeof(Program).Assembly);

// Add db context
builder.Services.AddDbContext<DatabaseContext>();

builder.Services.AddControllers();

// Add Service DI
builder.Services
.AddScoped<IAuthService, AuthService>()

.AddScoped<ICartItemRepo, CartItemRepo>()
.AddScoped<ICartItemService, CartItemService>()

// .AddScoped<ICategoryRepo, CategoryRepo>()
// .AddScoped<ICategoryService, CategoryService>()

// .AddScoped<IOrderdetailRepo, OrderdetailRepo>()
// .AddScoped<IOrderDetailService, OrderDetailServer>()

// .AddScoped<IOrderRepo, OrderRepo>()
// .AddScoped<IOrderService, OrderService>()

// .AddScoped<IPaymentRepo, PaymentRepo>()
// .AddScoped<IPaymentService, PaymentService>()

// .AddScoped<IReviewRepo, ReviewRepo>()
// .AddScoped<IReviewService, ReviewService>()

// .AddScoped<IShippingRepo, ShippingRepo>()
// .AddScoped<IShippingService, ShippingService>()

// .AddScoped<IShoppingCartRepo, ShoppingCartRepo>()
// .AddScoped<IShoppingCartService, ShoppingCartService>()

// .AddScoped<IProductRepo, ProductRepo>()
// .AddScoped<IProductService, ProductService>()

.AddScoped<IUserRepo, UserRepo>()
.AddScoped<IUserService, UserService>();

// Add services to the container.

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Description = "Bearer token authentication",
        Name = "Authentication",
        In = ParameterLocation.Header
    });
    options.OperationFilter<SecurityRequirementsOperationFilter>();
});
//Config route
builder.Services.Configure<RouteOptions>(options =>
{
    options.LowercaseUrls = true; 
});

// Config authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
         ValidateIssuer = true,
         ValidIssuer = "E-commerce backend",
         ValidateAudience = false,
         IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("my-secrete-key-jwt-token-validator")),
         ValidateIssuerSigningKey = true
    };
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{ 
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
