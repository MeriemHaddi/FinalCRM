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
    public class ShopClientController : Controller
    {
        // GET: administrator/Shopclient
        public ActionResult Index()
        {
            IDatabaseFactory Factory = new DatabaseFactory();
            IUnitOfWork Uok = new UnitOfWork(Factory);
            IService<Shop> chService = new Service<Shop>(Uok);
            return View(chService.GetAll().ToList());
        }

        // GET: administrator/Shopclient/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: administrator/Shopclient/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: administrator/Shopclient/Create
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

        // GET: administrator/Shopclient/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: administrator/Shopclient/Edit/5
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

        // GET: administrator/Shopclient/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: administrator/Shopclient/Delete/5
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
