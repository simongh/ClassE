using Microsoft.EntityFrameworkCore;

namespace ClassE
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services
                .Configure<Types.Options>(builder.Configuration.GetSection("classe"))
                .AddDbContext<Data.DataContext>(options =>
                {
                    var provider = builder.Configuration.GetValue("Provider", "sqlite");
                    var cs = builder.Configuration.GetConnectionString("classe");

                    _ = provider switch
                    {
                        _ => options.UseSqlite(cs)
                    };
                })
                .AddApplicationServices();

            builder.Services.AddControllers();
            builder.Services.ConfigureJson();
            builder.Services.AddAutoMapper(config => { });

            var app = builder.Build();

            app.UseDefaultFiles();
            app.UseStaticFiles();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.MapFallbackToFile("/index.html");

            app.Run();
        }
    }
}