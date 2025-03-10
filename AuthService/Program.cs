using AuthService.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace AuthService;

public class Program
{
    public static void Main(string[] args)
    {
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

        builder.Services.AddIdentityApiEndpoints<PlantingPadIdentity>().AddEntityFrameworkStores<ApplicationDbContext>();
        
        var app = builder.Build();

        app.MapIdentityApi<PlantingPadIdentity>();
        
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "PlantingPad Auth v1");
            });
        }
        
        // Configure the HTTP request pipeline.

        app.UseHttpsRedirection();

        app.UseAuthorization();
        
        app.MapControllers();

        app.Run();
    }
}