using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pi.domaine.Entities
{
    [Table("OffrePostpayee")]
    public class OffrePostpayee:Offre
    {
        public float PrixHorsPack { get; set; }

        public String Id_Pack { get; set; }
        public Pack Pack { get; set; }
    }
}
