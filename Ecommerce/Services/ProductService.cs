using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BinaryDataRepositoryLib;
using POCO;
using Specification;
namespace Service
{
    public class ProductService : IProductService
    {
        //private List<Product> products;


        public bool Seeding()
        {
            bool status = false;
            List<Product> products = new List<Product>();
            products.Add(new Product { Id = 1, Name = "Gerbera", Description = "Wedding Flower", UnitPrice = 12, Quantity = 5000, image = "" });
            products.Add(new Product { Id = 2, Name = "Rose", Description = "Wedding Flower", UnitPrice = 12, Quantity = 5000, image = "" });
            products.Add(new Product { Id = 3, Name = "Lily", Description = "Wedding Flower", UnitPrice = 12, Quantity = 5000, image = "" });
            products.Add(new Product { Id = 4, Name = "Jasmin", Description = "Wedding Flower", UnitPrice = 12, Quantity = 5000, image = "" });
            products.Add(new Product { Id = 5, Name = "Lotus", Description = "Wedding Flower", UnitPrice = 12, Quantity = 5000, image = "" });
            IDataRepository repository = new BinaryRepository();
            status = repository.Serialize("products.dat", products);
            return status;
        }
        public bool Delete(int id)
        {
            Product theproduct = GetById(id);
            if (theproduct != null)
            {
                List<Product> allProducts = GetAll();
                allProducts.Remove(theproduct);
                IDataRepository repo = new BinaryRepository();
                repo.Serialize("products.dat", allProducts);
                return true;
            }
            return false;
        }

        public List<Product> GetAll()
        {
            /*products.Add(new Product { Id = 1, Name = "Gerbera", Description = "Wedding Flower", UnitPrice = 12, Quantity = 5000, Img = "/Images/Gerbera.jfif" });
            products.Add(new Product { Id = 2, Name = "Rose", Description = "Wedding Flower", UnitPrice = 12, Quantity = 5000, Img = "/Images/Rose.jfif" });
            products.Add(new Product { Id = 3, Name = "Lily", Description = "Wedding Flower", UnitPrice = 12, Quantity = 5000, Img = "/Images/Lily.jfif" });
            products.Add(new Product { Id = 4, Name = "Jasmin", Description = "Wedding Flower", UnitPrice = 12, Quantity = 5000, Img = "/Images/Jasmine.jfif" });
            products.Add(new Product { Id = 5, Name = "Lotus", Description = "Wedding Flower", UnitPrice = 12, Quantity = 5000, Img = "/Images/Lotus.jfif" });*/
            List<Product> products = new List<Product>();
            IDataRepository repository = new BinaryRepository();
            products = repository.Deserialize("products.dat");
            return products;
        }

        public Product GetById(int id)
        {
            //foreach (Product product in products)
            //{
            // if (product.Id == id)
            // {
            // return product;
            // }

            //}
            //return null;
            //return new Product { Id = 1, Name = "Gerbera", Description = "Wedding Flower", UnitPrice = 12, Quantity = 5000, Img = "/Images/Gerbera.jfif" };
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

        public bool Insert(Product Product)
        {
            //products.Add(product);
            List<Product> allProducts = GetAll();
            allProducts.Add(Product);
            IDataRepository repository = new BinaryRepository();
            repository.Serialize("products.dat", allProducts);
            return true;
        }

        public bool Update(Product productToBeUpdated)
        {
            Product theProduct = this.GetById(productToBeUpdated.Id);
            if (theProduct != null)
            {
                List<Product> allProducts = GetAll();
                allProducts.Remove(theProduct);
                IDataRepository repository = new BinaryRepository();
                repository.Serialize("products.dat", allProducts);
            }
            return true;
        }
    }
}

