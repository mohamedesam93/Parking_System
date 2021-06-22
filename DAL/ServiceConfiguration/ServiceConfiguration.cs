using DAL.Abstract;
using DAL.Concrete;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

using System.Text;

namespace DAL.ServiceConfiguration
{
  public static  class ServiceConfiguration
    {
        public static void RegisterRepos(this IServiceCollection services)
        {  

            services.AddScoped<ICarRepository, CarRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

        }
    }
}
