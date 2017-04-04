using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolApp02
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] customers = new string[] { "smith", "hill", "fox", "cox" };

            using ( StreamWriter sw = new StreamWriter("customers.txt"))
            {
                foreach (string cust in customers)
                {
                    sw.WriteLine(cust);
                }
            }

            string custName = "";
            List<string> clients = new List<string> { "" }; 

            using (StreamReader sr = new StreamReader("customers.txt"))
            {
                while((custName = sr.ReadLine()) != null)
                {
                    Console.WriteLine(custName);
                    clients.Add(custName); 
                }
            }

            foreach (string name in clients)
            {
                Console.WriteLine(name);
            }

            Console.ReadLine(); 
        }
    }
}
