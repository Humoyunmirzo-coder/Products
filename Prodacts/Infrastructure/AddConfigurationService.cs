using Aplication.Service;
using Infrastructure.DataAccess;
using Infrastructure.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public  static  class AddConfigurationService
    {
        public static void AddConfigurationServices ( this IServiceCollection services , IConfiguration configuration )
        {
                services.AddScoped<IProductService, ProductService>();
                services.AddDbContext<ProductDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("ProductionConnection")));
        }
    }
}
