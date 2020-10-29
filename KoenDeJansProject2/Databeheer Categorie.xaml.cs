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
    /// Interaction logic for Databeheer_Categorie.xaml
    /// </summary>
    public partial class Databeheer_Categorie : Window
    {
        public Databeheer_Categorie()
        {
            InitializeComponent();
        }

        // overzicht van de categorieën
        private void btnOverzicht_Click(object sender, RoutedEventArgs e)
        {
            grdCategorie.ItemsSource = null;
            grdCategorie.ItemsSource = DataManager.GetCategorieën();
        }


        // categorie verwijderen
        private void btnVerwijderen_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Bent u zeker dat u deze categorie wil verwijderen", "Opgelet", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                try
                {
                    Categorie c = DataManager.GetCategorieById(Convert.ToInt32(txtID.Text));
                    {
                        int ok = DataManager.DeleteCategorie(c);
                        if (ok > 0)
                        {
                            grdCategorie.ItemsSource = null;
                            grdCategorie.ItemsSource = DataManager.GetCategorieën();
                            MessageBox.Show("Het verwijderen van de Categorie is gelukt");
                            Opruimen();
                        }
                        else
                        {
                            MessageBox.Show("Het verwijderen van de Categorie is niet gelukt");
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

        private void btnToevoegen_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Categorie c = new Categorie()
                {
                    CategorieID = Convert.ToInt32(txtID.Text),
                    CategorieNaam = txtNaam.Text
                };
                int ok = DataManager.InsertCategorie(c);
                if (ok > 0)
                {
                    grdCategorie.ItemsSource = null;
                    grdCategorie.ItemsSource = DataManager.GetCategorieën();
                    MessageBox.Show("Het toevoegen van de categorie is gelukt");
                    Opruimen();
                }
                else
                {
                    MessageBox.Show("Het toevoegen van de categorie is niet gelukt");
                    Opruimen();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Er is een fout gebeurd:" + ex.Message);
                Opruimen();
            }
        }

        private void btnWijzigen_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Categorie c = DataManager.GetCategorieById(Convert.ToInt32(txtID.Text));
                if (c != null)
                {
                    if (MessageBox.Show("Bent u zeker dat u de categorie op deze manier wilt wijzigen?", "vraag", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                    {
                        try
                        {
                            c.CategorieID = Convert.ToInt32(txtID.Text);
                            c.CategorieNaam = txtNaam.Text;
                            int ok = DataManager.CategorieWijzigen(c);
                            if (ok > 0)
                            {
                                DataManager.GetCategorieën().Clear();
                                grdCategorie.ItemsSource = null;
                                grdCategorie.ItemsSource = DataManager.GetCategorieën();
                                MessageBox.Show("Het wijzigen van de categorie is gelukt");
                                Opruimen();
                            }
                            else
                            {
                                MessageBox.Show(" Het wijzigen van de categorie is niet gelukt");
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
                    MessageBox.Show("Er staat geen categorie met deze ID in de databank");
                    Opruimen();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void btn1tonen_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Categorie c = DataManager.GetCategorieById(Convert.ToInt32(txtID.Text));
                if (c != null)
                {
                    txtID.Text = c.CategorieID.ToString();
                    txtNaam.Text = c.CategorieNaam;
                }
                else
                {
                    MessageBox.Show("Er staat geen categorie met deze ID in de databank");
                    Opruimen();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Opruimen()
        {
            txtID.Clear();
            txtNaam.Clear();
        }

        private void grdCategorie_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                Categorie c = (Categorie)grdCategorie.SelectedItem;
                if (c != null)
                {
                    txtID.Text = c.CategorieID.ToString();
                    txtNaam.Text = c.CategorieNaam;

                    DataManager.CategorieWijzigen(c);
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
