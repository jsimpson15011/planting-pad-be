using ApiService.Models;
using ApiService.Services;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddUserSecrets<Program>();

var serverName = builder.Configuration.GetValue<string>("DBConn:Server");
var dbUser = builder.Configuration.GetValue<string>("DBConn:User Id");
var dbDatabase = builder.Configuration.GetValue<string>("DBConn:Database");
var sqlPassword = builder.Configuration["SA_PASSWORD"];

SqlConnectionStringBuilder sqlBuilder =
  new SqlConnectionStringBuilder();

sqlBuilder.DataSource = serverName;
sqlBuilder.UserID = dbUser;
sqlBuilder.InitialCatalog = dbDatabase;
sqlBuilder.Password = sqlPassword;
if (builder.Environment.IsDevelopment())
{
  sqlBuilder.TrustServerCertificate = true;
}


// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(sqlBuilder.ToString()));

builder.Services.AddAuthentication();
builder.Services.AddAuthorization();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IPlantingPadService, PlantingPadService>();


var app = builder.Build();

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "PlantingPad API v1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();