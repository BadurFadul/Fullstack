using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using WebApi.Business.Src.Abstractions;
using WebApi.Business.Src.Implementations;
using WebApi.Business.Src.Shared;
using WebApi.Domain.Src.Abstractions;
using WebApi.Domain.Src.Entities;
using WebApi.WebApi.AuthorizationRequirement;
using WebApi.WebApi.Database;
using WebApi.WebApi.Middleware;
using WebApi.WebApi.Repositores;

var builder = WebApplication.CreateBuilder(args);


// Add this line to build the configuration
IConfiguration configuration = new ConfigurationBuilder()
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true)
    .AddEnvironmentVariables()
    .Build();

// Register the configuration in DI
builder.Services.AddSingleton(configuration);

// Register the JWT secret key
var jwtSecretKey = configuration.GetValue<string>("Jwt:SecretKey");
builder.Services.AddSingleton(jwtSecretKey);

// Add Automapper DI
builder.Services.AddAutoMapper(typeof(Program).Assembly);

// Add db context
builder.Services.AddDbContext<DatabaseContext>();

builder.Services.AddControllers();

// Add Service DI
builder.Services


.AddScoped<ICartItemRepo, CartItemRepo>()
.AddScoped<IBaseRepo<Category>, BaseRepo<Category>>()
.AddScoped<IBaseRepo<OrderDetail>, BaseRepo<OrderDetail>>()
.AddScoped<IBaseRepo<Order>, BaseRepo<Order>>()
.AddScoped<IBaseRepo<Payment>, BaseRepo<Payment>>()
.AddScoped<IBaseRepo<Review>, BaseRepo<Review>>()
.AddScoped<IBaseRepo<Shipping>, BaseRepo<Shipping>>()
.AddScoped<IBaseRepo<ShoppingCart>, BaseRepo<ShoppingCart>>()
.AddScoped<IBaseRepo<Product>, BaseRepo<Product>>()
.AddScoped<IUserRepo, UserRepo>()

.AddScoped<ICategoryService, CategoryService>()
.AddScoped<IOrderDetailService, OrderDetailServer>()
.AddScoped<IOrderService, OrderService>()
.AddScoped<IPaymentService, PaymentService>()
.AddScoped<IReviewService, ReviewService>()
.AddScoped<IShippingService, ShippingService>()
.AddScoped<IShoppingCartService, ShoppingCartService>()
.AddScoped<IProductService, ProductService>()
.AddScoped<IUserService, UserService>()
.AddScoped<ICartItemService, CartItemService>()
.AddScoped<IAuthService, AuthService>();
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

//Add policy based requirement 
builder.Services.AddSingleton<OrderOwerOnlyHandler>();
builder.Services.AddSingleton<UserOnlyHandler>();
builder.Services.AddSingleton<OnlyReviewOwnerHandler>();

//add Errorhnadlar
builder.Services.AddSingleton<ErrorHandlerMiddleware>();
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
         ValidIssuer = "Ecommerce-backend",
         ValidateAudience = false,
         IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("my-secrete-key-jwt-token-validator")),
         ValidateIssuerSigningKey = true
    };
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("EmailWhiteList", policy => policy.RequireClaim(ClaimTypes.Email, "Admin@gmail.com"));
    options.AddPolicy("OrderOwnerOnly", policy => policy.Requirements.Add(new OrderOwerOnly()));
    options.AddPolicy("UserOnly", policy => policy.Requirements.Add(new UserOnly()));
    options.AddPolicy("OnlyReviewOwner", policy => policy.Requirements.Add(new OnlyReviewOwner()));
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{ 
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ErrorHandlerMiddleware>();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
