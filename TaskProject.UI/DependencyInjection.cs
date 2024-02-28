
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Options;
using System.Globalization;
using TaskProject.DataAccess;
using TaskProject.Infrastructure.Interfaces.Contact;
using TaskProject.Infrastructure.Services.Contact;

namespace TaskProject.UI
{
    public static class DependencyInjection
    {
        public static void AddCor(this IServiceCollection services)
        {
            services.AddCors(op =>
            {
                op.AddDefaultPolicy(p => p.AllowAnyOrigin()
                                          .AllowAnyHeader()
                                          .AllowAnyMethod()
                                          .SetPreflightMaxAge(TimeSpan.FromMinutes(10)));
            });
        }
        public static void AddTransientServices(this IServiceCollection services)
        {
           
            services.AddTransient<IContactService, ContactService>();
        }
       
    }
}
