using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Z_Orchestre;

namespace Z_Orchestre
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" --- Orchestre 1 ---");
            var Orchestre1 = new Orchestre { Nom = "Orchestre Symphonique de Nancy"};
            var maestro1 = new Maestro("Du Gland", "Gérard", Orchestre1);
            Orchestre1.DisplayMaestro();
            Console.WriteLine("\t L'orchestre de nom {0} a pour Maestro {1} {2}", Orchestre1.Nom, Orchestre1.MaitreDorchestre.Nom, Orchestre1.MaitreDorchestre.Nom);
            var amelie = new Musicien ("klein", "amelie", Orchestre1 );
            amelie.DisplayMusiciens();
            var benjamin = new Musicien("bernard", "benjamin", Orchestre1);
            benjamin.DisplayMusiciens();
            //Orchestre1.DisplayMusiciens();

            Console.WriteLine("\n");

            Console.WriteLine(" --- Orchestre 2 ---");
            var Orchestre2 = new Orchestre { Nom = "Orchestre Symphonique de Paris" };
            var maestro2 = new Maestro("Maestrissme", "Jacynthe", Orchestre2);
            Orchestre2.DisplayMaestro();
            Console.WriteLine("\t L'orchestre {0} a pour Maestro {1} {2}", Orchestre2.Nom, Orchestre2.MaitreDorchestre.Nom, Orchestre2.MaitreDorchestre.Nom);
            var khaoula = new Musicien("kkk", "khaoula", Orchestre2);
            khaoula.DisplayMusiciens();
            var ambre = new Musicien("aaa", "ambre", Orchestre2);
            ambre.DisplayMusiciens();
            //Orchestre2.DisplayMusiciens();


            Console.ReadLine();
        }

    }

    public class Person
    {
        public string Nom;
        public string Prenom;

        //public Person(string n, string p)    ///LES CONSTRUCTEURS DE MUSICIENS ET MAESTRO NE MARCHENT PLUS AVEC CA
        //{
        //    Nom = n;
        //    Prenom = p;
        //}

        public virtual void Display (Person person)
        {
            Console.WriteLine("{0} {1} , Cette personne est inscrite sur le logiciel", person.Nom);
        }

    }

    public class Orchestre
    {
        public string Nom;
        public Maestro MaitreDorchestre;
        public List<Musicien> Musiciens = new List<Musicien>();
        public int cpt;

        internal void DisplayMaestro()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\t L'orchestre {0} a pour maestro {1} {2}", Nom, MaitreDorchestre.Nom, MaitreDorchestre.Prenom);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public void DisplayMusiciens()
        {
            //cpt = 0;
            Console.WriteLine("L'orchestre {0} a pour musiciens :");
            foreach (Musicien M in Musiciens)
            {
                Console.WriteLine("\t {1} {2} ", M.Prenom, M.Nom);
                //cpt++;
            }
        }

    }

    public class Maestro : Person
    {
        public DateTime Arrivée;
        public Orchestre Orchestre;
        public Maestro(string nom, String prenom, Orchestre orch)
        {
            Nom = nom;
            Prenom = prenom;
            Orchestre = orch;
            orch.MaitreDorchestre = this; // triche
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("A la création de son maestro, l'orchestre {0} a dorenavant {1} {2} pour maestro", 
                orch.Nom, orch.MaitreDorchestre.Nom, orch.MaitreDorchestre.Prenom);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

    }

    public class Musicien : Person
    {

        public DateTime Arrivée;
        public Orchestre orchestreMusicien;
        //protected string Instrument;
        //protected int NumInstrument;


        public Musicien(string nom, String prenom, Orchestre orch)
        {
            Nom = nom;
            Prenom = prenom;
            orchestreMusicien = orch;
            orch.Musiciens.Add(this);
            Console.WriteLine("\t Nouveau musicien créé : l'orchestre {0} compte dorenavant {1} musiciens", orch.Nom, orch.Musiciens.Count);
        }

        internal void DisplayMusiciens()
        {
            Console.WriteLine("\t -> {0} {1} joue pour {2}", Prenom, Nom, orchestreMusicien.Nom);
        }

    }

    //public class Instrument : Musicien
    //{
    //    protected string Instrument;
    //    protected int NumInstrument;
    //}


}

