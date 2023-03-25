using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UML_Modelisation
{
        internal class Program
        {
            static void Main(string[] args)
            {

                CompteBancaire ClientAmélie = new CompteBancaire { Nom = "KLEIN", Prenom = "Amélie", Numero = 1, Solde = 1025, Devise = "Euros" };
                Console.WriteLine(" {0} {1} a {2} {3} sur son compte", ClientAmélie.Prenom, ClientAmélie.Nom, ClientAmélie.Solde, ClientAmélie.Devise);

                CompteBancaire ClientBenjamin = new CompteBancaire { Nom = "BERNARD", Prenom = "Ben", Numero = 2, Solde = 102500, Devise = "Euros" };
                Console.WriteLine(" {0} {1} a {2} {3} sur son compte", ClientBenjamin.Prenom, ClientBenjamin.Nom, ClientBenjamin.Solde, ClientBenjamin.Devise);

                /// aggrégation dans une liste d'objets : 
                var personnescomptes = new List<CompteBancaire>();
                personnescomptes.Add(ClientAmélie);
                personnescomptes.Add(ClientBenjamin);

                foreach (CompteBancaire personnecompte in personnescomptes)
                {
                    Console.WriteLine("\t  {0} {1} a {2} {3} sur son compte",personnecompte.Prenom, personnecompte.Nom, personnecompte.Solde, personnecompte.Devise);
                }

                Console.ReadLine();
            }
    }
}

