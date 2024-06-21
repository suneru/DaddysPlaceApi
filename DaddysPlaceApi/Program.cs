using AutoMapper;
using DaddysPlaceApi;
using DaddysPlaceApi.Mapper;
using DaddysPlaceApi.Repository;
using DaddysPlaceApi.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<SqlConnectionSettings> (builder.Configuration.GetSection("ConnectionStrings"));
builder.Services.AddScoped<IUserRepository, UserRepositor>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IDbConnectors, DbConnectors>();

var mapperConfiguration = new MapperConfiguration(cfg => 
{
    cfg.AddProfile(typeof(MapperProfile));
});
var mapper= mapperConfiguration.CreateMapper();
builder.Services.AddSingleton(mapper);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
