using crm_pi.pi.data.Infrastructure;
using pi.domaine.Entities;
using Service;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace pi.webb.Areas.administrator.Controllers
{
    public class MobilesController : Controller
    {
        // GET: administrator/Mobiles
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
        public ActionResult Mobiles()
        {
            return View();
        }
        public ActionResult Service()
        {
            return View();
        }
    }
}
