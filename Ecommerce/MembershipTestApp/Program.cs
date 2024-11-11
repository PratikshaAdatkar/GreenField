using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services;
using Specification;
using POCO;
using System.Net;
namespace MembershipTestApp
{
    internal class Program
    {
        static void Main(string[] args)
        {

            AuthService svc = new AuthService();
            svc.Seeding();
            string pass = "xyz";
            User u = new User { Id = 1, FirstName = "Pratiksha", LastName = "Adatkar", Email = "adatkarpratiksha14@gmail.com", ContactNo = "7410542126" };
            Console.WriteLine(svc.Register(u, pass));
            List<User> allUsers = svc.GetAllUsers();
            foreach (User user in allUsers)
            {
                Console.WriteLine(user.Id + " " + user.FirstName + " " + user.LastName);
            }

            List<Credential> allCredentials = svc.GetAllCredentials();
            foreach (Credential cred in allCredentials)
            {
                Console.WriteLine(cred.Email + " " + cred.Password);
            }

            string email;
            Console.WriteLine("\n Please enter email address");
            email = Console.ReadLine();
            string password;
            Console.WriteLine("\n Please enter password");
            password = Console.ReadLine();
            bool flag = svc.Login(email, password);
            if (flag == true)
            {
                Console.WriteLine("LOGIN SUCCESSFUL");
            }
            else
            {
                Console.WriteLine("LOGIN UNSUCCESSFUL");
            }
            Console.ReadLine();
            /*
            svc.Seeding("products.dat");
            List<Product> allProducts = svc.GetAll();
            foreach (Product product in allProducts)
            {
                Console.WriteLine(product.Name + " " + product.UnitPrice);
            }
            */
            Console.ReadLine();
        }
    }
}