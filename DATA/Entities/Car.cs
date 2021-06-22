using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DATA.Entities
{
  public  class Car
    {
        public int Id { get; set; }
      
       
        [Required, DisplayName("Plate number")]
        public string PlateNumber { get; set; }

        public int OwnerId { get; set; }
        
        [ForeignKey("OwnerId")]
        public virtual Employee Owner { get; set; }

        public int ModelId { get; set; }
       
        [ForeignKey("ModelId")]
        public virtual Model ModelBrand { get; set; }


        public int? CardId { get; set; }

        [ForeignKey("CardId")]
        public virtual AccessCard Card { get; set; }

    }
}
