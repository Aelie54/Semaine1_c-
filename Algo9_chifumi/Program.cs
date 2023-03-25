using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo9_Chifoumi
{
    enum Chifoumi { Pierre = 1, Feuille = 2, Ciseau = 3 }
    internal class Program
    {
        static Random alea = new Random();
        static void Main(string[] args)
        {
            int compteur = 0;  int compteur_machine = 0;

            while (compteur < 3 && compteur_machine < 3) //on boucle tant qu'il n'y a pas de vainqueur
            {
                // Choix Machine
                var choixInt = alea.Next(1, 4);
                var choixM = (Chifoumi)choixInt;
                Console.WriteLine("\n*** Triche : choix de la machine : {0} ***\n", choixM);

                // Choix Utilisateur
                string choixStr = "";
                while (choixStr != "1" && choixStr != "2" && choixStr != "3")
                {
                    Console.WriteLine("Choisissez (1-3) :");
                    Console.WriteLine("1. Pierre");
                    Console.WriteLine("2. Feuille");
                    Console.WriteLine("3. Ciseau\n");
                    choixStr = Console.ReadLine();
                }
                var choixU = (Chifoumi)int.Parse(choixStr);

                if (choixM == choixU)
                {
                    Console.WriteLine("\n Egalité ! votre score est revenu à 0 \n"); compteur = 0; compteur_machine = 0;
                }
                else if (
                    choixU == Chifoumi.Pierre && choixM == Chifoumi.Ciseau || 
                    choixU == Chifoumi.Feuille && choixM == Chifoumi.Pierre || 
                    choixU == Chifoumi.Ciseau && choixM == Chifoumi.Feuille
                    )
                {
                    compteur++; compteur_machine = 0;
                    Console.WriteLine("\n Vous Gagnez ! Votre score est de {0} \n", compteur);

                }
                else
                {
                    compteur = 0; Console.WriteLine(" \n Perdu ! Votre score est revenu à 0 \n "); compteur_machine++;
                }
            }

            if (compteur_machine == 3)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" \n L'ordinateur a gagné 3 fois de suite \n");
            }

            if (compteur == 3)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n Vous avez gagné 3 fois de suite\n ");
            }

            Console.ForegroundColor = ConsoleColor.Gray;            
            Console.WriteLine("\n Partie terminée \n Au revoir \n ");
            Console.ReadLine();
        }
    }
}