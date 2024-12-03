using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catalog.Entities;

namespace Catalog.Repositories
{
    internal interface IDataRepository
    {
        List<Product> GetAll();               //abstract method
        Product GetById(int id);
        bool Insert(Product product);
        bool Update(Product product);
        bool Delete(int id);
    }
}
