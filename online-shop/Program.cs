using Application.Common.Interfaces;
using Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using OnlineShop.Application.Basket.Commands.SelectItem;
using OnlineShop.Application.Basket.Queries.GetItemsByType;
using Serilog;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddShopInfrastructure(builder.Configuration);
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddLogging();
builder.Services.AddSingleton(typeof(Microsoft.Extensions.Logging.ILogger), typeof(Logger<Program>));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//using var scope = app.Services.CreateScope();
//await using var dbContext = scope.ServiceProvider.GetRequiredService<ShopContext>();
//await dbContext.Database.EnsureCreatedAsync();



//static void MigrateDatabase(IHost host)
//{
//    using var scope = host.Services.CreateScope();
//    var services = scope.ServiceProvider;

//    try
//    {
//        var stampMakerContext = services.GetRequiredService<IOnlineShopContext>();
//        stampMakerContext.Migrate();
//    }
//    catch (Exception ex)
//    {
//        Log.Fatal(ex, "An error occurred while migrating or initializing the database.");
//        throw;
//    }
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
