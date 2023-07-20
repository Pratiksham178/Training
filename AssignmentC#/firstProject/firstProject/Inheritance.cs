using System;
using System.Numerics;
using System.Xml.Schema;

namespace HelloWorld
{
    class vehicle
    {
        public string brand = "";
        
        public void wheels()
        {
            Console.WriteLine("It has 4 wheels.");
        }
    }
    class car : vehicle
    {
        public string modeltype;
        public int price;
        public car(string brand,string modeltype, int price)
        {
            this.brand = brand;
            this.modeltype = modeltype;
            this.price = price;
        }
    }
    class Inheritance
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            car obj1 = new car("ford","nano",200000);
            Console.WriteLine(obj1.brand);
            obj1.wheels();
        }
    }

}
