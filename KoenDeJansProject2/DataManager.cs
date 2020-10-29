using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoenDeJansProject2
{
    class DataManager
    {
        //alle methodes om klanten gegevens in database te krijgen en bewerken

        //klanten ophalen
        public static List<Klant> GetKlanten()
        {
            using (var Mijn_KlantenEntities = new Individueel_ProjectEntities2())
            {
                return Mijn_KlantenEntities.Klants.ToList();
            }
        }

        //klanten toevoegen
        public static int InsertKlant(Klant k)
        {
            using (var Mijn_KlantEntities = new Individueel_ProjectEntities2())
            {
                Mijn_KlantEntities.Klants.Add(k);
                if (0 < Mijn_KlantEntities.SaveChanges())
                {
                    return Convert.ToInt32(k.KlantID);
                }
                return 0;
            }
        }

        //ophalen klanten per ID
        public static Klant GetKlantById(int kID)
        {
            using (var Mijn_KlantEntities = new Individueel_ProjectEntities2())
            {
                var query = from klant in Mijn_KlantEntities.Klants
                            where klant.KlantID == kID
                            select klant;
                var t = query.FirstOrDefault();
                return t;
            }
        }

        //klanten wijzigen
        public static int KlantWijzigen(Klant k)
        {
            using (var Mijn_KlantEntities = new Individueel_ProjectEntities2())
            {
                Mijn_KlantEntities.Entry(k).State = System.Data.Entity.EntityState.Modified;
                return Mijn_KlantEntities.SaveChanges();
            }
        }

        //klanten verwijderen
        public static int DeleteKlant(Klant k)
        {
            using (var Mijn_KlantEntities = new Individueel_ProjectEntities2())
            {
                var query = from klant in Mijn_KlantEntities.Klants
                            where klant.KlantID == k.KlantID
                            select klant;
                Klant kn = query.FirstOrDefault();
                Mijn_KlantEntities.Klants.Remove(kn);
                return Mijn_KlantEntities.SaveChanges();
            }
        }

        //alle methodes om leveranciers gegevens in database te krijgen en bewerken


        // leveranciers gegevens ophalen
        public static List<Leverancier> GetLeveranciers()
        {
            using (var Mijn_LeverancierEntities = new Individueel_ProjectEntities2())
            {
                return Mijn_LeverancierEntities.Leveranciers.ToList();
            }
        }

        // leverancier toevoegen
        public static int InsertLeverancier(Leverancier l)
        {
            using (var Mijn_LeverancierEntities = new Individueel_ProjectEntities2())
            {
                Mijn_LeverancierEntities.Leveranciers.Add(l);
                if (0 < Mijn_LeverancierEntities.SaveChanges())
                {
                    return Convert.ToInt32(l.LeverancierID);
                }
                return 0;
            }
        }

        //leverancier verwijderen
        public static int DeleteLeverancier(Leverancier l)
        {
            using (var Mijn_LeverancierEntities = new Individueel_ProjectEntities2())
            {
                var query = from leverancier in Mijn_LeverancierEntities.Leveranciers
                            where leverancier.LeverancierID == l.LeverancierID
                            select leverancier;
                Leverancier ln = query.FirstOrDefault();
                Mijn_LeverancierEntities.Leveranciers.Remove(ln);
                return Mijn_LeverancierEntities.SaveChanges();
            }
        }

        //leverancier zoeken per ID
        public static Leverancier GetLeverancierById(int lID)
        {
            using (var Mijn_LeverancierEntities = new Individueel_ProjectEntities2())
            {
                var query = from leverancier in Mijn_LeverancierEntities.Leveranciers
                            where leverancier.LeverancierID == lID
                            select leverancier;
                var t = query.FirstOrDefault();
                return t;
            }
        }

        //leveranciers gegevens wijzigen 
        public static int LeverancierWijzigen(Leverancier l)
        {
            using (var Mijn_LeverancierEntities = new Individueel_ProjectEntities2())
            {
                Mijn_LeverancierEntities.Entry(l).State = System.Data.Entity.EntityState.Modified;
                return Mijn_LeverancierEntities.SaveChanges();
            }
        }






        // alle methodes om product gegevens in database te krijgen en bewerken

        // ophalen van producten
        public static List<Product> GetProducten()
        {
            using (var Mijn_ProductenEntities = new Individueel_ProjectEntities2())
            {
                return Mijn_ProductenEntities.Products.ToList();
            }
        }

        // nieuw product toevoegen
        public static int InsertProduct(Product p)
        {
            using (var Mijn_ProductEntities = new Individueel_ProjectEntities2())
            {
                Mijn_ProductEntities.Products.Add(p);
                if (0 < Mijn_ProductEntities.SaveChanges())
                {
                    return Convert.ToInt32(p.ProductID);
                }
                return 0;
            }
        }

        //product verwijderen
        public static int DeleteProduct(Product p)
        {
            using (var Mijn_ProductEntities = new Individueel_ProjectEntities2())
            {
                var query = from product in Mijn_ProductEntities.Products
                            where product.ProductID == p.ProductID
                            select product;
                Product pn = query.FirstOrDefault();
                Mijn_ProductEntities.Products.Remove(pn);
                return Mijn_ProductEntities.SaveChanges();
            }
        }

        //ophalen product met productID
        public static Product GetProductById(int pID)
        {
            using (var Mijn_ProductEntities = new Individueel_ProjectEntities2())
            {
                var query = from product in Mijn_ProductEntities.Products
                            where product.ProductID == pID
                            select product;
                var t = query.FirstOrDefault();
                return t;
            }
        }

        //wijziging van product
        public static int ProductWijzigen(Product p)
        {
            using (var Mijn_ProductEntities = new Individueel_ProjectEntities2())
            {
                Mijn_ProductEntities.Entry(p).State = System.Data.Entity.EntityState.Modified;
                return Mijn_ProductEntities.SaveChanges();
            }
        }

        // alle methodes om personeelsleden gegevens in database te krijgen en bewerken

        //ophalen van personeelsleden
        public static List<Personeelslid> GetPersoneelsleden()
        {
            using (var Mijn_PersoneelsEntities = new Individueel_ProjectEntities2())
            {
                return Mijn_PersoneelsEntities.Personeelslids.ToList();
            }
        }

        // toevoegen van personeelslid
        public static int InsertPersoneelslid(Personeelslid p)
        {
            using (var Mijn_PersoneelEntities = new Individueel_ProjectEntities2())
            
            {
                Mijn_PersoneelEntities.Personeelslids.Add(p);
                if (0 < Mijn_PersoneelEntities.SaveChanges())
                {
                    return Convert.ToInt32(p.PersoneelslidID);
                }
                return 0;
            }
        }

        // verwijderen van personeelslid
        public static int DeletePersoneelslid(Personeelslid p)
        {
            using (var Mijn_PersoneelEntities = new Individueel_ProjectEntities2())
            {
                var query = from personeel in Mijn_PersoneelEntities.Personeelslids
                            where personeel.PersoneelslidID == p.PersoneelslidID
                            select personeel;
                Personeelslid pn = query.FirstOrDefault();
                Mijn_PersoneelEntities.Personeelslids.Remove(pn);
                return Mijn_PersoneelEntities.SaveChanges();
            }
        }

        // ophalen van personeelslid ID
        public static Personeelslid GetPersoneelslidById(int pID)
        {
            using (var Mijn_PersoneelEntities = new Individueel_ProjectEntities2())
            {
                var query = from personeel in Mijn_PersoneelEntities.Personeelslids
                            where personeel.PersoneelslidID == pID
                            select personeel;
                var t = query.FirstOrDefault();
                return t;
            }
        }

        // aanpassen van gegevens van personeelslid
        public static int PersoneelslidWijzigen(Personeelslid p)
        {
            using (var Mijn_PersoneelEntities = new Individueel_ProjectEntities2())
            {
                Mijn_PersoneelEntities.Entry(p).State = System.Data.Entity.EntityState.Modified;
                return Mijn_PersoneelEntities.SaveChanges();
            }
        }



        // alle methodes om bestelling gegevens in database te krijgen en bewerken

        //bestelling ophalen

        public static List<Bestelling> GetBestellingen()
        {
            using (var Mijn_BestellingEntities = new Individueel_ProjectEntities2())
            {
                return Mijn_BestellingEntities.Bestellings.ToList();
            }
        }

        // bestelling ingeven
        public static int InsertBestelling(Bestelling b)
        {
            using (var Mijn_BestellingEntities = new Individueel_ProjectEntities2())
            {
                Mijn_BestellingEntities.Bestellings.Add(b);
                if (0 < Mijn_BestellingEntities.SaveChanges())
                {
                    return Convert.ToInt32(b.BestellingID);
                }
                return 0;
            }
        }

        // bestelling verwijderen
        public static int DeleteBestelling(Bestelling b)
        {
            using (var Mijn_BestellingEntities = new Individueel_ProjectEntities2())
            {
                var query = from bestelling in Mijn_BestellingEntities.Bestellings
                            where bestelling.BestellingID == b.BestellingID
                            select bestelling;
                Bestelling pn = query.FirstOrDefault();
                Mijn_BestellingEntities.Bestellings.Remove(pn);
                return Mijn_BestellingEntities.SaveChanges();
            }
        }

        //bestelling ophalen per ID
        public static Bestelling GetBestellingbyId(int pID)
        {
            using (var Mijn_BestellingEntities = new Individueel_ProjectEntities2())
            {
                var query = from bestelling in Mijn_BestellingEntities.Bestellings
                            where bestelling.BestellingID == pID
                            select bestelling;
                var t = query.FirstOrDefault();
                return t;
            }
        }

        //wijzigen van bestelling
        public static int BestellinglidWijzigen(Bestelling p)
        {
            using (var Mijn_BestellingEntities = new Individueel_ProjectEntities2())
            {
                Mijn_BestellingEntities.Entry(p).State = System.Data.Entity.EntityState.Modified;
                return Mijn_BestellingEntities.SaveChanges();
            }
        }


        // alle methodes om bestellingProduct in database te krijgen en bewerken

        //BestellingProduct ophalen
        public static List<BestellingProduct> GetBestellingProducten()
        {
            using (var Mijn_BestellingProductenEntities = new Individueel_ProjectEntities2())
            {
                return Mijn_BestellingProductenEntities.BestellingProducts.ToList();
            }
        }

        // alle categorien weergeven
        public static List<Categorie> GetCategorieën()
        {
            using (var Mijn_CategorieEntities = new Individueel_ProjectEntities2())
            {
                return Mijn_CategorieEntities.Categories.ToList();
            }
        }

        // categorie toevoegen
        public static int InsertCategorie(Categorie c)
        {
            using (var Mijn_CategorieEntities = new Individueel_ProjectEntities2())
            {
                Mijn_CategorieEntities.Categories.Add(c);
                if (0 < Mijn_CategorieEntities.SaveChanges())
                {
                    return Convert.ToInt32(c.CategorieID);
                }
                return 0;
            }
        }

        // categorie verwijderen
        public static int DeleteCategorie(Categorie c)
        {
            using (var Mijn_CategorieEntities = new Individueel_ProjectEntities2())
            {
                var query = from categorie in Mijn_CategorieEntities.Categories
                            where categorie.CategorieID == c.CategorieID
                            select categorie;
                Categorie cn = query.FirstOrDefault();
                Mijn_CategorieEntities.Categories.Remove(cn);
                return Mijn_CategorieEntities.SaveChanges();
            }
        }

        // categorie per ID
        public static Categorie GetCategorieById(int cID)
        {
            using (var Mijn_CategorieEntities = new Individueel_ProjectEntities2())
            {
                var query = from categorie in Mijn_CategorieEntities.Categories
                            where categorie.CategorieID == cID
                            select categorie;
                var t = query.FirstOrDefault();
                return t;
            }
        }

        // categorie wijzigen
        public static int CategorieWijzigen(Categorie c)
        {
            using (var Mijn_CategorieEntities = new Individueel_ProjectEntities2())
            {
                Mijn_CategorieEntities.Entry(c).State = System.Data.Entity.EntityState.Modified;
                return Mijn_CategorieEntities.SaveChanges();
            }
        }




    }
}
