using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerCounter
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] command = Console.ReadLine().Split();

            while (command[0] != "End")
            {
                BeerCounter.BuyBeer(int.Parse(command[0]));
                BeerCounter.DrinkBeer(int.Parse(command[1]));

                command = Console.ReadLine().Split();
            }
            Console.WriteLine(BeerCounter.stock + " " + BeerCounter.drunkBeers);
            Console.ReadKey();
        }
    }
}
