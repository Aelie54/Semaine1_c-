using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Z_Orchestre;

//      Trois choses à demander :
//          enum pour recuperer une string,
//          les constructeur de classe parent, (constructeur de personne et de musicien que je dois supprimer...)
//          le set qui ne referepas le player ligne 202

namespace Z_Orchestre
{
        enum InstrumentsListe { 
            Premier_Violon = 1, 
            Second_Violon = 2, 
            Violoncelle = 3, 
            Contrebasse = 4, 
            Piano =5, Harpe = 6, 
            Flute= 7, 
            Piccolo = 8, 
            Cors_Anglais =9,
            Cors_d_Hamonie = 10,
            Basson = 11,
            Clarinette_basse = 12,
            Clarinette = 13,
            Contrebasson = 14,
            Tuba = 15,
            Trombonne = 16,
            Cornet = 17,
            Trompette = 18,
            Triangle = 19,
            Xylophone = 20,
            Carrillon = 21,
            Caisse_Claire = 22,
            Grosse_Caisse = 23,
            Gong = 24,
            Cinballes = 25,
            Timballes= 26,
        }
    //var choixInt = alea.Next(1, 26);
    //var choixI = (InstrumentsListe)choixInt; 

    internal class Program
    {
        static Random alea = new Random();
        static void Main(string[] args)
        {


            Console.WriteLine(" --- Orchestre 1 ---");

            var Orchestre1 = new Orchestre { Nom = "Orchestre Symphonique de Nancy" };
            var maestro1 = new Maestro("Du Gland", "Gérard", Orchestre1);
            Orchestre1.DisplayMaestro();
            Console.WriteLine("\t L'orchestre {0} a pour Maestro {1} {2}", Orchestre1.Nom, Orchestre1.MaitreDorchestre.Nom, Orchestre1.MaitreDorchestre.Nom);

            //var benjamin = new Musicien("bernard", "benjamin", Orchestre1);   //CONSTRUCTEUR MUSICIEN PLUS VALABLE AVEC HERITAGE INSTRUMENT
            //var amelie = new Musicien ("klein", "amelie", Orchestre1 );       //CONSTRUCTEUR MUSICIEN PLUS VALABLE AVEC HERITAGE INSTRUMENT

            var benjamin = new Instrument("Bernard", "Benjamin", new DateTime(2008, 3, 1, 7, 0, 0), Orchestre1, "Cinballes", 123987, new DateTime(2008, 3, 1, 7, 0, 0));
            var amelie = new Instrument("KLEIN", "Amélie", new DateTime(2008, 3, 1, 7, 0, 0), Orchestre1, "Saxophone", 123987, new DateTime(2008, 3, 1, 7, 0, 0));

            amelie.DisplayMusiciens();
            benjamin.DisplayMusiciens();
            Orchestre1.DisplayMusiciens(); 


            Console.WriteLine("\n");


            Console.WriteLine(" --- Orchestre 2 ---");

            var Orchestre2 = new Orchestre { Nom = "Orchestre Symphonique de Paris" };
            var maestro2 = new Maestro("Maestrissme", "Jacynthe", Orchestre2);
            Orchestre2.DisplayMaestro();
            Console.WriteLine("\t L'orchestre {0} a pour Maestro {1} {2}", Orchestre2.Nom, Orchestre2.MaitreDorchestre.Nom, Orchestre2.MaitreDorchestre.Nom);

            //var khaoula = new Musicien("kkk", "khaoula", Orchestre2);     //CONSTRUCTEUR MUSICIEN PLUS VALABLE AVEC HERITAGE INSTRUMENT
            //var ambre = new Musicien("aaa", "ambre", Orchestre2);         //CONSTRUCTEUR MUSICIEN PLUS VALABLE AVEC HERITAGE INSTRUMENT

            var khaoula = new Instrument("KKK", "Khaoula", new DateTime(2008, 3, 1, 7, 0, 0), Orchestre2, "Piccolo", 123987, new DateTime(2008, 3, 1, 7, 0, 0));
            var ambre = new Instrument("AAA", "Ambre", new DateTime(2008, 3, 1, 7, 0, 0), Orchestre2, "Violoncelle", 123987, new DateTime(2008, 3, 1, 7, 0, 0));

            khaoula.DisplayMusiciens();
            ambre.DisplayMusiciens();
            Orchestre2.DisplayMusiciens();

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
            if(Musiciens.Count > 0) Console.WriteLine("\t Pourcours des {0} musiciens : ", Musiciens.Count);
            else return;

            foreach (Musicien M in Musiciens)
            {
                Console.WriteLine("\t - {0} {1} ", M.Prenom, M.Nom);
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
            Console.WriteLine("A la création de son maestro, l'orchestre {0} a dorenavant {1} {2} pour maestro", orch.Nom, orch.MaitreDorchestre.Nom, orch.MaitreDorchestre.Prenom);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

    }

    public class Musicien : Person
    {

        public DateTime Arrivée;
        public Orchestre orchestreMusicien;

        //public Musicien(string nom, String prenom, Orchestre orch)
        //{
        //    Nom = nom;
        //    Prenom = prenom;
        //    orchestreMusicien = orch;
        //    orch.Musiciens.Add(this);
        //    Console.WriteLine("\t Nouveau musicien créé : l'orchestre {0} compte dorenavant {1} musiciens", orch.Nom, orch.Musiciens.Count);
        //}

        internal virtual void DisplayMusiciens()
        {
            Console.WriteLine("\t -> {0} {1} joue pour {2}", Prenom, Nom, orchestreMusicien.Nom);
        }

    }

    public class Instrument : Musicien
    {
        public Musicien player;
        protected int numserie;
        protected string instru;
        public int Numserie
        {
            get { return numserie; }
            set
            {
                numserie = value;
                Console.WriteLine("{0} a pour numéro de série : {1}", Instru, numserie);
            }
        }

        public string Instru
        {
            get { return instru; }
            set
            {
                instru = value;
                //Console.WriteLine("{0} {1} qui jour pour {2} a pour numéro de série : {3}", ((Person)player).Nom, ((Person)player).Prenom, orchestreMusicien.Nom, Instru);  ///PAS COMPRENDRE player null?!
            }
        }

        public string NumSerie { get; private set; }

        public DateTime FabricationDate;

        public Instrument(string nom, String prenom, DateTime arrivée, Orchestre orch, string instru, int num, DateTime Fabrication)
        {
            Nom = nom;
            Prenom = prenom;
            orchestreMusicien = orch;
            numserie = num;
            Arrivée = arrivée;
            Instru = instru;
            orch.Musiciens.Add(this);
            Console.WriteLine("\t Nouveau musicien créé : l'orchestre {0} compte dorenavant {1} musiciens", orch.Nom, orch.Musiciens.Count);
        }

        internal override void DisplayMusiciens()
        {
            Console.WriteLine("\t -> {0} {1} joue de l'instrument {2} pour {3}", Prenom, Nom, Instru, orchestreMusicien.Nom);
        }

    }

}

