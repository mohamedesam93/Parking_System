using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DATA.Entities
{
  public class Brand
    {
        public int Id { get; set; }
        [Required, StringLength(50), DisplayName("Brand name")]
        public string Name { get; set; }
        public virtual ICollection<Model> BrandModels { get; set; }
    }
}
