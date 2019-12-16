using Microsoft.Extensions.DependencyInjection;
using System;

namespace MroczekDotDev.ContactForm.Services.Repository
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddRepository(
            this IServiceCollection services, Func<RepositoryOptionsBuilder, RepositoryOptionsBuilder> optionsBuilder)
        {
            var repositoryOptions = optionsBuilder(new RepositoryOptionsBuilder(services)).Build();

            switch (repositoryOptions.RepositoryType)
            {
                case RepositoryType.SqlServer:
                    services.AddScoped<IRepository, SqlServerRepository>();
                    break;
            }
            return services;
        }
    }
}
