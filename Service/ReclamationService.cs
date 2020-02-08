using crm_pi.pi.data.Infrastructure;
using pi.domaine.Entities;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static pi.domaine.Entities.Reclamation;

namespace Service
{
    public class ReclamationService : Service<Reclamation>, IReclamationService
    {

        private static IDatabaseFactory dbf = new DatabaseFactory();
        private static IUnitOfWork ut = new UnitOfWork(dbf);
        public ReclamationService() : base(ut)
        {


        }

        public IEnumerable<Reclamation> GetReclamationbyIdUser(int UserId)
        {

            return GetMany(c => c.UserId.Equals(UserId));
        }


        public IEnumerable<Reclamation> GetReclamationNotTreated(string status)
        {

            return GetMany(c => c.etat.Equals(status));
        }


        public IEnumerable<Reclamation> GetReclamationbytype(TypeReclamation type)
        {

            return GetMany(c => c.TypeReclamation == type);
        }

        public IEnumerable<Reclamation> GetReclamationbysatis(enumSatisfaction type)
        {

            return GetMany(c => c.SatisfactionEnum == type);
        }


        public IEnumerable<Reclamation> searchByName(string key)
        {
            var data = from reclamation in dbf.DataContext.Reclamation
                       where reclamation.Titre.StartsWith(key)
                       select reclamation;
            return data;
        }

        public IEnumerable<Reclamation> searchByContent(string key)
        {
            var data = from reclamation in dbf.DataContext.Reclamation
                       where reclamation.contenu.Contains(key)
                       select reclamation;
            return data;
        }

    }
    
}
