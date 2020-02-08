using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pi.domaine.Entities
{
    public class Response { 
    [Key]
    public int IdResponse { get; set; }
    public DateTime ResponseDate { get; set; }
    public int IdUser { get; set; }
    public User User { get; set; }
    [Required]
    public string Content { get; set; }
    public DateTime Date { get; set; }
    public int idClaim { get; set; }
}
}
