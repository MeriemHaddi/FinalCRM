using pi.domaine.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pi.data.MyConfiguration
{
    class CommentConfig : EntityTypeConfiguration<Comment>
    {
        public CommentConfig()
        {
            HasRequired(c => c.Post)
                 .WithMany(cat => cat.comments)
                 .HasForeignKey(c => c.PostId)
                 .WillCascadeOnDelete(true);
        }
    }
}
