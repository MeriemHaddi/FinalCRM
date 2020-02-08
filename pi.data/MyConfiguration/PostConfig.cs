using pi.domaine.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pi.data.MyConfiguration
{
    class PostConfig : EntityTypeConfiguration<Post>
    {
        public PostConfig()
        {
            HasRequired(c => c.Client)
                 .WithMany(cat => cat.Post)
                 .HasForeignKey(c => c.ClientId)
                 .WillCascadeOnDelete(false);
        }
    
    }
}
