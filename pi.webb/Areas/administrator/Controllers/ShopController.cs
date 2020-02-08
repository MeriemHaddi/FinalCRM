using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Service;
using System.Web.Mvc;
using pi.domaine.Entities;
using System.Net;
using crm_pi.pi.data.Infrastructure;
using Service.Pattern;
using pi.data;

namespace pi.webb.Areas.administrator.Controllers
{
    public class ShopController : Controller
    {


        // GET: AdminSide/Shop
        public ActionResult Index()
        {


            IDatabaseFactory Factory = new DatabaseFactory();
            IUnitOfWork Uok = new UnitOfWork(Factory);
            IService<Shop> chService = new Service<Shop>(Uok);
            ShopService s = new ShopService();
            IEnumerable<Shop> Shop = chService.GetAll().ToList();



            return View(Shop);
        }

        // GET: AdminSide/Shop/Details/5
        public ActionResult Details(int id)
        {
            IDatabaseFactory Factory = new DatabaseFactory();
            IUnitOfWork Uok = new UnitOfWork(Factory);
            IService<Shop> chService = new Service<Shop>(Uok);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shop s = chService.GetById((long)id);
            ProductService p = new ProductService();
            IEnumerable<Product> l = p.GetProductByStore(id);

            if (s == null)
            {
                return HttpNotFound();
            }
            return View(l);

        }

        public ActionResult DetailsAgent(int id)
        {
            IDatabaseFactory Factory = new DatabaseFactory();
            IUnitOfWork Uok = new UnitOfWork(Factory);
            IService<Shop> chService = new Service<Shop>(Uok);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shop s = chService.GetById((long)id);
            AgentService p = new AgentService();
            IEnumerable<Agent> l = p.GetAgentByStore(id);

            if (s == null)
            {
                return HttpNotFound();
            }
            return View(l);

        }












    }
}