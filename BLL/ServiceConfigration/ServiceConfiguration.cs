using BLL.Abstract;
using BLL.Concrete;
using BLL.Mapping;
using BLL.Validator;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace  BLL.ServiceConfigration
{
   public static class ServiceConfiguration
    {
        public static void RegisterBll(this IServiceCollection services)
        {
            services.AddScoped<ICarBll, CarBll>();

            services.AddSingleton<CarViewModelValidator, CarViewModelValidator>();

            services.AddAutoMapper(new Type[] { typeof(Car_Mapper) });
        }
    }
}
