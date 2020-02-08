using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pi.domaine.Entities
{
   public class Admin:User
    {
        [Required(AllowEmptyStrings = false)]
        [MaxLength(8, ErrorMessage = "error")]
        public String CIN { get; set; }
    }
}
