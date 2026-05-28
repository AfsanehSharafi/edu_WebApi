using Application.Contracts;
using Application.Features.Categories.Handlers.Commands;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application
{
    public static class ApplicationServicesRegistration
    {
        public static IServiceCollection AddApplicationServices(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            //services.AddScoped<ICategoryRepository, CategoryRepository>();
            //services.AddMediatR(cfg =>
            //    cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));


            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(CreateCategoryCommandHandler).Assembly);
            });
            return services;
        }
    }
}
