using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DATA.Entities
{
   public class Model
    {
        public int Id { get; set; }
        [Required, StringLength(20), DisplayName("ModelName")]
        public string Name { get; set; }
        public int BrandId { get; set; }
      
        [ForeignKey("BrandId")]
        public virtual Brand Brand { get; set; }
    }
}
