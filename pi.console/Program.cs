using pi.domaine.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Service.Pattern;
using crm_pi.pi.data.Infrastructure;

namespace pi.console
{
    class Program
    {
        static void Main(string[] args)
        {
            IDatabaseFactory Factory = new DatabaseFactory();
           IUnitOfWork Uok = new UnitOfWork(Factory);
            IService<Client> chService = new Service <Client> (Uok);
            Client ch = new Client() { 
                Email ="meriem@gmail.com",
                Password="nidhal",
                UserName="nidhal",
                Name="nidhal",
                LastName="nidhal",
                Adress="tunis",
                PhoneNumber=96567790
            };
            Client ch2 = new Client()
            {
                Email = "mer@gmail.com",
                Password = "sabrine",
                UserName = "sabrine",
                Name = "sabrine",
                LastName = "sabrinee",
                Adress = "tunis",
                PhoneNumber = 925282028
            };
            chService.Add(ch2);
            chService.Commit();
            

           
            IService<Pack> chServicee = new Service<Pack>(Uok);

            //Product p1 = new Product() { Product_Name = "p1", Price = 200, Picture = "aaa.jpg" };
            //Product p2 = new Product() { Product_Name = "p2", Price = 210, Picture = "baaa.jpg" };
            //List<Product> lista = new List<Product>();
            //lista.Add(p1);
            //lista.Add(p2);

            //Pack pck = new Pack() { Id_Pack = "pack123", Titre = "aa", Description = "aaar", Periode_Engagement = 12, Prix = 100, listproduct = lista };
            //   var date1 = new DateTime(2008, 3, 1, 7, 0, 0);
            //   OffrePostpayee ch = new OffrePostpayee() { Id_Offre="4",Titre="aa", Description="ee",periode="summer",Prix=111,PrixHorsPack=100,date_debut=date1,date_fin=date1 };
            //chServicee.Add(pck);
            chServicee.Commit();
            chServicee.Dispose();
            //Console.WriteLine(pck.Id_Pack);
            Console.ReadKey();
        }
    }
    }

