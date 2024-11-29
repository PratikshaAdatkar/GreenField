using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceDALLib.DisConnectedDataAccess;
using ECommerceEntities;
namespace DisConnectedTestApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Product> products = DBManager.GetAll();

            foreach (Product product in products)

            {
                Console.WriteLine(product);
            }
 
/*Get by Id 

Product product = new Product();

int id = Convert.ToInt32(Console.ReadLine());

product = DBManager.GetById(id);

Console.WriteLine(product);

*/

            //delete

            /*int id = Convert.ToInt32(Console.ReadLine());

            DBManager.Delete(id);

            List<Product> products = DBManager.GetAll();

            foreach (Product product in products)

            {

                Console.WriteLine(product);

            }

            */



        }
    }
}
