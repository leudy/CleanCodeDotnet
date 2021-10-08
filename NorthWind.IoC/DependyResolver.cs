using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NorthWind.Repositories.EFCore;
using NorthWind.Repositories.EFCore.Repositories;
using NorthWind.UseCases.Common.Behaviors;
using NorthWind.UseCases.CreateOrder;
using Nortwind.Entities.Intefaces;

namespace NorthWind.IoC
{
    public static class DependyResolver
    {
        public static IServiceCollection AddNortWindServices(this IServiceCollection services,IConfiguration configuration)
        {
            string dbString = configuration.GetConnectionString("NortwindDB");

            services.AddDbContext<NorthWindContext>(opt=> opt.UseSqlServer(dbString) );
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();


            services.AddMediatR(typeof(CreateOrderInteractor));
            services.AddValidatorsFromAssembly(typeof(CreateOrderValidator).Assembly);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            
            
            
            return services;
        }
    }
}
