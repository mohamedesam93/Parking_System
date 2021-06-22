using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DATA.Entities
{
   public class HistoryTransit
    {
        public int Id { get; set; }

        public int CarId { get; set; }

        [ForeignKey("CarId")]
        public virtual Car Car { get; set; }

        public DateTime TimeOfPassing { get; set; }
    }
}
