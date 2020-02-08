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


namespace pi.webb.Areas.AdminSide.Controllers
{
    public class ShopController : Controller
    {

        // GET: AdminSide/Shop
        public ActionResult Index(String searchString)
        {

            var Shops = new List<Shop>();
            IDatabaseFactory Factory = new DatabaseFactory();
            IUnitOfWork Uok = new UnitOfWork(Factory);
            IService<Shop> chService = new Service<Shop>(Uok);
            ShopService s = new ShopService();
            IEnumerable<Shop> Shop = chService.GetAll().ToList();
            if (!String.IsNullOrEmpty(searchString))
            {
                Shop = s.GetShopsByTitle(searchString);
            }

            foreach (Shop sh in Shop)
            {
                Shops.Add(new Shop()
                {
                    id_Shop = sh.id_Shop,
                    shop_name = sh.shop_name,
                    Opening_Time = sh.Opening_Time,
                    closing_Time = sh.closing_Time,
                    Shop_Location = sh.Shop_Location,
                    altitude = sh.altitude,
                    longitude = sh.longitude,
                    Service = sh.Service





                });
            }

            return View(Shops);
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



        // GET: AdminSide/Shop/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: AdminSide/Shop/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_Shop,shop_name,Shop_Location,Opening_Time,closing_Time,altitude,longitude,Service")]Shop shop)
        {
            IDatabaseFactory Factory = new DatabaseFactory();
            IUnitOfWork Uok = new UnitOfWork(Factory);
            IService<Shop> chService = new Service<Shop>(Uok);
            if (ModelState.IsValid)
            {



                chService.Add(shop);
                chService.Commit();
                chService.Dispose();


                return RedirectToAction("Index");
            }

            return View(shop);
        }

        // GET: AdminSide/Shop/Edit/5
        public ActionResult Edit(int? id)
        {
            IDatabaseFactory Factory = new DatabaseFactory();
            IUnitOfWork Uok = new UnitOfWork(Factory);
            IService<Shop> chService = new Service<Shop>(Uok);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Shop s = chService.GetById((long)id);

            chService.Update(s);
            if (s == null)
            {
                return HttpNotFound();
            }
            return View(s);
        }

        // POST: AdminSide/Shop/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Shop sh)
        {
            IDatabaseFactory Factory = new DatabaseFactory();
            IUnitOfWork Uok = new UnitOfWork(Factory);
            IService<Shop> chService = new Service<Shop>(Uok);

            Shop s = chService.GetById((long)id);


            s.shop_name = sh.shop_name;
            s.Opening_Time = sh.Opening_Time;
            s.closing_Time = sh.closing_Time;
            s.Shop_Location = sh.Shop_Location;
            s.altitude = sh.altitude;
            s.longitude = sh.longitude;
            s.Service = sh.Service;


            chService.Update(s);
            chService.Commit();
            chService.Dispose();


            return RedirectToAction("Index");


        }

        // GET: AdminSide/Shop/Delete/5
        public ActionResult Delete(int id)
        {
            IDatabaseFactory Factory = new DatabaseFactory();
            IUnitOfWork Uok = new UnitOfWork(Factory);
            IService<Shop> chService = new Service<Shop>(Uok);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Shop shop = chService.GetById((long)id);
            if (shop == null)
            {
                return HttpNotFound();
            }
            return View(shop);
        }
        // POST: AdminSide/Shop/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            IDatabaseFactory Factory = new DatabaseFactory();
            IUnitOfWork Uok = new UnitOfWork(Factory);
            IService<Shop> chService = new Service<Shop>(Uok);
            Shop shop = chService.GetById((long)id);
            chService.Delete(shop);
            chService.Commit();
            return RedirectToAction("Index");
        }





        public ActionResult Dashboard(int id)
        {

            IDatabaseFactory Factory = new DatabaseFactory();
            IUnitOfWork Uok = new UnitOfWork(Factory);
            IService<Shop> chService = new Service<Shop>(Uok);

            Shop s = chService.GetById((long)id);
            ProductService p = new ProductService();
            IEnumerable<Product> list = p.GetProductByStore(id);

            List<String> repartions = new List<String>();
            var nbrvue = list.Select(x => x.nbrvue).Distinct();
            var Names = list.Select(x => x.Product_Name).Distinct();


            var rep = repartions;
            ViewBag.NBRVUE = nbrvue;
            ViewBag.REP = Names;

            return View();
        }






    }

}