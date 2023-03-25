using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace intro //Intro !
{
    public class Personne
    {
        public Personne() //constructeur == methode particulière qui retourne rien, elle est du même nom que la classe
        {
            Compteur++;
        }
        public Personne(int d, string nom, string prenom) //constructeur == methode particulière qui retourne rien, elle est du même nom que la classe
        {
            Id = d;
            Nom = nom;
            Prenom = prenom;
            Compteur++;
        }

        public int Id;
        public string Nom;
        public string Prenom;
        public DateTime DateNaissance;
        public string Ville;
        public static int Compteur = 0;
        public int CalculerAge()
        {
            return (int)(DateTime.Now - DateNaissance).TotalDays / 365;
        }

    }

    public class PersonneVille
    {

        public Personne P;
        public string V;
    }


    public class Interprete :Personne
    {
        public List<string> Concerts;
        public string MaisonProduction;
    }




    //public static class Freddy
    //{
    //    public static int id;
    //    public static string Nom;
    //    public static string Prenom;
    //    public static DateTime DateNaissance;
    //    public static int CalculerAge()
    //    {
    //        return (int)(DateTime.Now - DateNaissance).TotalDays / 365;
    //    }
    //}

}
