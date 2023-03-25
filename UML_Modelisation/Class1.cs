using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UML_Modelisation
{

    class Client
    {

        public string Nom;
        public string Prenom;
        public int Numero;

    }

    class CompteBancaire : Client
    {
        public decimal Solde;
        public string Devise;

        public bool Crediter(decimal montant)
        {
            Solde += montant;
            return true;
        }

        public bool Debiter(decimal montant)
        {
            if (Solde - montant > 0)
            {
                Solde -= montant;
                return true;
            }
            return false;
        }

        public void Decrire()
        {
            Console.WriteLine(" {0} {1} a {2} {3} sur son compte", Prenom, Nom,Solde,Devise);
        }
    }


}
