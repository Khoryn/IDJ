using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemperatureConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();

            while (command != "End")
            {
                string[] cmdWords = command.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
                switch (cmdWords[1])
                {
                    case "Celsius": Console.WriteLine(Temperature.ConvertToFahrenheit(int.Parse(cmdWords[0]))); break;
                    case "Fahrenheit": Console.WriteLine(Temperature.ConvertToCelsius(int.Parse(cmdWords[0]))); break;
                    default: Console.WriteLine("Não encontrou a unidade"); break;
                }
                command = Console.ReadLine();
            }
        }
    }
}
