using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UML_TD1_v_s1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var nom = CoffreFort.NomCoffre;

            var c = new CoffreFort();
            c.Password = "abc";

            ////////////////////GET
            //var x = c.GetCode(); //ENCAPSU2LE
            var code = c.Code;

            c.Code = "456";

            Console.WriteLine(code);
            Console.ReadLine();

        }
    }

    public class CoffreFort
    {
        public static string NomCoffre = "Coffre d'amélie";
        public string Password;
        private string code = "123456";

        ////////////////////GET

        ////////////////////ENCAPSULE
        //internal object GetCode()
        //{
        //    if (Password == "abc") return code;
        //    return null;
        //}

        ////////////////////METHODE PUBLIQUE NON ENCAPSULE
        public string Code
        {
            get
            {
                if (Password == "abc") return code;
                return null;
            }
            set {
                if (Password == "abc") code = value;
            }
        }


    }
}
