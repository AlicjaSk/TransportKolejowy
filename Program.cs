using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HD
{
    class Program
    {
        static void Main(string[] args)
        {

            GeneratorDB g = new GeneratorDB();

            
            Console.WriteLine("\n\tWcisnij klawisz, aby zakonczyc ;-)");
            Console.ReadKey();
        }

        static readonly Random rnd = new Random();
        
    }
}
