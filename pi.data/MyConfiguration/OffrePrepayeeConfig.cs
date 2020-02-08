using pi.domaine.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pi.data.MyConfiguration
{
    public class OffrePrepayeeConfig : EntityTypeConfiguration<OffrePrepayee>
    {
        public OffrePrepayeeConfig()
        {
            Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("OffrePrepayee");
            });
        }
    }
}
