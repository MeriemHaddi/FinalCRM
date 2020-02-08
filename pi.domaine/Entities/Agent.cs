using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pi.domaine.Entities
{
   public class Agent { 
   [Key]
    public int idAgent { get; set; }

    public string FName { get; set; }

    public string LName { get; set; }
    public string post { get; set; }
    public int tel { get; set; }
    public int? id_Shop { get; set; }

    [ForeignKey("id_Shop")]
    public virtual Shop Shop { get; set; }
    public string role { get; set; }
    public string password { get; set; }
}
}
