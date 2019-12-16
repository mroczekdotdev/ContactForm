using Microsoft.Extensions.DependencyInjection;

namespace MroczekDotDev.ContactForm.Services.EmailSender
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddLocalEmailSender(this IServiceCollection services)
        {
            services.AddSingleton<IEmailSender, LocalEmailSender>();
            return services;
        }
    }
}
