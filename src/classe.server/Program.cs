using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

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
                        _ => options.UseSqlite(cs, sql => sql.MigrationsAssembly("classe.sqlite"))
                    };
                })
                .AddApplicationServices()
                .AddWebServices();

            builder.Services
                .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = "/login";
                    options.LogoutPath = "/logout";

                    options.Events.OnRedirectToAccessDenied =
                        options.Events.OnRedirectToLogin = c =>
                        {
                            c.Response.StatusCode = StatusCodes.Status401Unauthorized;
                            return Task.CompletedTask;
                        };
                })
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new()
                    {
                        ValidateIssuer = false,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = builder.Configuration["class£:siteUrl"],
                        ValidAudience = builder.Configuration["classE:siteUrl"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["classE:secret"]!))
                    };
                });

            builder.Services.AddControllers();
            builder.Services.ConfigureJson();
            builder.Services.AddAutoMapper(config => { });

            builder.Services.AddAuthorizationBuilder()
                .SetDefaultPolicy(new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build())
                .AddPolicy("token", policy => policy
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                    .RequireAuthenticatedUser()
                    .Build())
                .AddPolicy("cookies", policy => policy
                    .AddAuthenticationSchemes(CookieAuthenticationDefaults.AuthenticationScheme)
                    .RequireAuthenticatedUser());

            var app = builder.Build();

            app.Services.Migrate();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseDefaultFiles();
            app.UseStaticFiles();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers().RequireAuthorization();
            app.MapFallbackToFile("/index.html");

            app.Run();
        }
    }
}