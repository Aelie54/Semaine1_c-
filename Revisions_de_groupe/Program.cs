using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Z_Revisions_de_groupe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var amelie = new Personne { Nom = "KLEIN", Prenom = "Amélie" };

            Console.WriteLine(amelie.Nom);
            amelie.Sayhello();
            amelie.DitBjr(amelie);

            amelie.setAge(32);

            var adrien = new Student { Nom = "Nom", Prenom = "Adrien" };
            adrien.setAge(31);
            adrien.GotoSchool();

            var khaoula = new Teacher { Nom = "Nom", Prenom = "Khaoula" };
            khaoula.GetSubject("maths");
            khaoula.ExplainSubject();

            Console.ReadLine();
        }
    }

    public class Personne
    {
        public string Nom;
        public string Prenom;
        protected int Age;

        internal void DitBjr(Personne param)
        {
            Console.WriteLine("Bonjour {0}", param.Prenom);
        }

        internal void Sayhello()
        {
            Console.WriteLine("Bonjour");
        }

        internal void setAge(int v)
        {
            Age = v;
        }
    }


    public class Student : Personne
    {
        public void SetAge()
        {
            Console.WriteLine("mon age d'étudiant est de  {0} ans", Age);
        }
        public void GotoSchool()
        {
            Console.WriteLine("{0} va à l'école", Prenom);
        }

    }


    public class Teacher : Personne
    {
        private string Matière;

        internal void GetSubject(string mat)
        {
            Matière = mat;
            Console.WriteLine("votre matière étudiée est : {0}", Matière);
        }

        internal void ExplainSubject()
        {
            Console.WriteLine("Explications begins");
        }

    }








}
