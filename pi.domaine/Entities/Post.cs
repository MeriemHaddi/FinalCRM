using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace pi.domaine.Entities
{
   public class Post
    {
        [Key]
        public int PostId { get; set; }
        public String Title { get; set; }
        public String Description { get; set; }
       public string Date { get; set; }
        public String State { get; set; }
        public int vue { get; set; }
        public int ClientId { get; set; }
        [ForeignKey("ClientId")]
        public virtual Client Client { get; set; }
        public string Picture { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }
       // public virtual ICollection<Reaction> Reaction { get; set; }
        public virtual ICollection<Comment> comments { get; set; }
        public virtual ICollection<Client> Clients { get; set; }


 }
}
