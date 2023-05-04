using WebAPI_MNS_Games.Domain.Services;
using WebAPI_MNS_Games.Abstractions;
using WebAPI_MNS_Games.Repo;
using System.Data.SqlClient;
using System.Data;

namespace WebAPI_MNS_Games
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddTransient<IDbConnection>(db => new SqlConnection(builder.Configuration.GetConnectionString("Default")));
            builder.Services.AddTransient<IAppUserService, AppUserService>();
            builder.Services.AddTransient<IAppUserRepository, AppUserRepository>();

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
        }
    }
}