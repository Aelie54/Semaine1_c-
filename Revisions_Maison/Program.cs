using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Z_Revisions_Maison
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var mamaison = new House(55.5M);
            mamaison.Display();

            mamaison.Surface = 60; /// setter !

            var porte = new Door("porte", "red");
            mamaison.door = porte;
            Console.WriteLine("ACCES PORTE PAR MAISON : Ma porte {0} est de couleur {1}", mamaison.door.name, mamaison.door.Color);

            var porte2 = new Door("porte2", "blue");
            mamaison.door = porte2;
            Console.WriteLine("ACCES PORTE PAR MAISON : Ma porte {0} est de couleur {1}", mamaison.door.name, mamaison.door.Color);

            var monappart = new Appart();
            monappart.Display();
            monappart.Surface = 100;
            monappart.Display();

            var porte3 = new Door("porte3", "violet");
            monappart.door = porte3;
            Console.WriteLine("ACCES PORTE PAR APPART : Ma porte {0} est de couleur {1}", monappart.door.name, monappart.door.Color);

            Console.ReadLine();
        }

    }


    public class House
    {
        protected decimal surface;
        public Door door;

        public House(decimal s)
        {
            surface = s;
        }

        internal virtual void Display()
        {
            Console.WriteLine("Je suis une maison de surface {0} m²", Surface);
        }

        public decimal Surface
        {
            get { return surface; }
            set
            {
                surface = value;
                Console.WriteLine("Je suis une maison de surface {0} m²", Surface);
            }
        }
    }

    public class Door
    {
        public string name;
        public Door(string n, string c)
        {
            name = n;
            color = c;
        }

        protected string color;

        public string Color
        {
            get { return color; }
            set
            {
                color = value;
                Console.WriteLine("la porte est de couleur {0}", color);
            }
        }

    }


    public class Appart : House
    {
        public Appart() : base(50)
        {
        }

        internal override void Display()
        {
            Console.WriteLine("Je suis un appartement de surface {0} m²", Surface);
        }

    }


}
