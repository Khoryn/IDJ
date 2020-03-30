using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemperatureConverter
{
    class Temperature
    {
        public static string ConvertToFahrenheit(int degreesCelsius)
        {
            double degreesInFahrenheit = degreesCelsius * 1.8f + 32;
            return String.Format("{0:F2}",degreesInFahrenheit);
        }

        public static string ConvertToCelsius(int degreesInFahrenheit)
        {
            double degreesCelsius = (degreesInFahrenheit - 32) / 1.8f;
            return String.Format("{0:F2}", degreesCelsius);
        }
    }
}
