using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalClinic
{
    class Animal
    {
        public string Name { get; set; }
        public string Breed { get; set; }
        public int Id { get; set; }

        public Animal(string name, string breed, int id)
        {
            Name = name;
            Breed = breed;
            Id = id;
        }
    }
}
