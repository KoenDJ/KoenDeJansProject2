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
    /// Interaction logic for Databeheer_Leverancier.xaml
    /// </summary>
    public partial class Databeheer_Leverancier : Window
    {
        public Databeheer_Leverancier()
        {
            InitializeComponent();
        }

        // overzicht van de lijst van leveranciers
        private void btnOverzicht_Click(object sender, RoutedEventArgs e)
        {
            dgOverzichtLeveranciers.ItemsSource = null;
            if (DataManager.GetLeveranciers() != null)
            {
                dgOverzichtLeveranciers.ItemsSource = DataManager.GetLeveranciers();
            }
            else
            {
                MessageBox.Show("Er staan momenteel geen leveranciers in onze database.");
            }
        }

        // verwijderen van leveranciers
        private void btnVerwijderen_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Bent u zeker dat u deze leverancier wil verwijderen", "Opgelet", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                try
                {
                    Leverancier l = DataManager.GetLeverancierById(Convert.ToInt32(txtID.Text));
                    {
                        int ok = DataManager.DeleteLeverancier(l);
                        if (ok > 0)
                        {
                            dgOverzichtLeveranciers.ItemsSource = null;
                            dgOverzichtLeveranciers.ItemsSource = DataManager.GetLeveranciers();
                            MessageBox.Show("Het verwijderen van de leverancier is gelukt");
                            Opruimen();
                        }
                        else
                        {
                            MessageBox.Show("Het verwijderen van de leverancier is niet gelukt");
                            Opruimen();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Er is een fout gebeurd:" + ex.Message);
                    Opruimen();
                }
            }
        }

        // toevoegen van leveranciers
        private void btnToevoegen_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Leverancier l = new Leverancier()
                {
                    LeverancierID = Convert.ToInt32(txtID.Text),
                    Contactpersoon = txtContact.Text,
                    Emailadres = txtEmail.Text,
                    Huisnummer = txtHuisnr.Text,
                    Gemeente = txtGemeente.Text,
                    Bus = txtBus.Text,
                    Postcode = Convert.ToInt32(txtPostcode.Text),
                    Telefoonnummer = txtTelefoonnr.Text.ToString()
                };
                int ok = DataManager.InsertLeverancier(l);
                if (ok > 0)
                {
                    dgOverzichtLeveranciers.ItemsSource = null;
                    dgOverzichtLeveranciers.ItemsSource = DataManager.GetLeveranciers();
                    MessageBox.Show("Het toevoegen van de leverancier is gelukt");
                    Opruimen();
                }
                else
                {
                    MessageBox.Show("Het toevoegen van de leverancier is niet gelukt");
                    Opruimen();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Er is een fout gebeurd:" + ex.Message);
                Opruimen();
            }
        }

        //wijzigen van leveranciers gegevens
        private void btnWijzigen_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Leverancier l = DataManager.GetLeverancierById(Convert.ToInt32(txtID.Text));
                if (l != null)
                {
                    if (MessageBox.Show("Bent u zeker dat u de leverancier op deze manier wilt wijzigen?", "vraag", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                    {
                        try
                        {
                            l.Bus = txtBus.Text;
                            l.Contactpersoon = txtContact.Text;
                            l.Emailadres = txtEmail.Text;
                            l.Gemeente = txtGemeente.Text;
                            l.Huisnummer = txtHuisnr.Text;
                            l.LeverancierID = Convert.ToInt32(txtID.Text);
                            l.Postcode = Convert.ToInt32(txtPostcode.Text);
                            l.Telefoonnummer = txtTelefoonnr.Text;
                            int ok = DataManager.LeverancierWijzigen(l);
                            if (ok > 0)
                            {
                                DataManager.GetLeveranciers().Clear();
                                dgOverzichtLeveranciers.ItemsSource = null;
                                dgOverzichtLeveranciers.ItemsSource = DataManager.GetLeveranciers();
                                MessageBox.Show("Het wijzigen van de leverancier is gelukt");
                                Opruimen();
                            }
                            else
                            {
                                MessageBox.Show(" Het wijzigen van de leverancier is niet gelukt");
                                Opruimen();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("error" + ex.Message);
                        }
                    }
                    Opruimen();
                }
                else
                {
                    MessageBox.Show("Er staat geen leverancier met deze ID in de databank");
                    Opruimen();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //zoeken van leverancier aan de hand van leveranciersID
        private void btn1tonen_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Leverancier l = DataManager.GetLeverancierById(Convert.ToInt32(txtID.Text));
                if (l != null)
                {
                    txtBus.Text = l.Bus.ToString();
                    txtContact.Text = l.Contactpersoon;
                    txtEmail.Text = l.Emailadres.ToString();
                    txtGemeente.Text = l.Gemeente;
                    txtHuisnr.Text = l.Huisnummer.ToString();
                    txtID.Text = l.LeverancierID.ToString();
                    txtPostcode.Text = l.Postcode.ToString();
                    txtTelefoonnr.Text = l.Telefoonnummer;
                }
                else
                {
                    MessageBox.Show("Er staat geen leverancier met deze ID in de databank");
                    Opruimen();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgOverzichtLeveranciers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                Leverancier l = (Leverancier)dgOverzichtLeveranciers.SelectedItem;
                if (l != null)
                {
                    txtBus.Text = l.Bus.ToString();
                    txtContact.Text = l.Contactpersoon;
                    txtEmail.Text = l.Emailadres.ToString();
                    txtGemeente.Text = l.Gemeente;
                    txtHuisnr.Text = l.Huisnummer.ToString();
                    txtID.Text = l.LeverancierID.ToString();
                    txtPostcode.Text = l.Postcode.ToString();
                    txtTelefoonnr.Text = l.Telefoonnummer;
                    DataManager.LeverancierWijzigen(l);
                }
            }

            catch
            {
                MessageBox.Show("Gelieve geen lege rij te selecteren.");
            }
        }

        private void Opruimen()
        {
            txtBus.Clear();
            txtContact.Clear();
            txtEmail.Clear();
            txtGemeente.Clear();
            txtHuisnr.Clear();
            txtID.Clear();
            txtPostcode.Clear();
            txtTelefoonnr.Clear();
        }
    }
}
