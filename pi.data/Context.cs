using pi.data.MyConfiguration;
using pi.domaine.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pi.data
{
   public  class Context :DbContext
    {
  
        public Context (){}
        public DbSet<Product> Product { get; set; }
        public DbSet<Shop> Shop{ get; set; }
        public DbSet<Stock> Stock { get; set; }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<Comment> Comment { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Offre> Offre{ get; set; }
        public DbSet<OffrePostpayee> OffrePostpayee { get; set; }
        public DbSet<OffrePrepayee> OffrePrepayee { get; set; }
        public DbSet<Pack> Pack { get; set; }
        public DbSet<PointOfSale> PointOfSale { get; set; }
        public DbSet<Post> Post { get; set; }
       // public DbSet<Reaction> Reaction { get; set; }
        public DbSet<Reclamation> Reclamation { get; set; }
        public DbSet<Resources> Resources { get; set; }
        public DbSet<TeleProspection> TeleProspection { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<lignecmd>Lignecmd { get; set; }
        public DbSet<factdev> factdev { get; set; }
        public DbSet<Conversation> Conversations { get; set; }
        public DbSet<Usere> Useres { get; set; }
        public DbSet<Response> Responses { get; set; }
        public DbSet<Agent> Agents { get; set; }
        public DbSet<CategoryProduct> CategoryProducts { get; set; }
        public DbSet<Boncmd> Boncmds { get; set; }
        public object DeleteBehavior { get; private set; }


        protected override void OnModelCreating(DbModelBuilder DBM)
        {
           DBM.Configurations.Add(new CommentConfig());
           //DBM.Configurations.Add(new ReactionConfig());
            
          
            DBM.Configurations.Add(new PostConfig());
            DBM.Configurations.Add(new OffrePostpayeeConfig());
            DBM.Configurations.Add(new OffrePrepayeeConfig());
            DBM.Configurations.Add(new PackConfig());
            DBM.Configurations.Add(new Factdevconf());
            DBM.Configurations.Add(new Boncmdconf());



        }

    }
}
