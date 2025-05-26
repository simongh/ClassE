using Microsoft.EntityFrameworkCore;

namespace ClassE
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services
                .AddDbContext<Data.DataContext>(options =>
                {
                    options.UseSqlite(builder.Configuration.GetConnectionString("classe"));
                });
            //.Configure<Types.Options>(builder.Configuration.GetSection("timeoff"))
            //.AddApplicationServices(options =>
            //{
            //    var provider = builder.Configuration.GetValue("Provider", "sqlite");
            //    var cs = builder.Configuration.GetConnectionString("timeoff");
            //    _ = provider switch
            //    {
            //        "sqlserver" => options
            //            .UseSqlServer(cs, sql => sql.MigrationsAssembly("Timeoff.SqlServer")),
            //        _ => options
            //            .UseSqlite(cs, sql => sql.MigrationsAssembly("Timeoff.Sqlite"))
            //    };
            //})
            // Add services to the container.

            builder.Services.AddControllers();

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