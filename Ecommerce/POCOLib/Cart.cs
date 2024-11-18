using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceEntities
{
    [Serializable]
    public class Cart
    {
        public List<Item> items=new List<Item>();
    }
}
