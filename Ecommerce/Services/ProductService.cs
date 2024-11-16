using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceEntities;
using Specification;
using BinaryDataRepositoryLib;

namespace Services
{
    public class ProductService : IProductService
    {
        public string filename = @"D:/products.dat";
        public ProductService() 
        { 
            List<Product> products = new List<Product>();
            Seeding();
        }
        public bool Seeding()
        {

            bool status = false;
            List<Product> products = new List<Product>();
            products.Add(new Product { Id = 1, Name = "gerbera", Description = "Wedding Flower", UnitPrice = 12, Quantity = 5000, image = "/Images/gerbera.jpg" });
            products.Add(new Product { Id = 2, Name = "rose", Description = "Wedding Flower", UnitPrice = 11, Quantity = 4000, image = "/Images/rose.jfif" });
            products.Add(new Product { Id = 3, Name = "lily", Description = "Wedding Flower", UnitPrice = 2, Quantity = 5000, image = "" });
            products.Add(new Product { Id = 4, Name = "jasmine", Description = "Wedding Flower", UnitPrice = 22, Quantity = 5000, image = "" });
            products.Add(new Product { Id = 5, Name = "lotus", Description = "Wedding Flower", UnitPrice = 19, Quantity = 3000, image = "" });
            IDataRepository<Product> repository = new BinaryRepository<Product>();
            status = repository.Serialize(filename, products);
            return status;
        }
        
        public bool Delete(int id)
        {
            Product theProduct = this.Get(id);
            if (theProduct != null)
            {
                List<Product> allProducts = GetAll();
                allProducts.Remove(theProduct);
                IDataRepository<Product> repo = new BinaryRepository<Product>();
                repo.Serialize("products.dat", allProducts);
                return true;
            }
            return false;
        }

        public Product Get(int id)
        {
            Product foundProduct = null;
            List<Product> products = GetAll();
            foreach (Product p in products)
            {
                if (p.Id == id)
                {
                    foundProduct = p;
                }
            }
            return foundProduct;
        }

        public List<Product> GetAll()
        {
            
            List<Product> products = new List<Product>();
            IDataRepository<Product> repository = new BinaryRepository<Product>();
            products = repository.Deserialize(filename);
            return products;
        }

        public bool Insert(Product Product)
        {
            List<Product> allProducts = GetAll();
            allProducts.Add(Product);
            IDataRepository<Product> repository = new BinaryRepository<Product>();
            repository.Serialize("products.dat", allProducts);
            return true;
        }

        public bool Update(Product productToBeUpdated)
        {
            Product theProduct = this.Get(productToBeUpdated.Id);
            if (theProduct != null)
            {
                List<Product> allProducts = GetAll();
                allProducts.Remove(theProduct);
                IDataRepository<Product> repository = new BinaryRepository<Product>();
                repository.Serialize("products.dat", allProducts);
            }
            return true;

        }
    }
}