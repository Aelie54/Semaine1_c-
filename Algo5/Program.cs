using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo5 //enregistrer des personnes avec des villes
{
    internal class Program
    {

        // partie 1 : saisie
        static Dictionary <string, string> personnes= new Dictionary<string, string>(); // une créé une liste de personne avec persone === clé et valeur ville

        static void Main(string[] args)
        {
            //partie 0 : lecture
            var lignes = File.ReadAllLines(@"D:\personnes.csv"); //retour une tableau de string une ligne texte == une ligne tableau mieux que ReadAllText 

            foreach (var ligne in lignes)
            {
                var tab = ligne.Split(';');
                personnes.Add(tab[0], tab[1]);
            }

            Affichage();

            //partie 1 saisie
            while (true)
            {
                Console.Write("Nom : ");
                var nom = Console.ReadLine();

                if(string.IsNullOrEmpty(nom)) break;

                Console.Write("Ville : ");
                var ville = Console.ReadLine();

                if (personnes.ContainsKey(nom)) Console.WriteLine("J'ai déjà un {0}", nom);
                else
                {
                    personnes.Add(nom, ville);
                }

            }

            //On sauvegarde pour persister
            var contenu = "";
            foreach (var person in personnes)
            {
                contenu += person.Key + ";" + person.Value + "\n";
            }
            File.WriteAllText(@"D:\personnes.csv", contenu); // ou C:\Users\Amélie\Desktop


            Console.ForegroundColor = ConsoleColor.Yellow;

            // partie 2 : affichage
            Affichage();
            //foreach(var person in personnes)
            //{
            //    Console.WriteLine("{0} \t {1}", person.Key, person.Value);
            //}

            // partie 3 : recherche une ville à partir d'un nom
            Console.Write("Nom ? : ");
            var question = Console.ReadLine();
            if (personnes.ContainsKey(question))
            {
                Console.WriteLine("{0} est de la ville de {1}", question, personnes[question]);
            }
            else {
                Console.WriteLine("{0} n'existepas!", question);
            }

            Console.ReadLine();  // pour ne pas qitter brutalement la fenetre
        }

        private static void Affichage()
        {
            foreach (var person in personnes)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("{0} \t {1}", person.Key, person.Value);
            }
            Console.ForegroundColor = ConsoleColor.Gray;
        }

    }
}
