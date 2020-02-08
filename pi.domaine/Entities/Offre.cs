using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pi.domaine.Entities
{
    [Table("Offre")]
    public class Offre
    {
        [Key]
        [DisplayName("Reference")]
        public String Id_Offre { get; set; }

        [Required(AllowEmptyStrings = false)]
        [MaxLength(20, ErrorMessage = "error")]
        [DataType(DataType.Text)]
        public String Titre { get; set; }

        [Required(AllowEmptyStrings = false)]
        [DataType(DataType.Text)]
        public String Description { get; set; }

        public String periode { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime date_debut { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime date_fin { get; set; }

        [DisplayName("Prix Total")]
        public float Prix { get; set; }
        [DisplayName("Couverture")]
        public String img { get; set; }

    }
}

