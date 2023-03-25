using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo7_echecs_cavalier
{
    internal class Program
    {
        static List<string> echiquier = new List<string>(); 
        static string lettre;
        static string cavalier = "A1";
        static List<string> deplacementsPossibles = new List<String> { "1,2", "1,-2", "2,1", "2,-1", "-1,2", "-1,-2", "-2,1", "-2,-1" };
        static Random alea = new Random();
        static int compteur =0 ;
        static void Main(string[] args)
        {
            for (int i=65; i<72; i++){
                for (int j=1; j<9; j++)
                {
                    lettre = ((char)i).ToString();
                    echiquier.Add(lettre + j.ToString());
                }
            }

            //for (int z = 1; z < 65; z++)
            //    Console.WriteLine(echiquier[z]);

            Console.WriteLine(cavalier);

            while ( cavalier != "H8" )
            {
                if (Deplacer()) { compteur++; Console.WriteLine(" coup {0} : position cavalier {1}", compteur, cavalier); }
                else Console.WriteLine("Impossible");
            }

            Console.ReadLine();  // pour ne pas qitter brutalement la fenetre
        }

        private static bool Deplacer()
        {
            var d = alea.Next(1, 9);
            var depl = deplacementsPossibles[d - 1];
            var tab=depl.Split(',');
            var deplH = int.Parse(tab[0]);
            var deplV = int.Parse(tab[1]);

            //position du cavalier
            var cavalierH = cavalier[0]; //A
            var cavalierV = cavalier[1]; //1

            //nouvelles positions du cavalier sur H et V
            cavalierH = (char)((int)cavalierH + deplH);
            if (cavalierH < 'A' || cavalierH  > 'H') return false;

            cavalierV = (char)((int)cavalierV + deplV);
            if (cavalierV-48 < 1 || cavalierV-48 > 8) return false;

            //position finale après mouvement
            cavalier = cavalierH.ToString() + cavalierV;
            return true;

        }
    }
}
