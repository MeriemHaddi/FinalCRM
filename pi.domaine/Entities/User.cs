using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pi.domaine.Entities
{
   public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int UserId { get; set; }

        [Required(AllowEmptyStrings = false)]
        [MaxLength(20)]
        [DataType(DataType.Text)]
        public String Name { get; set; }


        [Required(AllowEmptyStrings = false)]
        [MaxLength(20, ErrorMessage = "error")]
        [DataType(DataType.Text)]
        public String LastName { get; set; }


        [Required(AllowEmptyStrings = false)]
        [MaxLength(20, ErrorMessage = "error")]
        [DataType(DataType.Text)]
        public String Adress { get; set; }


        public int PhoneNumber { get; set; }

        public static implicit operator User(int v)
        {
            throw new NotImplementedException();
        }
    }
}

