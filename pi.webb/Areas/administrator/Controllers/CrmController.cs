using crm_pi.pi.data.Infrastructure;
using pi.domaine.Entities;
using Service;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;


namespace pi.webb.Areas.administrator.Controllers
{
    public class CrmController : Controller
    {
        // GET: administrator/Crm
        public ActionResult Index()
        {
            return View();
        }

        //appell au fnct de nbr de vue

        public ActionResult Mobiles(String searchString)

        {

            var products = new List<Product>();
            var prod = new List<Product>();
            IDatabaseFactory Factory = new DatabaseFactory();
            IUnitOfWork Uok = new UnitOfWork(Factory);
            IService<Product> chService = new Service<Product>(Uok);
            ProductService p = new ProductService();
            List<Product> productDomain = chService.GetAll().ToList();

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
                    CategoryProduct = pdomaine.CategoryProduct,
                    nbrvue = pdomaine.nbrvue




                });



            }

            Product d = new Product();



            return View(p.max());

        }


        //filtre


        // GET: administrator/Crm/Category
        public ActionResult Category(int id_Category)

        {
            IDatabaseFactory Factory = new DatabaseFactory();
            IUnitOfWork Uok = new UnitOfWork(Factory);

            IService<CategoryProduct> Cat = new Service<CategoryProduct>(Uok);
            ViewBag.Category = Cat.GetById(id_Category);


            return View("Category");
        }


        public ActionResult Mobilehs(String searchString)

        {

            var products = new List<Product>();
            var prod = new List<Product>();
            IDatabaseFactory Factory = new DatabaseFactory();
            IUnitOfWork Uok = new UnitOfWork(Factory);
            IService<Product> chService = new Service<Product>(Uok);
            ProductService p = new ProductService();
            List<Product> productDomain = chService.GetAll().ToList();

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
                    CategoryProduct = pdomaine.CategoryProduct,
                    nbrvue = pdomaine.nbrvue




                });



            }

            Product d = new Product();



            return View(p.max());

        }
        public ActionResult Service()
        {
            return View();
        }



        //au bas de page desc most view product

        public ActionResult products()
        {
            IDatabaseFactory Factory = new DatabaseFactory();
            IUnitOfWork Uok = new UnitOfWork(Factory);
            IService<Product> chService = new Service<Product>(Uok);
            ProductService p = new ProductService();
            ViewBag.products = p.max().Take(4);

            return PartialView("products");
        }




        public ActionResult QuantitytoUpdate(int id)
        {
            IDatabaseFactory Factory = new DatabaseFactory();
            IUnitOfWork Uok = new UnitOfWork(Factory);
            IService<Product> chService = new Service<Product>(Uok);

            Product p = chService.GetById((long)id);


            if (p.Quantity == p.Quantity)
            {
                p.Quantity = p.Quantity - p.Out_Quantity;

                //jbService.Update(app);

                chService.Commit();

                return View(p);
            }
            return View(p);

        }


        //Quantity to reserve by client
        public ActionResult Quantity(int id, Product prod)
        {

            if (ModelState.IsValid)

            {
                IDatabaseFactory Factory = new DatabaseFactory();
                IUnitOfWork Uok = new UnitOfWork(Factory);
                IService<Product> chService = new Service<Product>(Uok);

                Product p = chService.GetById((long)id);




                if (prod.Out_Quantity > p.Quantity)
                {
                    return RedirectToAction("Sorry");

                }


                p.Out_Quantity = prod.Out_Quantity;
                p.Quantity = p.Quantity - p.Out_Quantity;

                chService.Commit();




            }




            return View(prod);



        }

        // TODO: Add delete logic here   //update nbr de vue 
        public ActionResult ProductDescription(int id)
        {
            IDatabaseFactory Factory = new DatabaseFactory();
            IUnitOfWork Uok = new UnitOfWork(Factory);
            IService<Product> chService = new Service<Product>(Uok);

            Product p = chService.GetById((long)id);
            if (p.nbrvue == p.nbrvue)
            {
                p.nbrvue = p.nbrvue + 1;

                //jbService.Update(app);

                chService.Commit();

                return View(p);
            }
            return View(p);

        }





        public ActionResult Sorry()
        {
            return View();
        }

    }
}