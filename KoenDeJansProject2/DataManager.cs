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
            using (var Mijn_KlantenEntities = new Individueel_ProjectEntities())
            {
                return Mijn_KlantenEntities.Klants.ToList();
            }
        }

        //klanten toevoegen
        public static int InsertKlant(Klant k)
        {
            using (var Mijn_KlantEntities = new Individueel_ProjectEntities())
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
            using (var Mijn_KlantEntities = new Individueel_ProjectEntities())
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
            using (var Mijn_KlantEntities = new Individueel_ProjectEntities())
            {
                Mijn_KlantEntities.Entry(k).State = System.Data.Entity.EntityState.Modified;
                return Mijn_KlantEntities.SaveChanges();
            }
        }

        //klanten verwijderen
        public static int DeleteKlant(Klant k)
        {
            using (var Mijn_KlantEntities = new Individueel_ProjectEntities())
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
            using (var Mijn_LeverancierEntities = new Individueel_ProjectEntities())
            {
                return Mijn_LeverancierEntities.Leveranciers.ToList();
            }
        }

        // alle methodes om product gegevens in database te krijgen en bewerken

        // ophalen van producten
        public static List<Product> GetProducten()
        {
            using (var Mijn_ProductenEntities = new Individueel_ProjectEntities())
            {
                return Mijn_ProductenEntities.Products.ToList();
            }
        }

        // alle methodes om personeelsleden gegevens in database te krijgen en bewerken

        //ophalen van personeelsleden
        public static List<Personeelslid> GetPersoneelsleden()
        {
            using (var Mijn_PersoneelsEntities = new Individueel_ProjectEntities())
            {
                return Mijn_PersoneelsEntities.Personeelslids.ToList();
            }
        }

        // alle methodes om bestelling gegevens in database te krijgen en bewerken

        //bestelling ophalen

        public static List<Bestelling> GetBestellingen()
        {
            using (var Mijn_BestellingEntities = new Individueel_ProjectEntities())
            {
                return Mijn_BestellingEntities.Bestellings.ToList();
            }
        }

        // alle methodes om bestellingProduct in database te krijgen en bewerken

        //BestellingProduct ophalen
        public static List<BestellingProduct> GetBestellingProducten()
        {
            using (var Mijn_BestellingProductenEntities = new Individueel_ProjectEntities())
            {
                return Mijn_BestellingProductenEntities.BestellingProducts.ToList();
            }
        }

        // alle categorien weergeven
        public static List<Categorie> GetCategorieën()
        {
            using (var Mijn_CategorieEntities = new Individueel_ProjectEntities())
            {
                return Mijn_CategorieEntities.Categories.ToList();
            }
        }
    }
}
