using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pi.domaine.Entities
{
    public class factdev
    {
        //id pk
        public int FactdevId { get; set; }
        // fk iduser
        public User UserId { get; set; }


        [Required(AllowEmptyStrings = false)]
        [MaxLength(20)]
        [DataType(DataType.Text)]
        public string reference { get; set; }

        public int prix { get; set; }

        public DateTime date { get; set; }

        public int etat { get; set; }

        //  [ForeignKey("UserId")]
        //    public User user { get; set; }

        public List<lignecmd> lignes { get; set; }

        public factdev()
        {
            //      this.lignes = new List<lignecmd>();
        }


    }
}
