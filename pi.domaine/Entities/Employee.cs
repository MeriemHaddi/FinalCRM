using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pi.domaine.Entities
{
   public class Employee:User
    {
        [Required(AllowEmptyStrings = false)]
        [DataType(DataType.PhoneNumber)]
        public String Email { get; set; }
        public String Password { get; set; }
        [Required(AllowEmptyStrings = false)]
        [RegularExpression(@"^[^,\.\^]+$")]
        [DataType(DataType.Text)]
        public String UserName { get; set; }
        public int Salary { get; set; }
        public String Position { get; set; }
        public virtual ICollection<Resources> Resources { get; set; }
        public int PointOfSaleId { get; set; }
        public PointOfSale PointOfSale { get; set; }
    }
}
