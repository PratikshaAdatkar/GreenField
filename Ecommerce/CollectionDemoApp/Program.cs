using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CollectionDemoApp
{
    //containted class
    public class book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
    }

    //container class
    public class Library
    {
        private List<book> books = null;
        private string location;
        public Library(string location)
        {
            books = new List<book>();
            books.Add(new book { Id = 1, Title = "Inside C#", Description = " best seller", Author = " Steve Jobs" });
            books.Add(new book { Id = 2, Title = "Inside Cpp", Description = " best seller", Author = " Steve Jobs" });
            books.Add(new book { Id = 3, Title = "Inside Java", Description = " best seller", Author = " Steve Jobs" });
            this.location = location;
        }
    
        //property
        public string Location {

            get { return this.location; }
            set { this.location = value; }
        }
        public book this[int index]
        {
            get { return books[index]; }
            set { books[index] = value; }
        }


    }

    
    internal class Program
    {
        static void Main(string[] args)
        {
            //library pictlib = new library();
            string[] names = { "Sachin", "Rahul","Virat","Dhoni" };
            string player1 = names[0];
            string player2 = names[1];

            Library pccoelib= new Library("Akurdi");
            book thebook = pccoelib[2];
          
            Console.WriteLine(thebook.Title+ " "+thebook.Description+" "+thebook.Author);
            Console.ReadLine();
           
        }
    }
}
/* List<book> books = new List<book>();
            List<string> list = new List<string>();
            List<int> list2 = new List<int>();
            */
