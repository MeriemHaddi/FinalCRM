using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pi.domaine.Entities
{
  public  class PointOfSale
    {
        public int PointOfSaleId { get; set; }
       
        public String Address { get; set; }
        public String State { get; set; }
        public String Name { get; set; }

        public string Service { get; set; }
        [Required(AllowEmptyStrings = false)]
        [DataType(DataType.PhoneNumber)]
        [Phone]
        public int PhoneNumber { get; set; }

        public virtual ICollection<Resources> Resources { get; set; }
        public virtual ICollection<Product> Product { get; set; }
        public virtual ICollection<User> User { get; set; }
    }
}
