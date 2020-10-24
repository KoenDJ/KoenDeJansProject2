using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace KoenDeJansProject2
{
    /// <summary>
    /// Interaction logic for Databeheer_Klant.xaml
    /// </summary>
    public partial class Databeheer_Klant : Window
    {
        // In deze window activeer ik de buttons voor scherm klanten
        // via dit scherm doe ik al de aanpassingen voor mijn klanten

        public Databeheer_Klant()
        {
            InitializeComponent();
        }

        //overzicht van de klanten
        private void btnOverzicht_Click(object sender, RoutedEventArgs e)
        {
            grdKlanten.ItemsSource = null;
            grdKlanten.ItemsSource = DataManager.GetKlanten();

        }

        //verwijderen van klant
        private void btnVerwijderen_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Bent u zeker dat u deze klant wil verwijderen", "Opgelet", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {

                Klant k = DataManager.GetKlantById(Convert.ToInt32(txtID.Text));
                {
                    int ok = DataManager.DeleteKlant(k);
                    if (ok > 0)
                    {
                        grdKlanten.ItemsSource = null;
                        grdKlanten.ItemsSource = DataManager.GetKlanten();
                        MessageBox.Show("Het verwijderen van de klant is gelukt");
                        Opruimen();
                    }
                    else
                    {
                        MessageBox.Show("Het verwijderen van de klant is niet gelukt");
                        Opruimen();
                    }
                }
            }
        }

        //toevoegen van klant
        private void btnToevoegen_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Klant k = new Klant()
                {
                    Voornaam = txtVoornaam.Text,
                    Achternaam = txtAchternaam.Text,
                    AangemaaktOp = Convert.ToDateTime(txtAangemaaktOp.Text),
                    Straatnaam = txtStraatnaam.Text,
                    Bus = txtBus.Text,
                    Emailadres = txtMail.Text,
                    Gemeente = txtGemeente.Text,
                    Huisnummer = txtHuisnr.Text,
                    KlantID = Convert.ToInt32(txtID.Text),
                    Postcode = txtPostcode.Text,
                    Telefoonnummer = txtTelefoonnr.Text,
                    Opmerking = txtOpmerking.Text,
                };
                int ok = DataManager.InsertKlant(k);
                if (ok > 0)
                {
                    grdKlanten.ItemsSource = null;
                    grdKlanten.ItemsSource = DataManager.GetKlanten();
                    MessageBox.Show("Het toevoegen van de klant is gelukt");
                    Opruimen();
                }
                else
                {
                    MessageBox.Show("Het toevoegen van de klant is niet gelukt");
                    Opruimen();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Er is een fout gebeurd:" + ex.Message);
                Opruimen();
            }
        }
        
        //wijzigen van klant
        private void btnWijzigen_Click(object sender, RoutedEventArgs e)
        {
            Klant k = DataManager.GetKlantById(Convert.ToInt32(txtID.Text));
            if (k != null)
            {
                if (MessageBox.Show("Bent u zeker dat u de klant op deze manier wilt wijzigen?", "vraag", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {

                    k.Voornaam = txtVoornaam.Text;
                    k.Achternaam = txtAchternaam.Text;
                    k.AangemaaktOp = Convert.ToDateTime(txtAangemaaktOp.Text);
                    k.Straatnaam = txtStraatnaam.Text;
                    k.Bus = (txtBus.Text);
                    k.Emailadres = txtMail.Text;
                    k.Gemeente = txtGemeente.Text;
                    k.Huisnummer = (txtHuisnr.Text);
                    k.KlantID = Convert.ToInt32(txtID.Text);
                    k.Postcode = txtPostcode.Text;
                    k.Telefoonnummer = txtTelefoonnr.Text;
                    k.Opmerking = txtOpmerking.Text;
                    int ok = DataManager.KlantWijzigen(k);
                    if (ok > 0)
                    {
                        DataManager.GetKlanten().Clear();
                        grdKlanten.ItemsSource = null;
                        grdKlanten.ItemsSource = DataManager.GetKlanten();
                        MessageBox.Show("Het wijzigen van de klant is gelukt");
                        Opruimen();
                    }
                    else
                    {
                        MessageBox.Show(" Het wijzigen van de klant is niet gelukt");
                        Opruimen();
                    }

                }
                Opruimen();
            }
            else
            {
                MessageBox.Show("Er staat geen klant met deze ID in de databank");
                Opruimen();
            }
        }

        //zoeken van een klant, enkel via ID van de klant
        private void btn1tonen_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Klant k = DataManager.GetKlantById(Convert.ToInt32(txtID.Text));
                if (k != null)
                {
                    txtVoornaam.Text = k.Voornaam;
                    txtAchternaam.Text = k.Achternaam;
                    txtStraatnaam.Text = k.Straatnaam;
                    txtBus.Text = k.Bus.ToString();
                    txtMail.Text = k.Emailadres.ToString();
                    txtGemeente.Text = k.Gemeente;
                    txtHuisnr.Text = k.Huisnummer.ToString();
                    txtID.Text = k.KlantID.ToString();
                    txtPostcode.Text = k.Postcode.ToString();
                    txtTelefoonnr.Text = k.Telefoonnummer.ToString();
                    txtAangemaaktOp.Text = k.AangemaaktOp.ToString();
                    txtOpmerking.Text = k.Opmerking.ToString();
                }
                else
                {
                    MessageBox.Show("Er staat geen klant met deze ID in de databank");
                    Opruimen();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        //methode om alles te wissen (clearen)
        private void Opruimen()
        {
            txtBus.Clear();
            txtVoornaam.Clear();
            txtAchternaam.Clear();
            txtStraatnaam.Clear();
            txtGemeente.Clear();
            txtHuisnr.Clear();
            txtID.Clear();
            txtPostcode.Clear();
            txtAangemaaktOp.Clear();
            txtMail.Clear();
            txtOpmerking.Clear();
            txtTelefoonnr.Clear();
        }

        // geselecteerde rij
        private void grdKlanten_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                Klant k = (Klant)grdKlanten.SelectedItem;
                if (k != null)

                {
                    txtVoornaam.Text = k.Voornaam;
                    txtAchternaam.Text = k.Achternaam;
                    txtStraatnaam.Text = k.Straatnaam;
                    txtBus.Text = k.Bus;
                    txtMail.Text = k.Emailadres;
                    txtGemeente.Text = k.Gemeente;
                    txtHuisnr.Text = k.Huisnummer.ToString();
                    txtID.Text = k.KlantID.ToString();
                    txtPostcode.Text = k.Postcode.ToString();
                    txtTelefoonnr.Text = k.Telefoonnummer;
                    txtAangemaaktOp.Text = k.AangemaaktOp.ToString();
                    txtOpmerking.Text = k.Opmerking;
                    DataManager.KlantWijzigen(k);
                }
            }
            catch
            {
                MessageBox.Show("Gelieve geen lege rij te selecteren.");
            }
        }
    }
}
