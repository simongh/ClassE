using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ClassE
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(Behaviours.ValidationBehaviour<,>));
            services.AddMediatR(options =>
            {
                options.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });

            services.AddScoped<Data.IDataContext, Data.DataContext>();

            services.AddTransient<Validators.QueryValidator>();

            services.AddTransient<IValidator<Attendees.UpdateCommand>, Attendees.UpdateCommandValidator>();

            services.AddTransient<IValidator<Classes.ClassesQuery>, Classes.ClassesQueryValidator>();
            services.AddTransient<IValidator<Classes.UpdateCommand>, Classes.UpdateCommandValidator>();

            services.AddTransient<IValidator<Payments.PaymentsQuery>, Payments.PaymentsQueryValidator>();
            services.AddTransient<IValidator<Payments.UpdateCommand>, Payments.UpdateCommandValidator>();

            services.AddTransient<IValidator<Person.PersonQuery>, Person.PersonQueryValidator>();
            services.AddTransient<IValidator<Person.UpdateCommand>, Person.UpdateCommandValidator>();

            services.AddTransient<IValidator<Sessions.SessionsQuery>, Sessions.SessionsQueryValidator>();

            services.AddTransient<IValidator<Venue.VenueQuery>, Venue.VenueQueryValidator>();
            services.AddTransient<IValidator<Venue.UpdateVenueCommand>, Venue.UpdateCommandValidator>();

            return services;
        }

        public static void Migrate(this IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            scope.ServiceProvider.GetRequiredService<Data.DataContext>().Database.Migrate();
        }
    }
}