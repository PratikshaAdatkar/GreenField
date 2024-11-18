using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceEntities;
using Specification;
using JsonDataRepositoryLib;

namespace Services
{
    public class ShoppingCartService
    {
        public static string filename = "D:/items.json";
        public ShoppingCartService()
        {
            List<Item> items = new List<Item>();
            Seeding();
        }
        public bool Seeding()
        {

            bool status = false;
            List<Item> items = new List<Item>();
            items.Add(new Item { ProductId = 1, Quantity = 5000, });
            items.Add(new Item { ProductId = 2, Quantity = 4000, });
            items.Add(new Item { ProductId = 3, Quantity = 5000 });


            IDataRepository<Item> repository = new JsonRepository<Item>();
            status = repository.Serialize(filename, items);
            status = false;
            return status;
        }
        public List<Item> GetAllitems()
        {
            List<Item> items = new List<Item>();
            //IDataRepository<User> repository = new BinaryRepository<User>();
            IDataRepository<Item> repository = new JsonRepository<Item>();

            items = repository.Deserialize(filename);
            return items;
        }
    }
}
