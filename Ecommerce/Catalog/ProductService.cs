

using System;

using System.Collections.Generic;

using System.Linq;

using System.Text;

using System.Threading.Tasks;

using POCO;

using Specification;

using BinaryDataRepositoryLib;

namespace Catalog

{

    public class ProductService : IProductService

    {

        private List<Product> products;
 
        public ProductService() 

        {

            this.products = new List<Product>();

        }

        public bool Delete(int id)

        {

           Product product=this.GetById(id);

            products.Remove(product);

            return true;

        }

        public Product Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()

        {

           List<Product> products = new List<Product>();
            IDataRepository repository = new BinaryRepository();
            return products;

        }
 
        public Product GetById(int id)

        {

            //foreach (Product product in products)

            //{

            //    if (product.Id == id)

            //    {

            //        return product;

            //    }
 
            //}

            //return null;

            return new Product { Id = 1, Name = "Gerbera", Description = "Wedding Flower", UnitPrice = 12, Quantity = 5000, image = "/Images/Gerbera.jfif" };

        }
 
        public bool Insert(Product product)

        {

            products.Add(product);

            return true;

        }
 
        public bool Update(Product product)

        {

            Product product1=GetById(product.Id);

            products.Remove(product1); 

            products.Add(product);

            return true;

        }

    }

}

 