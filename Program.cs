using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Quiero_revisar;
using Quiero_revisar.Data_Context;
using Quiero_revisar.Service;
using Quiero_revisar.Service.Implementation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
#region establecer contexto base de datos
builder.Services.AddDbContext<TiendaComics>(
    opt =>
    {
        opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
        .EnableSensitiveDataLogging(true).UseLazyLoadingProxies();
    });
#endregion
#region configurar mapper
builder.Services.AddSingleton(provider =>
{
    return new MapperConfiguration(config =>
    {
        config.AddProfile<AutoMapperProfile>();
        config.ConstructServicesUsing(type =>
        ActivatorUtilities.GetServiceOrCreateInstance(provider, type));
    });
});
#endregion

builder.Services.AddControllersWithViews();
builder.Services.AddScoped<ICatalogoService, CatalogoService>();
//builder.Services.AddTransient<ICatalogoService, CatalogoService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();
