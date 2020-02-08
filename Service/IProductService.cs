using pi.domaine.Entities;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IProductService : IService<Product>
    {
        IEnumerable<Product> GetProductByStore(int Id);
        IEnumerable<Product> GetProductByTitle(string title);
    }
}
