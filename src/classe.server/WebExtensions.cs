namespace ClassE
{
    internal static class WebExtensions
    {
        public static IServiceCollection AddWebServices(this IServiceCollection services)
        {
            services.AddScoped<Services.ICurrentUserService, Services.CurrentUserService>();
            services.AddHttpContextAccessor();

            return services;
        }
    }
}