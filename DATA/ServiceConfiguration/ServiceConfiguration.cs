using DATA.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DATA.ServiceConfiguration
{
  public static class ServiceConfiguration
    {
        public static void UseSQL(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddDbContext<ERPContext>(options => {
                options.UseSqlServer(Configuration.GetConnectionString("SystemConnection"));
            });
           
        }

    }
}
