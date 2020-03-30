using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlunoISMAI
{
    class Program
    {
        static void Main(string[] args)
        {

            Aluno aluno = new Aluno("João Loureiro", 12345, 1, "DJD");
            Aluno aluno2 = new Aluno("Ricardo Silva", 22345, 2, "DJD");

            Console.WriteLine(aluno.ConvertToString());
            Console.WriteLine(aluno.InscritoAntes(aluno2));
            Console.ReadKey();

        }
    }
}
