using DataAccsesLayer.Interfaces;
using DataAccsesLayer.Repositories;
using DataAccsesLayer;
using Microsoft.EntityFrameworkCore;
using DataAccessLayer.Interfaces;
using Serilog;
using BusnisLogicLayer.Interfaces;
using BusnisLogicLayer.Services;
using AutoMapper;
using Animals;
using BussinessLogicLayer.Interfaces;

Log.Logger = new LoggerConfiguration()
    .WriteTo.File("log-.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

try
{
    var builder = WebApplication.CreateBuilder(args);

    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddDbContext<ApplicationDbContext>(opt
                    => opt.UseSqlServer(builder.Configuration.GetConnectionString("LocalSqlServer")));
    var mapperConfig = new MapperConfiguration(mc =>
    {
        mc.AddProfile(new MapperProfile());
    });
    builder.Services.AddTransient<IAnimalInterface, AnimalRepository>();
    builder.Services.AddTransient<ICategoryInterface, CategoryRepository>();
    builder.Services.AddTransient<IUnitOfWork, UnitOfWor>();
    builder.Services.AddTransient<IAnimalService, AnimalService>();
    builder.Services.AddTransient<ICategoryServeice, CategoryService>();
    IMapper mapper = mapperConfig.CreateMapper();
    builder.Services.AddSingleton(mapper);
    builder.Host.UseSerilog();
    var app = builder.Build();

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();

}
catch (Exception ex)
{
    Log.Fatal(ex, "Application terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}