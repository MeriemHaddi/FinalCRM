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
    public class ProductController : Controller
    {


        IDatabaseFactory Factory;
        IUnitOfWork Uok;

        IService<Product> servProduct;
        IService<User> servuser;

        public ProductController()
        {
            Factory = new DatabaseFactory();
            Uok = new UnitOfWork(Factory);
            servProduct = new Service<Product>(Uok);
            servuser = new Service<User>(Uok);
        }

        public ActionResult afu()
        {
            List<User> hotels = servuser.GetAll().ToList();
            return View(hotels);
        }


        // GET: administrator/Product
        public ActionResult Index()
        {
            List<Product> hotels = servProduct.GetAll().ToList();
            return View(hotels);
        }

        // GET: administrator/Product/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: administrator/Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: administrator/Product/Create
        [HttpPost]
        public ActionResult Create(Product p,FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                servProduct.Add(p);
                servProduct.Commit();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: administrator/Product/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: administrator/Product/Edit/5
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

        // GET: administrator/Product/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: administrator/Product/Delete/5
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
