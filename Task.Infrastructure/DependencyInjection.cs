
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaskProject.DataAccess;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using System.Buffers.Text;

namespace TaskProject.Infrastructure
{
    public static class DependencyInjection
    {
        public static void AddServices(this IServiceCollection services)
        {
      
            services.AddDistributedMemoryCache();
            //services.AddSession(options =>
            //{
            //    options.IdleTimeout = TimeSpan.FromMinutes(30);
            //});
          //  services.AddAutoMapper(Assembly.GetExecutingAssembly());
         
        }
        public static void AddDBContext(this IServiceCollection services, IConfiguration Configuration)
        {
            var connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<AppDBContext>(options =>
            {
                options.UseSqlServer(connection);
            });
        }
  
    }
}
