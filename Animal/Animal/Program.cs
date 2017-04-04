using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

delegate double GetSum(double num1, double num2);

namespace ConsoleApp01
{
    public enum Temperature
    {
        Freeze,
        Low,
        Warm,
        Boil
    } 
    struct Customers
    {
        private string name;
        private double balance;
        private int id;

        public void createCust(string n, double b, int i)
        {
            name = n;
            balance = b;
            id = i; 
        }

        public void showCust()
        {
            Console.WriteLine("Name " + name);
            Console.WriteLine("balance " + balance);
            Console.WriteLine("Id " + id);

        }
    }
    class Animal
    {
        public double height { get; set; }
        public double weight { get; set; }
        public string sound  { get; set; }
        public string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public Animal()
        {
            this.height = 0;
            this.weight = 0;
            this.name = "no name";
            this.sound = "no sound";
            numOfAnimals++;
        }

        public Animal(double height, double weight, string name, string sound)
        {
            this.height = height;
            this.weight = weight;
            this.name = name;
            this.sound = sound;
            numOfAnimals++; 
        }


        static int numOfAnimals = 0; 

        public static int getNumOfAnimals()
        {
            return numOfAnimals; 
        }

        public string toString()
        {
            return String.Format("{0} is {1} inches tall, weighs {2} lbs and likes to say {3}",
                name, height, weight, sound); 
        }

        public int getSum(int num1=1, int num2=1)
        {
            return num1 + num2; 
        }

        public double getSum(double num1 = 1, double num2 = 1)
        {
            return num1 + num2;
        }
        static void Main(string[] args)
        {
            GetSum sum = delegate (double num1, double num2)
            {
                return num1 + num2;
            };
            Console.WriteLine("5+10= "+sum(5,10));
            //
            // lambda expression

            Func<int, int, int> getTot = (x, y) => x + y;

            Console.WriteLine("10+345= "+getTot.Invoke(10,345));
            //
            // List
            //
            List<int> numList = new List<int> { 5, 10, 15, 20, 25, 30 };

            List<int> oddNums = numList.Where(n => n % 2 == 1).ToList();

            foreach (int num in oddNums)
            {
                Console.WriteLine(num+",");
            }
            //
            // Write and Read with file
            //
            string[] custs = new string[] { "Tom", "Paul", "Greg" ,"Peter"};
            using (StreamWriter sw = new StreamWriter("custs.txt"))
            {
                foreach (string cust in custs)
                {
                    sw.WriteLine(cust); 
                }
            }

            string custName = "";
            using(StreamReader sr = new StreamReader("custs.txt"))
            {
                while ((custName = sr.ReadLine())!= null)
                {
                    Console.WriteLine(custName);
                }
            }
            //
            //
            //
            Customers customer =new Customers();
            customer.createCust("smith", 1232.40, 343432);
            customer.showCust(); 


            Temperature micTemp = Temperature.Warm;

            switch (micTemp)
            {
                case Temperature.Freeze:
                    Console.WriteLine("Temp on Freezing");
                    break;
                case Temperature.Low:
                    Console.WriteLine("Temp on Low");
                    break;
                case Temperature.Warm:
                    Console.WriteLine("Temp on Warm");
                    break;
                case Temperature.Boil:
                    Console.WriteLine("Temp on Boil");
                    break;
            }

            Animal spot = new Animal(15, 10, "spot","woof");

            Console.WriteLine("{0} says {1}", spot.name, spot.sound);

            Console.WriteLine("Number of animals "+Animal.getNumOfAnimals());

            Console.WriteLine(spot.toString());

            Console.WriteLine(spot.getSum(num2: 1.4, num1: 2.7));

            Animal grover = new Animal
            {
                name = "Grover",
                height = 16,
                weight = 18,
                sound = "Grrr"
            };

            //==============================

            Dog spike = new Dog();

            Console.WriteLine(spike.toString());

            spike = new Dog(20, 15, "Spike", "Grrrrrr", "Chicken");

            Console.WriteLine(spike.toString());

            //==============================

            Shape rect = new Rectangle(5, 7);
            Shape tri = new Triangle(3, 4);

            Console.WriteLine("Rect Area " + rect.area());
            Console.WriteLine("Tri Area " + tri.area());

            Rectangle combRect = new Rectangle(5, 6) + new Rectangle(7, 8);

            Console.WriteLine("combRect Area "+combRect.area());

            //==============================

            KeyValue<string, string> superman = new KeyValue<string, string>("", "");
            superman.key = "superman";
            superman.value = "Clark Kent";

            KeyValue<int, string> samsungTV = new KeyValue<int, string>(0, "");

            samsungTV.key = 342;
            samsungTV.value = "a 50 inch samsung TV";

            superman.showData();
            samsungTV.showData(); 





            Console.ReadLine(); 

        }
    }

    class Dog: Animal
    {
        public string favFood { get; set;  }

        public Dog(): base()
        {
            this.favFood = "No Favorite Food"; 
        }

        public Dog(double height, double weight, string name, string sound, string favFood) :
            base (height, weight, name, sound)
        {
            this.favFood = favFood; 
        }

        new public string toString()
        {
            return String.Format("{0} is {1} inches tall, weighs {2} lbs and likes to say {3} and eats {4} ",
                name, height, weight, sound, favFood);
        }
    }

    abstract class Shape
    {
        public abstract double area();

        public void sayHello()
        {
            Console.WriteLine("Hello");
        }
    }
    public interface ShapeItem
    {
        double area(); 
    }

    class Rectangle : Shape
    {
        private double length;
        private double width;

        public Rectangle(double num1, double num2)
        {
            length = num1;
            width = num2; 
        }
        public override double area()
        {
            return length * width; 
        }

        public static Rectangle operator+ (Rectangle rect1, Rectangle rect2)
        {
            double rectLength = rect1.length + rect2.length;
            double rectWidth = rect1.width + rect2.width;

            return new Rectangle(rectLength, rectWidth);
        }
    }

    class Triangle : Shape
    {
        private double theBase;
        private double height;

        public Triangle(double num1, double num2)
        {
            theBase = num1;
            height = num2;
        }
        public override double area()
        {
            return 0.5*theBase * height;
        }
    }
    
    class KeyValue<TKey, TValue>
    {
        public TKey key { get; set; }
        public TValue value { get; set;  }

        public KeyValue(TKey k, TValue v)
        {
            key = k;
            value = v; 
        }

        public void showData()
        {
            Console.WriteLine("{0} is {1}", this.key, this.value);
        }
    }
    
}
