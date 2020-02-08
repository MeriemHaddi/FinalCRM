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
    public class ShopService : Service<Shop>, IShopService
    {
        static IDatabaseFactory Factory = new DatabaseFactory();
        static IUnitOfWork Uok = new UnitOfWork(Factory);
        public ShopService() : base(Uok)
        { }

        public IEnumerable<Shop> GetShopsByTitle(string title)
        {
            return GetMany(f => f.shop_name.Contains(title));
        }



    }
}
