using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pi.domaine.Entities
{
   public class Client:User
    {
        [Required(AllowEmptyStrings = false)]
        [DataType(DataType.PhoneNumber)]
        public String Email { get; set; }
        public String Password { get; set; }
        [Required(AllowEmptyStrings = false)]
        [RegularExpression(@"^[^,\.\^]+$")]
        [DataType(DataType.Text)]
        public String UserName { get; set; }

        public virtual ICollection<Post> Post { get; set; }
        public virtual ICollection<Comment> Comment { get; set; }
        public virtual IEnumerable<Comment> Cm { get; set; }


    }
}

