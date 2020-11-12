using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarEvents
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Events *****\n");

            int aboutToBlowCounter = 0;//Переменная для анонимной функции

            Car c1 = new Car("SlugBug", 100, 10);

            c1.AboutToBlow += CarIsAlmostDoomed;
            c1.AboutToBlow += CarAboutToBlow;
            c1.Exploded += CarExploded;

            // Register event handlers as anonymous methods.
            c1.AboutToBlow += delegate
            {
                aboutToBlowCounter++;
                Console.WriteLine("Eek! Going too fast!");
            };
            c1.AboutToBlow += delegate (object sender, CarEventArgs e)
            {
                aboutToBlowCounter++;
                Console.WriteLine("Critical Message from Car: {0}", e.msg);
            };



            Console.WriteLine("***** Speeding up ******");
            for (int i = 0; i < 6; i++)
            {
                c1.Accelerate(20);              
            }
            c1.Exploded -= CarExploded;

            Console.WriteLine("\n***** Speeding up *****");
            for (int i = 0; i < 6; i++)
                c1.Accelerate(20);
            Console.ReadLine();
        }

        public static void CarAboutToBlow(object sender, CarEventArgs e)
        {
            Console.WriteLine("{0} says: {1}", sender, e.msg);
        }
        public static void CarIsAlmostDoomed(object sender, CarEventArgs e)
        { Console.WriteLine("{0} says: {1}", sender, e.msg); }
        public static void CarExploded(object sender, CarEventArgs e)
        { Console.WriteLine("{0} says: {1}", sender, e.msg); }
    }
}
