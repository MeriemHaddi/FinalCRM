using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pi.domaine.Entities
{
   public class Resources
    {
        public int ResourcesId { get; set; }
        public String Description { get; set; }
      
        public int EmployeeId { get; set; }
        //[ForeignKey("Employee")]
        //public Employee Employee { get; set; }
        public int PointOfSaleId { get; set; }
        public PointOfSale PointOfSale { get; set; }
        public string State { get; set; }
    }
}
