using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POCO;

namespace Catalog
{
    public interface IProductService
    {
        List<Product> GetAll();//generic class symbol<> //abstract method
        Product Get(int id);
        bool Insert(Product product);
        bool Update(Product product);
        bool Delete(int productid);
    }
}