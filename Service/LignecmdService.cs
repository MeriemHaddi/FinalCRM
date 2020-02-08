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
  public  class LignecmdService : Service<lignecmd>, ILignecmdService
    {
        static IDatabaseFactory Factory = new DatabaseFactory();
        static IUnitOfWork Uok = new UnitOfWork(Factory);
        public LignecmdService() : base(Uok)
        {
        }

        public IEnumerable<lignecmd> findPanier(int iduser)
        {
            return (from lc in Factory.DataContext.Lignecmd
                    where lc.UserId == iduser
                    where lc.etat == 0                  
                    select lc);
        }

        public IEnumerable<lignecmd> findProductUser(int iduser, int idprod)
        {
            return (from lc in Factory.DataContext.Lignecmd                 
                    where lc.UserId == iduser where lc.etat==0 where lc.ProductId== idprod
                    select lc);
        }

        public IEnumerable<lignecmd> findDevis(int iduser,int devid)
        {
            return (from lc in Factory.DataContext.Lignecmd
                    where lc.UserId == iduser
                    where lc.FactdevId == devid
                    select lc);
        }

        public IEnumerable<lignecmd> findFacture(int iduser)
        {
            return (from lc in Factory.DataContext.Lignecmd
                   
                    where lc.FactdevId ==iduser
                    select lc);
        }

        public IQueryable<IGrouping<int, lignecmd>> chart()
        {

            var result = from lc in Factory.DataContext.Lignecmd
                         group lc by lc.ProductId
                         ;

            return result;
            //return (from lc in Factory.DataContext.Lignecmd
            //        group lc by lc.ProductId
            //     //   where lc.FactdevId == iduser
            //        select lc);
        }




        public IEnumerable<lignecmd> findBon(int bonid)
        {
            return (from lc in Factory.DataContext.Lignecmd       
                    where lc.BoncmdId == bonid 
                    select lc);
        }


    }
}
