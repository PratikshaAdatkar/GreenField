using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDesignPatternApp
{
    public class complex:ICloneable
    {
        public int real;
        public int img;
        public complex()
        {
            real = img = 1;
        }
        public complex(int real, int img) {
        this.real = real;
        this.img = img;
        }

        public object Clone()
        {
            complex temp = new complex();
            temp.real = this.real;
            temp.img = this.img;
            return temp;

        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            complex c=new complex(1,2);
            complex c2 = (complex)c.Clone();
            Console.WriteLine(c2.real +" "+c2.img);
            Console.WriteLine(c.real + " " + c.img);


        }
    }
}
/* OfficeBoy waiter = OfficeBoy.Create();
                OfficeBoy admin= OfficeBoy.Create();
            OfficeBoy supervisor = OfficeBoy.Create();*/
