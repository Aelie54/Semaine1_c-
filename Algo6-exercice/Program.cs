using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo6_exercice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //création de la liste de nombres
            int[] numbers = { 52, 68, 95, 74, 32, 22, 11, 44, 55, 66 };

            for (int i = 0; i < numbers.Length; i++)
            {
                var modulo = numbers[i] % 2;

                if (modulo != 1)
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("{0} est paire", numbers[i]);
                    //Console.WriteLine(numbers[i]);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("{0} est impaire", numbers[i]);
                }
            }
            Console.ReadLine();  // pour ne pas qitter brutalement la fenetre
        }
    }
}
