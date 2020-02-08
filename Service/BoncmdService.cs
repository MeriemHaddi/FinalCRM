using crm_pi.pi.data.Infrastructure;
using pi.domaine.Entities;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class BoncmdService : Service<Boncmd>, IBoncmdService
    {
        static IDatabaseFactory Factory = new DatabaseFactory();
        static IUnitOfWork Uok = new UnitOfWork(Factory);
        public BoncmdService() : base(Uok)
        {
        }


        public IEnumerable<Boncmd> bonadmin()
        {
            return (from lc in Factory.DataContext.Boncmds        
                    where lc.etat == 0
                    select lc);
        }
    }
}
