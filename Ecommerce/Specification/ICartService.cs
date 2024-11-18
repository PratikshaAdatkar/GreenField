using System;

using System.Collections.Generic;

using System.Linq;

using System.Text;

using System.Threading.Tasks;

using ECommerceEntities;

namespace Specification

{

    public interface ICartService

    {

        List<Item> GetAll();

        bool AddtoCart(Item item);

        bool RemovefromCart(int id);

        bool Clear();

    }

}

