using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pi.domaine.Entities
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }
        public DateTime date { get; set; }
        public int ClientId { get; set; }
        [ForeignKey("ClientId")]
        public virtual Client Client { get; set; }
        [ForeignKey("Post")]
        public int PostId { get; set; }
        public virtual Post Post { get; set; }
        public String Text { get; set; }
        public int Rating { get; set; }
        public virtual ICollection<Client> Clients { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
        public virtual IEnumerable<Client> Cl { get; set; }

    }
}
