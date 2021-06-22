using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.ViewModels
{
  public  class CarViewModel
    {
        public int Id { get; set; }
        public string PlateNumber { get; set; }

        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }

        public int ModelId { get; set; }   
        public string ModelName { get; set; }
     
        public int BrandId { get; set; }
        public string BrandName { get; set; }

    }
}
