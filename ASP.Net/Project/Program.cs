using Microsoft.EntityFrameworkCore;
using NLog;
using NLog.Web;
using Project.Data;
using Project.Filters;
using StudentApi.Filters;
namespace Project
{
    public class Program
    {
        public static void Main(string[] args)
        {

            LogManager.Setup().LoadConfigurationFromFile("nlog.config");
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Logging.ClearProviders();
            builder.Host.UseNLog();
            builder.Services.AddControllers(options =>
            {
                options.Filters.Add<ExceptionHandlingFilter>();
                options.Filters.Add<AddHeaderResultFilter>();
            });
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<AppDbContext>(options =>
                    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            var app = builder.Build();
            app.UseMiddleware<ExceptionHandlingMiddleware>();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
