using TravelCompanyBusinessLogic.BusinessLogic;
using TravelCompanyContracts.BusinessLogicsContracts;
using TravelCompanyContracts.StoragesContracts;
using TravelCompanyDatabaseImplement.Implements;
using Microsoft.OpenApi.Models;
using TravelCompanyRestApi;
using TravelCompanyBusinessLogic.BusinessLogics;
var builder = WebApplication.CreateBuilder(args);
builder.Logging.SetMinimumLevel(LogLevel.Trace);
builder.Logging.AddLog4Net("log4net.config");
// Add services to the container.
builder.Services.AddTransient<IClientStorage, ClientStorage>();
builder.Services.AddTransient<IOrderStorage, OrderStorage>();
builder.Services.AddTransient<ITravelStorage, TravelStorage>();
builder.Services.AddTransient<IShopStorage, ShopStorage>();

builder.Services.AddTransient<IOrderLogic, OrderLogic>();
builder.Services.AddTransient<IClientLogic, ClientLogic>();
builder.Services.AddTransient<ITravelLogic, TravelLogic>();
builder.Services.AddTransient<IShopLogic, ShopLogic>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at
https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "TravelCompanyRestApi",
        Version
    = "v1"
    });
});
var app = builder.Build();
APIConfig.LoadData(builder.Configuration);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json",
   "TravelCompanyRestApi v1"));
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
