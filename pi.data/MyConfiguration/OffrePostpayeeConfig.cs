using pi.domaine.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pi.data.MyConfiguration
{
    public class OffrePostpayeeConfig : EntityTypeConfiguration<OffrePostpayee>
    {
        public OffrePostpayeeConfig()
        {
            Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("OffrePostpayee");
            });
        }
    }
}
