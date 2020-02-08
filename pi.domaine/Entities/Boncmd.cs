using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pi.domaine.Entities
{
    public class Boncmd
    {
        [Key]
        public int BoncmdId { get; set; }

        public int UserId { get; set; }


        [Required(AllowEmptyStrings = false)]
        [MaxLength(20)]
        [DataType(DataType.Text)]
        public String reference { get; set; }

        public double prixb { get; set; }

        public double prix { get; set; }

        public DateTime date { get; set; }

        public int etat { get; set; }

        [DefaultValue("")]
        public string codeqr { get; set; }

        //[ForeignKey("UserId")]
        //        public User userr { get; set; }
        //  [ForeignKey("UserId")]
        //      public User user { get; set; }

        public List<lignecmd> lignes { get; set; }

        public Boncmd()
        {
            //      this.lignes = new List<lignecmd>();
        }

    }
}
