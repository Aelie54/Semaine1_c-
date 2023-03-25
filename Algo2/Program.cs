using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random alea = new Random();
            string nom = "";
            int proposition = 0;
            int nombreADeviner;
            int nCoup = 0;
            bool partieFinie;
            string[] scores = new string[10];
            int index = 0;

            //// Pour tester 
            scores[0] = "André|5";
            scores[1] = "Monique|4";
            index = 2;
            ////

            while (true)
            {
                Console.Write("Votre nom : ");
                nom = Console.ReadLine();

                Console.WriteLine("{0}, deviner un nombre compris entre 1 et 99", nom);
                nombreADeviner = alea.Next(1, 100);
                Console.WriteLine(nombreADeviner);
                nCoup = 0; partieFinie = false;

                while (!partieFinie)
                {
                    nCoup++;
                    if (nCoup == 8)
                    {
                        Console.WriteLine("Perdu");
                        partieFinie = true;
                    }
                    else
                    {
                        Console.Write("Proposition {0} : ", nCoup);
                        var propositionStr = Console.ReadLine();
                        if (int.TryParse(propositionStr, out proposition))
                        {
                            if (proposition < nombreADeviner)
                                Console.WriteLine("Trop petit");
                            else if (proposition > nombreADeviner)
                                Console.WriteLine("Trop grand");
                            else
                            {
                                Console.WriteLine("Gagné");
                                partieFinie = true;
                                scores[index] = nom + "|" + nCoup;
                                index++;
                                if (index == scores.Length) index = 0;

                                AffichageScore(scores);
                                //remplacé par une fonction :
                                //for (int i = 0; i < scores.Length; i++)
                                //{
                                //    Console.ForegroundColor = ConsoleColor.Magenta;
                                //    Console.WriteLine(scores[i]);
                                //}

                                Console.ForegroundColor = ConsoleColor.Gray;
                            }
                        }
                        else
                            Console.WriteLine("Saisie incorrecte");
                    }
                }
                Console.ReadLine();
            }

        }

        static void AffichageScore(string[] tableau) //qui ne retourne rien du tout void
        {
            var tab_tri = Trier(tableau);

            for (int i = 0; i < tab_tri.Length; i++)
            {
                if (tab_tri[i] != null)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    var new_tab = tab_tri[i].Split('|');
                    Console.WriteLine("{0}\t{1}", new_tab[i], new_tab[i + 1]);
                }
                Console.ForegroundColor = ConsoleColor.Gray;
            }

            //////////////////////////////////////////////////////  ====>   fonctionne déjà sans le tri :
            //for (int i = 0; i < tableau.Length; i++)
            //{
            //    if (tableau[i] != null)
            //    {
            //        Console.ForegroundColor = ConsoleColor.Red;
            //        var new_tab = tableau[i].Split('|');
            //        Console.WriteLine("{0}\t{1}", tableau[i], tableau[i + 1]);
            //    }
            //    Console.ForegroundColor = ConsoleColor.Gray;
            //}
            //////////////////////////////////////////////////////
        }

        static string[] Trier(string[] scores)
        {
            var fin = false;
            var index = 0; var a = 0; var b = 0; //initialisation

            while (!fin)
            {
                string tampon;
                //on sépare les valeurs nom et score dans un nouveau tableau
                var tab1 = scores[index].Split('|');
                a = int.Parse(tab1[1]);
                //Console.WriteLine("longeur tableau : {0}\t position tableau : {1} \t index : {2}", new_tab[index + 1], new_tab.Length, index);
                //Console.ReadLine();// pour ne pas qitter brutalement la fenetre

                if (scores[index + 1] == null || index + 1 == scores.Length)
                {
                    fin = true;
                }
                else
                {
                    var tab2 = scores[index + 1].Split('|'); //on a séparé les valeurs nom et score dans un nouveau tableau
                    b = int.Parse(tab2[1]); //on converti en entier en 0 on a le prenom
                    // a c'est didier qui a un score de 5 ;  b c'est monique qui a un score de 4 => score monique doit ê avant celui de didier
                    if (a > b) //on inverse
                    {
                        tampon = scores[index + 1];             //on met dans une variable la valeur à déplacer qui est le score de monique
                        scores[index + 1] = scores[index];      // on inverse les deux valeurs je remplace celles de monique par celles de andré
                        scores[index] = tampon;                 // là ou il y avait andré je mets monique
                        index = 0;                              //on reprend à 0 car les lignes on été interchangées
                    }
                    else { index++; }
                }
            }
            return scores;
        }
    }
}
