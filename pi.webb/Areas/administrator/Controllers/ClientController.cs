using crm_pi.pi.data.Infrastructure;
using pi.domaine.Entities;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace pi.webb.Areas.administrator.Controllers
{
    public class ClientController : Controller
    {
        IDatabaseFactory Factory = new DatabaseFactory();
       
        // GET: administrator/Client
        public ActionResult Index()
        {

            IUnitOfWork Uok = new UnitOfWork(Factory);
            IService<OffrePostpayee> serOffre = new Service<OffrePostpayee>(Uok);
            IEnumerable<OffrePostpayee> lista = new List<OffrePostpayee>();
            lista = serOffre.GetAll().Take(3);

            return View(lista);

        }

        // GET: administrator/Client/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: administrator/Client/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: administrator/Client/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: administrator/Client/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: administrator/Client/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: administrator/Client/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: administrator/Client/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
