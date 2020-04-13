using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerCounter
{
    class BeerCounter
    {
        public static int stock;
        public static int drunkBeers;

        public static int BuyBeer(int bottleCount)
        {
            stock += bottleCount;
            return stock;
        }

        public static int DrinkBeer(int bottleCount)
        {
            drunkBeers += bottleCount;
            stock -= bottleCount;
            return drunkBeers;
        }
    }
}
