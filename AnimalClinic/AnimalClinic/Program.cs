using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalClinic
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] command = Console.ReadLine().Split();
            List<Animal> animals = new List<Animal>();

            while (command[0] != "End")
            {
                animals.Add(new Animal(command[0], command[1], AnimalClinic.patientId));               

                switch (command[2])
                {
                    case "heal": AnimalClinic.Heal(); break;
                    case "rehab": AnimalClinic.Rehabilitate(); break;
                }
                command = Console.ReadLine().Split();
            }

            foreach (Animal animal in animals)
            {
                Console.WriteLine($"Patient {animal.Id}: [{animal.Name} ({animal.Breed})] has been healed!");
            }

            Console.WriteLine($"Total healed animals: {AnimalClinic.healedAnimalsCount}");
            Console.WriteLine($"Total rehabilitated animals: {AnimalClinic.rehabilitatedAnimalsCount}");

            foreach (Animal animal in animals)
            {
                Console.WriteLine($"{animal.Name} {animal.Breed}");
            }
            Console.ReadKey();
        }
    }
}
