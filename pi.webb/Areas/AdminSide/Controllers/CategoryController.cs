using crm_pi.pi.data.Infrastructure;
using pi.domaine.Entities;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace pi.webb.Areas.AdminSide.Controllers
{
    public class CategoryController : Controller
    {

        // GET: AdminSide/Category
        public ActionResult _Category()
        {
            IDatabaseFactory Factory = new DatabaseFactory();
            IUnitOfWork Uok = new UnitOfWork(Factory);
            IService<Product> chService = new Service<Product>(Uok);
            IService<CategoryProduct> Cat = new Service<CategoryProduct>(Uok);
            ViewBag.Categories = Cat.GetAll().ToList();

            return PartialView("_Category");
        }

        // GET: AdminSide/Category/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AdminSide/Category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminSide/Category/Create
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

        // GET: AdminSide/Category/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AdminSide/Category/Edit/5
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

        // GET: AdminSide/Category/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AdminSide/Category/Delete/5
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
