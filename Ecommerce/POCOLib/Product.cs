using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POCO //id, unit price, quantity, title, description, image url
{
    [Serializable]
    public class Product
    {
        public int Id { get; set; }
        public int UnitPrice { get; set; }
        public int Quantity { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string image { get; set; }
    }
}