using pi.domaine.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pi.data.MyConfiguration
{
    public class PackConfig : EntityTypeConfiguration<Pack>
    {
        public PackConfig()
        {
            /* HasMany(pck => pck.listproduct)
                 .WithRequired(p => p.pack)
                     .HasForeignKey(p => p.Id_Pack)
                ;*/


            HasMany(pck => pck.listoffre)
           .WithRequired(o => o.Pack)
               .HasForeignKey(o => o.Id_Pack)
          ;

        }

    }
}
