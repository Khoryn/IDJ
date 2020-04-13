using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalClinic
{
    class AnimalClinic
    {
        public static int patientId = 1;
        public static int healedAnimalsCount;
        public static int rehabilitatedAnimalsCount;

        public static void Heal()
        {
            patientId++;
            healedAnimalsCount++;
        }

        public static void Rehabilitate()
        {
            patientId++;
            rehabilitatedAnimalsCount++;
        }
    }
}
