using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace intro
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // =====> class patrick qui était inutile
            //Patrick.id = 1;
            //Patrick.Nom = "Hernandez";
            //Patrick.Prenom = "Patrick";
            //Patrick.DateNaissance = new DateTime(1942, 3, 22); //DateTime.Now; 
            //Console.WriteLine(" {0} {1} a {2} ans", Patrick.Prenom, Patrick.Nom, Patrick.CalculerAge());
            //Console.ReadLine();

            Personne patrick = new Personne(1, "Chirac", "Patrick");
            //Personne patrick = new Personne();
            //patrick.Nom = "Hernandez";
            //patrick.Prenom = "Patrick";
            patrick.DateNaissance = new DateTime(1942, 3, 22); //DateTime.Now; 
            var patrickVille = new PersonneVille { P = patrick, V = "Paris" };
            //Personne.Compteur++; 


            ///// NOTION STATIC /////
            ////////////////////////
            ////////////////////////
            ///
            // var i = patrick.Compteur;  //impossible car static donc n'est pas dans objet
            var i = Personne.Compteur; // général à la class donc ok en passant par la class
            ///
            ////////////////////////
            ////////////////////////

            Personne freddy = new Personne();
            freddy.Nom = "Mercury";
            freddy.Prenom = "Freddy";
            var freddyVille = new PersonneVille { P = freddy, V = "London" };
            freddy.DateNaissance = new DateTime(1946, 9, 5); //DateTime.Now; 
            //Personne.Compteur++; car dans le contructeur


            //liste personnes villes
            var personnesvilles = new List<PersonneVille>();
            personnesvilles.Add(patrickVille);
            personnesvilles.Add(freddyVille);
            foreach (PersonneVille personneville in personnesvilles)
            {
                Console.WriteLine("\n AGREGATION 2 juste des personnes : {0} {1} vit à {2}", personneville.P.Prenom, personneville.P.Nom, personneville.V);
            }


            //Personne johnny = new Personne(3, "Halliday", "Johnny");  // on ne peut pas on créé soit une perosnne soit un interprete
            Interprete johnny = new Interprete(); //ou Personne à la declaration
            johnny.Nom = "Halliday";
            johnny.Prenom = "Johnny";
            johnny.Concerts = new List<string> { "Arena", "Woodstock", "Zenith" };
            johnny.MaisonProduction = "MGM Records";
            johnny.Concerts.Add("Bordeaux on the Rock!");
            var johnnyVille = new PersonneVille { P = johnny, V = "Paris" };
            johnny.DateNaissance = new DateTime(1953, 8, 16); //DateTime.Now; 
            //Personne.Compteur++;


            Console.WriteLine("\n {0} personnes ont été définies ", Personne.Compteur);
            Console.WriteLine("\n Afficher un objet : {0} {1} a {2} ans", patrick.Prenom, patrick.Nom, patrick.CalculerAge());
            Console.WriteLine(" Afficher un objet : {0} {1} a {2} ans\n", freddy.Prenom, freddy.Nom, freddy.CalculerAge());

            Console.WriteLine(" \n \n AFFICHAGES DE LISTES - AGGREGATION AVEC HEREDITE  \n ");


            //liste de personnes
            var personnes = new List<Personne>();
            personnes.Add(patrick);
            personnes.Add(freddy);
            personnes.Add(johnny);
            foreach (Personne personne in personnes)
            {
                Console.WriteLine("\t AGREGATION 1 avec label : {0} {1} a {2} ans", personne.Prenom, personne.Nom, personne.CalculerAge());

                if( personne is Interprete)
                {
                    Console.WriteLine("\t c'est un chanteur, son label est {0} \n", ((Interprete)personne).MaisonProduction);
                }

            }



            //liste personnes villes
            var personnesvilles2 = new List<PersonneVille>();
            personnesvilles2.Add(patrickVille);
            personnesvilles2.Add(freddyVille);
            personnesvilles2.Add(johnnyVille);
            foreach (PersonneVille personneville in personnesvilles2)
            {
                Console.WriteLine("\t AGREGATION 3 avec concerts  car interprète: {0} {1} vit à {2} ", personneville.P.Prenom, personneville.P.Nom, personneville.V);

                if (personneville.P is Interprete)
                {
                    Console.WriteLine("\t  {0} est un chanteur et se produit à ", personneville.P.Prenom);
                    foreach (var concert in ((Interprete)personneville.P).Concerts)
                    {
                        Console.WriteLine("\t     " + concert);
                    }
                }
            }

            Console.ReadLine();
        }
    }
}
