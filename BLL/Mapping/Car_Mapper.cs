using AutoMapper;
using BLL.ViewModels;
using DATA.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace  BLL.Mapping
{
   public class Car_Mapper : Profile
    {

        public Car_Mapper()
        {
			//Car
			CreateMap<CarViewModel, Car>();

			CreateMap<Car, CarViewModel>()
			.ForPath(m => m.EmployeeName, MO => MO.MapFrom(s => s.Owner.Name))
			.ForPath(m => m.BrandName, MO => MO.MapFrom(s => s.ModelBrand.Brand.Name))
			.ForPath(m => m.ModelName, MO => MO.MapFrom(s => s.ModelBrand.Name));
			


		}
	}
}
