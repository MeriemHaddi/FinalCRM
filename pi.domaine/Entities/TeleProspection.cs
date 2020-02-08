using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pi.domaine.Entities
{
    public class TeleProspection
    {
        [Key]
        public int TeleProspectionId { get; set; }
        public DateTime Date { get; set; }
        public String State { get; set; }
        public String Description { get; set; }
        public String Priority { get; set; }
        [ForeignKey("Client")]
        public int ClientId { get; set; }
        public virtual Client Client { get; set; }
        public virtual ICollection<Client> ClientC { get; set; }


    }
}
