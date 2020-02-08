using pi.domaine.Entities;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IAgentService : IService<Agent>
    {
        IEnumerable<Agent> GetAgentByTitle(string title);
        IEnumerable<Agent> GetAgentByStore(int Id);
    }
}
