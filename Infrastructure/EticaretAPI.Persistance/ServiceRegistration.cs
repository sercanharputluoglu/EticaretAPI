using Microsoft.EntityFrameworkCore;
using EticaretAPI.Application.Abstractions;
using EticaretAPI.Persistance.Concretes;
using EticaretAPI.Persistance.Contexts;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace EticaretAPI.Persistance
{
    public static class ServiceRegistration
    {
        public static void AddPersistanceServices(this IServiceCollection services)
        {
            /*
            ConfigurationManager configurationManager = new();
            configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/EticaretAPI.API"));
            configurationManager.AddJsonFile("appsettings.json");
            */

            services.AddSingleton<IProductService, ProductService>();
            services.AddDbContext<EticaretAPIDbContext>(options => options.UseNpgsql(Configuration.ConnnectionString));
        }
    }
}
