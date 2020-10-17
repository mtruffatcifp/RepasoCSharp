using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Exercise1_ForeachAndLists
{
    class Program
    {
        static void Main(string[] args)
        {
            var personas = new List<string> { "Tanya", "Miriam", "Glenn", "Xavier", "Musa", "Ryan", "Evangeline", "Otis", "Tyler" };

            foreach (var pers in personas)
              Console.WriteLine("Hello " + pers);
            Console.WriteLine();

            List<PersonModel> personasModel = GetpeopleModels();

            foreach (var persona in personasModel)
                Console.WriteLine("Hello " + persona.FirstName + " " +  persona.LastName);

            Console.WriteLine();
            Console.Write("Press enter to close...");
            Console.ReadLine();
        }
        private static List<PersonModel> GetpeopleModels()
        {
            var personas = new List<PersonModel>();

            personas.Add(new PersonModel { FirstName = "Becky", LastName = "Clayton" });
            personas.Add(new PersonModel { FirstName = "Alessandro", LastName = "Correa" });
            personas.Add(new PersonModel { FirstName = "Aubrey", LastName = "Swift" });
            personas.Add(new PersonModel { FirstName = "Stella", LastName = "Whittle" });

            return personas;
        }
    }
}
