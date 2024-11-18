using System;

using System.Collections.Generic;

using System.Linq;

using System.Text;

using System.Threading.Tasks;

using ECommerceEntities;

using Specification;

using JsonDataRepositoryLib;

namespace ECommerceServices

{

    public class ProductService : IProductService

    { 
       
        public string fileadress = @"D:/productslist.json";

        public bool Seeding()

        {

            // Sample Data

            bool status = false;

            List<Product> products = new List<Product>();

            products.Add(new Product { Id = 1, Name = "Jasmine", Description = "Fragnance", UnitPrice = 32, Quantity = 30, image = "/images/Jasmine.jpg" });

            products.Add(new Product { Id = 2,  Name = "Rose", Description = "Love", UnitPrice = 12, Quantity = 80, image = "/images/Rose.jpg" });

            products.Add(new Product { Id = 4, Name = "Lotus", Description = "Worship", UnitPrice = 40, Quantity = 70, image = "/images/Lotus.jpg" });

            products.Add(new Product { Id = 7, Name = "Lily", Description = "Beautiful", UnitPrice = 20, Quantity = 100, image = "/images/Lily.jpg" });

            ///IDataRepository<Product> repo = new JSONRepository<Product>();


            IDataRepository<Product> repo = new JsonRepository<Product>();
            
            status = repo.Serialize(fileadress, products);

            return status;

        }


        private List<Product> productslist;

        public ProductService()

        {

            productslist = new List<Product>();

        }

        public bool Delete(int id)

        {

            Product theProduct = GetById(id);

            if (theProduct != null)

            {

                List<Product> allproducts = GetAll();

                //allproducts.RemoveAll (p=>p.Id==id);

                allproducts = allproducts.FindAll((x) => x.Id != id);

                IDataRepository<Product> repo = new JsonRepository<Product>();

                repo.Serialize(fileadress, allproducts);

                return true;


            }

            return false;

            /*Product theproduct =this.Get(id);

            this.productslist.Remove(theproduct);

            return true;

           // throw new NotImplementedException();*/

        }

       /* public Product GetbyId(int id)

        {

            Product foundProduct = null;

            List<Product> products = GetAll();

            foreach (Product p in products)

            {
                if (p.Id == id) { foundProduct = p; }

            }

            return foundProduct;

            //throw new NotImplementedException();

        }*/

        public List<Product> GetAll()

        {

            //Deserialization

            List<Product> products = new List<Product>();

            IDataRepository<Product> repository = new JsonRepository<Product>();

            products = repository.Deserialize(fileadress);

            /*  products.Add(new Product { Id = 1, Title = "Jasmine", Description = "Fragnance", Unitprice = 32, Quantity = 30, Image = "/images/Jasmine.jpg" });

              products.Add(new Product { Id = 2, Title = "Rose", Description = "Love", Unitprice = 12, Quantity = 80, Image = "/images/Rose.jpg" });

              products.Add(new Product { Id = 4, Title = "Lotus", Description = "Worship", Unitprice = 40, Quantity = 70, Image = "/images/Lotus.jpg" });

              products.Add(new Product { Id = 1, Title = "Lily", Description = "Beautiful", Unitprice = 20, Quantity = 100, Image = "/images/Lily.jpg" });

             */

            return products;

            //throw new NotImplementedException();

        }

        public bool Insert(Product product)

        {

            //this.productslist.Add(product);

            // return true;

            //throw new NotImplementedException();

            List<Product> allProducts = GetAll();

            allProducts.Add(product);

            IDataRepository<Product> repository = new JsonRepository<Product>();

            repository.Serialize(fileadress, allProducts);

            return true;

        }

        public bool Update(Product productToBeUpdated)

        {

            Product theProduct = this.GetById(productToBeUpdated.Id);

            if (theProduct != null)

            {

                List<Product> allProducts = GetAll();

                allProducts.Remove(theProduct);

                allProducts.Add(productToBeUpdated);

                IDataRepository<Product> repository = new JsonRepository<Product>();

                repository.Serialize(fileadress, allProducts);

            }

            return true;

        }

        public Product GetById(int id)
        {
            Product foundProduct = null;

            List<Product> products = GetAll();

            foreach (Product p in products)

            {
                if (p.Id == id) { foundProduct = p; }

            }

            return foundProduct;

            //throw new NotImplementedException();

        }
    }

}

