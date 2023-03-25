using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Z_exo_flash
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var catFromage = new Categorie { Id = Guid.NewGuid(), Libelle = "Fromages" };
            var catSurgelé = new Categorie { Id = Guid.NewGuid(), Libelle = "Surgelés" };
            var catTraiteur = new Categorie { Id = Guid.NewGuid(), Libelle = "Traiteur" };
            var catBoisson = new Categorie { Id = Guid.NewGuid(), Libelle = "Boisson" };

            var camembert = new Produit { Id = Guid.NewGuid(), Libelle = "Président", /*CategorieProduit = catFromage,*/ Prix = 3.25M, Quantite = 100, Reduction = 0.80M };
            var pizza = new Produit { Id = Guid.NewGuid(), Libelle = "Pizza 4 Fromages", /*CategorieProduit = catSurgelé,*/ Prix = 5.5M, Quantite = 100, Reduction = 1.50M };
            var brie = new Produit { Id = Guid.NewGuid(), Libelle = "Petit Brie",/* CategorieProduit = catFromage,*/ Prix = 2.5M, Quantite = 100 };
            var briebio = new Produit("Au lait de chèvre") { Id = Guid.NewGuid(), Libelle = "Petit Brie Bio",/* CategorieProduit = catFromage,*/ Prix = 2.5M, Quantite = 100 };


            //var produits = new List<Produit>();
            //produits.Add(camembert);
            //produits.Add(brie);
            //produits.Add(pizza);
            //var cat1 = "Fromages";
            //
            //foreach (Produit produit in produits)
            //{
            //    if ( produit.CategorieProduit.Libelle == cat1 )
            //    {
            //        Console.WriteLine("\t {0} est un produit de catégorie Fromage", produit.Libelle);
            //    }
            //}

            catFromage.Produits.Add(camembert);
            catFromage.Produits.Add(brie);
            catFromage.Produits.Add(briebio);
            catSurgelé.Produits.Add(pizza);

            camembert.Categories.Add(catFromage);
            brie.Categories.Add(catFromage);
            briebio.Categories.Add(catFromage);
            pizza.Categories.Add(catSurgelé);
            pizza.Categories.Add(catTraiteur);


            Console.WriteLine("\n Afficher les produits de catégorie Fromage :");
            foreach (Produit p in catFromage.Produits)
            {
                var etoile = p.isBio() ? "*" : "";
                Console.WriteLine("\t {0} est un produit de catégorie Fromage \t {1}", p.Libelle, etoile);
            }

            //on peut maintennt avoir plusieurs catégoriés par produits!
            Console.WriteLine("\n Afficher les catégories de Pizza :");
            foreach (Categorie c in pizza.Categories) Console.WriteLine("\t {0} est une catégorie de Pizza", c.Libelle);


            //avant la création d'ube classe panier
            Console.WriteLine("\n Je veux le prix total d'un camembert et deux pizzas :");
            var panier = new List<Produit>();
            panier.Add(camembert);
            panier.Add(pizza);
            panier.Add(pizza);
            var sum = 0M;
            foreach (Produit produit in panier) sum += (produit.Prix - produit.Reduction);
            Console.WriteLine("\t Prix total : {0} Euros", sum);


            //après la création d'ube classe panier
            Console.WriteLine("\n Je veux le prix total d'un camembert et deux pizzas dans mon panier avec mes bons :");
            var monpanier = new Panier();
            monpanier.BonAchats.Add(5);
            monpanier.BonAchats.Add(2);
            monpanier.Produits.Add(camembert);
            monpanier.Produits.Add(pizza);
            monpanier.Produits.Add(pizza);
            var sum2 = 0M;
            var montantBa = 0M;

            foreach (Produit produit in panier) sum += (produit.Prix - produit.Reduction);
            foreach (var b in monpanier.BonAchats) montantBa += b;
            var total = (sum2 - montantBa);

            Console.WriteLine("\t Prix total : {0} Euros", total);
            Console.ReadLine();
        }
    }


    public class Produit : IBio
    {
        public Produit()
        {
        }
        public Produit(string label)
        {
            Label = label;
        }

        public Guid Id;
        public string Libelle;
        public Categorie CategorieProduit;
        public decimal Prix;
        public int Quantite;
        public List<Categorie> Categories = new List<Categorie>();
        public decimal Reduction;
        public string Label = "";
        public bool isBio() { return Label != "" };

    }

    public class Categorie
    {
        public Guid Id;
        public string Libelle;
        public string Nom;
        public List<Produit> Produits = new List<Produit>(); // il faut instancier pour que ça ne reste pas vide !!!

    }

    public class Panier
    {
        public List<Produit> Produits = new List<Produit>();
        public List<decimal> BonAchats = new List<decimal>();
    }

    interface IBio
    {
        bool isBio();
    }


}
