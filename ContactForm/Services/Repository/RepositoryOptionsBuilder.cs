using Microsoft.Extensions.DependencyInjection;
using System;

namespace MroczekDotDev.ContactForm.Services.Repository
{
    public class RepositoryOptionsBuilder
    {
        private readonly IServiceCollection services;
        private string connectionString;

        public RepositoryType RepositoryType { get; private set; }

        public RepositoryOptionsBuilder(IServiceCollection services)
        {
            this.services = services;
        }

        public RepositoryOptionsBuilder UseSqlServer(string connectionString)
        {
            RepositoryType = RepositoryType.SqlServer;

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException("ConnectionString is not specified.");
            }
            this.connectionString = connectionString;

            return this;
        }

        public RepositoryOptionsBuilder Build()
        {
            switch (RepositoryType)
            {
                case RepositoryType.SqlServer:
                    services.Configure<SqlServerRepositoryOptions>(o => o.ConnectionString = connectionString);
                    break;

                default:
                    throw new InvalidOperationException("Repository type is not specified.");
            }
            return this;
        }
    }
}
