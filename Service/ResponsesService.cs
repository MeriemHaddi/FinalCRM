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
    public class ResponsesService : Service<Response>, IResponsesService
    {
        private static IDatabaseFactory dbf = new DatabaseFactory();
        private static IUnitOfWork ut = new UnitOfWork(dbf);
        public Response GetResponseByIdClaim(int ClaimId)
        {
            return Get(c => c.idClaim.Equals(ClaimId));
        }
        public ResponsesService() : base(ut)
        {


        }
    }

}
