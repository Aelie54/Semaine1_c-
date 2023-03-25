using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POEI_Aggregation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Version1();
            Version2();
            
            /////// on met dans version 1 :

            //int i = 0;
            //DateTime auj = DateTime.Now;
            //decimal pi = 3.14M;   ///double décimal ;  F pour Float 
            ////Personne p = new Personne();
            //Personne p1 = new Personne { Nom = "Amélie" };
            //Personne p2 = new Interprete { Nom = "Benjamin" };

            ////AGGREGATION   pareil que instancier
            //List<object> liste = new List<object>();
            //liste.Add(pi);
            //liste.Add(auj);
            //liste.Add(p1);
            //liste.Add(p2);

            //foreach (object objet in liste)   ///var objet in liste  => c'est pareil
            //{
            //    //Console.WriteLine(objet.ToString());
            //    Console.WriteLine(objet);   //le to string est dans objet 
            //}

            Console.ReadLine();
        }

        private static void Version1()
        {
            int i = 0;
            DateTime auj = DateTime.Now;
            decimal pi = 3.14M;   ///double décimal ;  F pour Float 
            //Personne p = new Personne();
            Personne p1 = new Personne { Nom = "Amélie" };
            Personne p2 = new Interprete { Nom = "Benjamin" };

            //AGGREGATION   pareil que instancier
            List<object> liste = new List<object>(); //autant d'elements que l'on veut
            liste.Add(pi);
            liste.Add(auj);
            liste.Add(p1);
            liste.Add(p2);

            foreach (object objet in liste)   ///var objet in liste  => c'est pareil
            {
                //Console.WriteLine(objet.ToString());
                Console.WriteLine(objet);   //le to string est dans objet 
            }
        }

        private static void Version2()
        {
            int i = 0;
            DateTime auj = DateTime.Now;
            decimal pi = 3.14M;   ///double décimal ;  F pour Float 
            Personne p1 = new Personne { Nom = "Amélie" };//Personne p = new Personne();
            Personne p2 = new Interprete { Nom = "Benjamin" };

            //AGGREGATION   pareil que instancier
            var liste = new ArrayList(); //autant d'elements que l'on veut
            liste.Add(pi);
            liste.Add(auj);
            liste.Add(p1);
            liste.Add(p2);

            foreach (object objet in liste)   ///var objet in liste  => c'est pareil
            {
                Console.WriteLine(objet);  //Console.WriteLine(objet.ToString()); //le to string est dans objet 
            }
        }
    }

    class Personne /// : Object
    {
        public string Nom;
        public override string ToString()  ///on peut remplacer ce qui est remplacable == virtual to string sur personne sera remplacé!
        {
            return " Personne de nom ---> " + Nom;
        }

    }

    class Interprete :Personne
    {
        public override string ToString()  ///on peut remplacer ce qui est remplacable == virtual to string sur personne sera remplacé!
        {
            return " Personne de nom ---> " + Nom;
        }

    }
}
