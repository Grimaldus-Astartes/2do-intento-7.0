using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Quiero_revisar;
using Quiero_revisar.Data_Context;
using Quiero_revisar.Service;
using Quiero_revisar.Service.Implementation;

var builder = WebApplication.CreateBuilder(args);

// No tenias esta linea de codigo, creo que por esto los controllers no se aniadian al contexto de la app
builder.Services.AddControllers();

// Swagger para testear los endpoints
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Esatto backend endpoints",
        Description = "This is a documentation for endpoints in esatto project.",
    });
});
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
    }).CreateMapper();
});
#endregion

builder.Services.AddScoped<ICatalogoService, CatalogoService>();
//builder.Services.AddTransient<ICatalogoService, CatalogoService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllers();


app.Run();
