using BLL.ViewModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Validator
{
   public class CarViewModelValidator : AbstractValidator<CarViewModel>
    {
        public CarViewModelValidator()
        {
            RuleFor(x => x.EmployeeName).NotEmpty();
            RuleFor(x => x.ModelName).NotEmpty();
            RuleFor(x => x.BrandName).NotEmpty();
            RuleFor(x => x.PlateNumber).NotEmpty();
        }
    }
}
