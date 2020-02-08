using pi.domaine.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pi.data.MyConfiguration
{
    class Factdevconf : EntityTypeConfiguration<factdev>
    {
        public Factdevconf()
        {
            this.HasMany(c => c.lignes)
                    .WithOptional(e => e.factdev)
                    .HasForeignKey(e => e.FactdevId).WillCascadeOnDelete(true);

        }

    }
}
