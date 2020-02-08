using pi.domaine.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pi.data.MyConfiguration
{
    class Boncmdconf : EntityTypeConfiguration<Boncmd>
    {

        public Boncmdconf()
        {
            this.HasMany(c => c.lignes)
                    .WithOptional(e => e.boncmd)
                    .HasForeignKey(e => e.BoncmdId).WillCascadeOnDelete(true);

        }


    }
}
