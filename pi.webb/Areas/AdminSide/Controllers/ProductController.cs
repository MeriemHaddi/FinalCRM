using crm_pi.pi.data.Infrastructure;
using pi.data;
using pi.domaine.Entities;
using Service;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Services;
using System.Web.Services;

namespace pi.webb.Areas.AdminSide.Controllers
{
    public class ProductController : Controller
    {
        private Context db = new Context();
        HttpPostedFileBase file;
        // GET: AdminSide/Product

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public ActionResult Index(String searchString)

        {

            var products = new List<Product>();
            IDatabaseFactory Factory = new DatabaseFactory();
            IUnitOfWork Uok = new UnitOfWork(Factory);
            IService<Product> chService = new Service<Product>(Uok);
            ProductService p = new ProductService();
            IEnumerable<Product> productDomain = chService.GetAll().ToList();
            if (!String.IsNullOrEmpty(searchString))
            {
                productDomain = p.GetProductByTitle(searchString);
            }

            foreach (Product pdomaine in productDomain)
            {
                products.Add(new Product()
                {
                    idProduct = pdomaine.idProduct,
                    Product_Name = pdomaine.Product_Name,
                    id_Category = pdomaine.id_Category,
                    Picture = pdomaine.Picture,
                    Price = pdomaine.Price,
                    Quantity = pdomaine.Quantity,
                    In_Quantity = pdomaine.In_Quantity,
                    Out_Quantity = pdomaine.Out_Quantity,
                    Description = pdomaine.Description,
                    id_Shop = pdomaine.id_Shop,
                    Shop = pdomaine.Shop,
                    CategoryProduct = pdomaine.CategoryProduct




                });
            }


            return View(products);

        }
        public ActionResult Category(int id_Category)

        {
            IDatabaseFactory Factory = new DatabaseFactory();
            IUnitOfWork Uok = new UnitOfWork(Factory);

            IService<CategoryProduct> Cat = new Service<CategoryProduct>(Uok);
            ViewBag.Category = Cat.GetById(id_Category);


            return View("Category");
        }
        // GET: AdminSide/Product/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AdminSide/Product/Create
        public ActionResult Create()
        {
            ViewBag.Shop = db.Shop;
            ViewBag.Category = db.CategoryProducts;
            return View();
        }

        // POST: AdminSide/Product/Create
        [HttpPost]

        public ActionResult Create(Product product, HttpPostedFileBase file)
        {
            IDatabaseFactory Factory = new DatabaseFactory();
            IUnitOfWork Uok = new UnitOfWork(Factory);
            IService<Product> chServic = new Service<Product>(Uok);



            if (!ModelState.IsValid || file.ContentLength == 0)
            {
                RedirectToAction("Create");
            }
            Product productdomaine = new Product()
            {
                Product_Name = product.Product_Name,
                id_Category = product.id_Category,
                Picture = file.FileName,
                Price = product.Price,
                Quantity = product.Quantity,
                In_Quantity = product.In_Quantity,
                Out_Quantity = product.Out_Quantity,
                Description = product.Description,
                id_Shop = product.id_Shop,



            };


            chServic.Add(productdomaine);
            chServic.Commit();
            var fileName = "";
            if (file.ContentLength > 0)
            {
                fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/Content/Uploads/"), fileName);
                file.SaveAs(path);
            }


            return RedirectToAction("Index");



        }

        // GET: AdminSide/Product/Edit/5
        public ActionResult Edit(int? id, Product p)
        {
            IDatabaseFactory Factory = new DatabaseFactory();
            IUnitOfWork Uok = new UnitOfWork(Factory);
            IService<Product> chService = new Service<Product>(Uok);
            ViewBag.Shop = db.Shop;
            ViewBag.Category = db.CategoryProducts;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Product product = chService.GetById((long)id);

            chService.Update(product);

            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: AdminSide/Product/Edit/5
        [HttpPost]

        public ActionResult Edit([Bind(Include = "idProduct,Product_Name,Description,Price,Picture,id_Shop,In_Quantity,Out_Quantity,Quantity,id_Category")] Product product, HttpPostedFileBase file, int id)
        {
            IDatabaseFactory Factory = new DatabaseFactory();
            IUnitOfWork Uok = new UnitOfWork(Factory);
            IService<Product> chService = new Service<Product>(Uok);

            if (!ModelState.IsValid)
            {
                RedirectToAction("Edit");
            }

            Product p = chService.GetById((long)id);

            p.Product_Name = product.Product_Name;
            p.id_Category = product.id_Category;
            p.Picture = file.FileName;
            p.Price = product.Price;
            p.Quantity = product.Quantity;
            p.In_Quantity = product.In_Quantity;
            p.Out_Quantity = product.Out_Quantity;
            p.Description = product.Description;
            p.id_Shop = product.id_Shop;


            var fileName = "";

            fileName = Path.GetFileName(file.FileName);
            var path = Path.Combine(Server.MapPath("~/Content/Uploads/"), fileName);
            file.SaveAs(path);



            chService.Update(p);
            chService.Commit();


            return RedirectToAction("Index");

        }
        // GET: AdminSide/Product/Delete/5
        public ActionResult Delete(int? id)
        {
            IDatabaseFactory Factory = new DatabaseFactory();
            IUnitOfWork Uok = new UnitOfWork(Factory);
            IService<Product> chService = new Service<Product>(Uok);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Product product = chService.GetById((long)id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: AdminSide/Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            IDatabaseFactory Factory = new DatabaseFactory();
            IUnitOfWork Uok = new UnitOfWork(Factory);
            IService<Product> chService = new Service<Product>(Uok);
            Product product = chService.GetById((long)id);
            chService.Delete(product);
            chService.Commit();
            return RedirectToAction("Index");
        }

        public ActionResult Dashboard()
        {
            IDatabaseFactory Factory = new DatabaseFactory();
            IUnitOfWork Uok = new UnitOfWork(Factory);
            IService<Product> chService = new Service<Product>(Uok);
            List<Product> list = chService.GetAll().ToList();
            List<String> repartions = new List<String>();
            var nbrvue = list.Select(x => x.nbrvue).Distinct();
            var Names = list.Select(x => x.Product_Name).Distinct();


            var rep = repartions;
            ViewBag.NBRVUE = nbrvue;
            ViewBag.REP = Names;

            return View();
        }


        public ActionResult ProductDescription(int id)
        {
            IDatabaseFactory Factory = new DatabaseFactory();
            IUnitOfWork Uok = new UnitOfWork(Factory);
            IService<Product> chService = new Service<Product>(Uok);

            Product p = chService.GetById((long)id);

            return View(p);

        }




    }
}