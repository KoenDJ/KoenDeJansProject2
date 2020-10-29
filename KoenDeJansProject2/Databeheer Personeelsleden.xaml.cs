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
    /// Interaction logic for Databeheer_Personeelsleden.xaml
    /// </summary>
    public partial class Databeheer_Personeelsleden : Window
    {
        public Databeheer_Personeelsleden()
        {
            InitializeComponent();
        }

        // overzicht personeelsleden
        private void btnOverzicht_Click(object sender, RoutedEventArgs e)
        {
            grdPersoneel.ItemsSource = null;
            grdPersoneel.ItemsSource = DataManager.GetPersoneelsleden();
        }


        // personeelsleid verwijderen
        private void btnVerwijderen_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Bent u zeker dat u dit personeelslid wil verwijderen", "Opgelet", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                try
                {
                    Personeelslid p = DataManager.GetPersoneelslidById(Convert.ToInt32(txtID.Text));
                    {
                        int ok = DataManager.DeletePersoneelslid(p);
                        if (ok > 0)
                        {
                            grdPersoneel.ItemsSource = null;
                            grdPersoneel.ItemsSource = DataManager.GetPersoneelsleden();
                            MessageBox.Show("Het verwijderen van het personeelslid is gelukt");
                            Opruimen();
                        }
                        else
                        {
                            MessageBox.Show("Het verwijderen van het personeelslid is niet gelukt");
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

        // personeelslid toevoegen
        private void btnToevoegen_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Personeelslid p = new Personeelslid()
                {
                    Voornaam = txtVoornaam.Text,
                    //Achternaam = txtAchternaam.Text,
                    PersoneelslidID = Convert.ToInt32(txtID.Text),
                };
                int ok = DataManager.InsertPersoneelslid(p);
                if (ok > 0)
                {
                    grdPersoneel.ItemsSource = null;
                    grdPersoneel.ItemsSource = DataManager.GetPersoneelsleden();
                    MessageBox.Show("Het toevoegen van het personeelslid is gelukt");
                    Opruimen();
                }
                else
                {
                    MessageBox.Show("Het toevoegen van het personeelslid is niet gelukt");
                    Opruimen();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Er is een fout gebeurd:" + ex.Message);
                Opruimen();
            }
        }

        // gegevens personeelslid wijzigen
        private void btnWijzigen_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Personeelslid p = DataManager.GetPersoneelslidById(Convert.ToInt32(txtID.Text));
                if (p != null)
                {
                    if (MessageBox.Show("Bent u zeker dat u het personeelslid op deze manier wilt wijzigen?", "vraag", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                    {
                        try
                        {
                            p.PersoneelslidID = Convert.ToInt32(txtID.Text);
                            p.Voornaam = txtVoornaam.Text;
                           // p.Achternaam = txtAchternaam.Text;
                            int ok = DataManager.PersoneelslidWijzigen(p);
                            if (ok > 0)
                            {
                                DataManager.GetPersoneelsleden().Clear();
                                grdPersoneel.ItemsSource = null;
                                grdPersoneel.ItemsSource = DataManager.GetPersoneelsleden();
                                MessageBox.Show("Het wijzigen van het personeelslid is gelukt");
                                Opruimen();
                            }
                            else
                            {
                                MessageBox.Show(" Het wijzigen van het personeelslid is niet gelukt");
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
                    MessageBox.Show("Er staat geen personeelslid met deze ID in de databank");
                    Opruimen();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // geselecteerde personeelslid
        private void grdPersoneel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                Personeelslid p = (Personeelslid)grdPersoneel.SelectedItem;
                if (p != null)
                {
                    txtVoornaam.Text = p.Voornaam;
                    //txtAchternaam.Text = p.Achternaam;
                    txtID.Text = p.PersoneelslidID.ToString();
                    DataManager.PersoneelslidWijzigen(p);
                }

            }
            catch
            {
                MessageBox.Show("Gelieve geen lege rij te selecteren.");
            }
        }
        private void Opruimen()
        {
            //txtAchternaam.Clear();
            txtVoornaam.Clear();
            txtID.Clear();
        }
    }
}
