using System;

using System.Collections.Generic;

using System.Linq;

using System.Net;

using System.Net.Http;

using System.Web.Http;

using ECommerceEntities;

using Services;

using Specification;

namespace AuthWebAPI.Controllers

{

    public class ProductsController : ApiController

    {

        // GET api/values

        public IEnumerable<Product> Get()

        {

            IProductService productService = new ProductService();

            List<Product> products = productService.GetAll();

            return products;

        }

        // GET api/values/5

        public Product Get(int id)

        {

            IProductService productService = new ProductService();

            Product product = productService.Get(id);

            return product;

        }

        // POST api/values

        public void Post([FromBody] Product product)

        {

            IProductService productService = new ProductService();

            productService.Insert(product);

        }

        // PUT api/values/5

        public void Put([FromBody] Product product)

        {

            IProductService productService = new ProductService();

            productService.Update(product);

        }

        // DELETE api/values/5

        public void Delete(int id)

        {

            IProductService productService = new ProductService();

            productService.Delete(id);

        }

    }

}

