using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using FluentValidation;
using Vaultex.Shared.Interfaces;
using Vaultex.Shared;
using MediatR;
using Vaultex.Application.Repositories;
using Vaultex.Application.Specifications;

namespace Vaultex.Application.Extensions
{
    public static class IServiceCollectionExtensions
    {

        public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddScoped(typeof(IResult<>), typeof(Result<>));
            services.AddScoped(typeof(ISpecifications<>), typeof(BaseSpecification<>));
            return services;
        }

    }
}
