using pi.domaine.Entities;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface ILignecmdService : IService<lignecmd>
    {

        IEnumerable<lignecmd> findProductUser(int iduser, int idprod);
        IEnumerable<lignecmd> findPanier(int iduser);
        IEnumerable<lignecmd> findDevis(int iduser,int devid);
        IEnumerable<lignecmd> findFacture(int iduser);
        IEnumerable<lignecmd> findBon(int bonid);
      IQueryable<IGrouping<int, lignecmd>> chart();


    }
}
