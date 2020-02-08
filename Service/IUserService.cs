using pi.domaine.Entities;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IUserService : IService<User>
    {
        IEnumerable<User> byaddress(string address);
    }
}
