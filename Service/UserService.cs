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
    public class UserService : Service<User>, IUserService
    {


        static IDatabaseFactory Factory = new DatabaseFactory();
        static IUnitOfWork Uok = new UnitOfWork(Factory);
        public UserService() : base(Uok)
        {
        }

        public IEnumerable<User> byaddress(string address)
        {
            return (from lc in Factory.DataContext.User          
                    where lc.Adress == address
                    select lc);
        }
    }
}
