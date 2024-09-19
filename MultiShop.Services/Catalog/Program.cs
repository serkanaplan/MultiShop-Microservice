using Microsoft.AspNetCore.Authentication.JwtBearer;
using Catalog.Services.FeatureSliderServices;
using Catalog.Services.OfferDiscountServices;
using Catalog.Services.ProductDetailServices;
using Catalog.Services.ProductImageServices;
using Catalog.Services.SpecialOfferServices;
using Catalog.Services.StatisticServices;
using Catalog.Services.CategoryServices;
using Catalog.Services.ContactServices;
using Catalog.Services.FeatureServices;
using Catalog.Services.ProductServices;
using Catalog.Services.AboutServices;
using Catalog.Services.BrandServices;
using Microsoft.Extensions.Options;
using System.Reflection;
using Catalog.Settings;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
    opt.Authority = builder.Configuration["IdentityServerUrl"];
    opt.Audience = "ResourceCatalog";
    opt.RequireHttpsMetadata = false;
});

builder.Services.AddScoped<IStatisticService, StatisticService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductDetailService, ProductDetailService>();
builder.Services.AddScoped<IProductImageService, ProductImageService>();
builder.Services.AddScoped<IFeatureSliderService, FeatureSliderService>();
builder.Services.AddScoped<ISpecialOfferService, SpecialOfferService>();
builder.Services.AddScoped<IFeatureService, FeatureService>();
builder.Services.AddScoped<IOfferDiscountService, OfferDiscountService>();
builder.Services.AddScoped<IBrandService, BrandService>();
builder.Services.AddScoped<IAboutService, AboutService>();
builder.Services.AddScoped<IContactService, ContactService>();

builder.Services.AddScoped<IDatabaseSettings>(sp =>sp.GetRequiredService<IOptions<DatabaseSettings>>().Value);
builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("DatabaseSettings"));

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();
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