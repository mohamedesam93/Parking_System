using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DATA.Entities
{
  public  class Employee
    {

        public int EmployeeId { get; set; }

        [Required, StringLength(100), DisplayName("Employee Name")]
        public string Name { get; set; }
       
        [Required]
        public string Position { get; set; }
        [Required]
        public int Age { get; set; }

        public int ? CarId { get; set; }

        [ForeignKey("CarId")]
        public virtual Car Car { get; set; }
    }
}
