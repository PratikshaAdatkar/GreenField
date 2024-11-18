using ECommerceEntities;

using Specification;

using System;

using System.Collections.Generic;

using System.Linq;

using System.Text;

using System.Threading.Tasks;

namespace Services

{

    public class CartService : ICartService

    {

        Cart thecart = null;

        public CartService(Cart cart)
        {

            this.thecart = cart;

        }

        public bool AddtoCart(Item item)

        {

            this.thecart.items.Add(item);

            return false;

            // throw new NotImplementedException();

        }

        public bool Clear()

        {

            this.thecart.items.Clear();

            return false;

            //throw new NotImplementedException();

        }

        public List<Item> GetAll()

        {

            return new List<Item>();

            //throw new NotImplementedException();

        }

        public bool RemovefromCart(int id)

        {

            this.thecart.items.RemoveAll((item) => (item.ProductId == id));

            return false;

            //throw new NotImplementedException();

        }

    }

}

