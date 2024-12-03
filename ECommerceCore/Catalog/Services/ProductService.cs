using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catalog.Entities;
using Catalog.Repositories.Connected;

namespace Catalog.Services
{
    public class ProductService : IProductService
    {
        public bool Delete(int id)
        {
            ProductRepository.Delete(id);

            return false;
        }

        public Product Get(int id)
        {
            Product foundProduct = null;

            return foundProduct;
        }

        public List<Product> GetAll()
        {
            List<Product> products = ProductRepository.GetAll();
            return products;
        }

        public Product GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(Product product)
        {
            List<Product> allProducts = GetAll();

            return false;
        }

        public bool Update(Product productTobeUpdated)
        {
            Product theProduct = Get(productTobeUpdated.Id);

            return false;
        }
    }

}
