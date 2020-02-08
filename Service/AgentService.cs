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
    public class AgentService : Service<Agent>, IAgentService
    {
        static IDatabaseFactory Factory = new DatabaseFactory();
        static IUnitOfWork Uok = new UnitOfWork(Factory);
        public AgentService() : base(Uok)
        {
        }

        public IEnumerable<Agent> GetAgentByTitle(string title)
        {
            return GetMany(f => f.FName.Contains(title));
        }


        public IEnumerable<Agent> GetAgentByStore(int Id)
        {

            return GetMany(ch => ch.id_Shop == Id);
        }



    }
}
