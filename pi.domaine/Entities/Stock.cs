using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pi.domaine.Entities
{
   public class Stock
    {
        [Key]
        public int Id_Stock { get; set; }
        public int In_Quantity { get; set; }
        public int Out_Quantity { get; set; }
        public int Quantity { get; set; }
       
       
      
        public Shop id_Shop { get; set; }
       
        public Stock() { }
    }
}
