using crm_pi.pi.data.Infrastructure;
using pi.data;
using pi.domaine.Entities;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ProductService : Service<Product>, IProductService
    {
        static IDatabaseFactory Factory = new DatabaseFactory();
        static IUnitOfWork Uok = new UnitOfWork(Factory);
        public ProductService() : base(Uok)
        {
        }
        public IEnumerable<Product> GetProductByStore(int Id)
        {

            return GetMany(ch => ch.id_Shop == Id);
        }
        public IEnumerable<Product> GetProductByTitle(string title)
        {
            return GetMany(f => f.Product_Name.Contains(title));
        }
        public List<Product> GetProducts(List<Product> v)
        {

            return v;
        }




        public Context db = new Context();



        public IEnumerable<Product> max()

        {

            var products = new List<Product>();
            var Array = db.Product.SqlQuery("SELECT * FROM [dbo].[Products]");


            foreach (var a in Array.OrderByDescending(s => s.nbrvue))
            {

                products.Add(a);

            }
            return products;
        }


    }
}
