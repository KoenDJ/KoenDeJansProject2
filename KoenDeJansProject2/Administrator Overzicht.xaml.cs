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
    /// Interaction logic for Administrator_Overzicht.xaml
    /// </summary>
    public partial class Administrator_Overzicht : Window
    {
        // In deze window worden alle buttonsweergegeven, waar we op klikken om gevens uit dataManager te activeren
        public Administrator_Overzicht()
        {
            InitializeComponent();
        }

        private void btnKlanten_Click(object sender, RoutedEventArgs e)
        {
            dgOverzicht.ItemsSource = null;
            if (DataManager.GetKlanten() != null)
            {
                dgOverzicht.ItemsSource = DataManager.GetKlanten();
            }
            else
            {
                MessageBox.Show("Er staan momenteel geen klanten in onze database.");
            }

        }

        private void btnLeveranciers_Click(object sender, RoutedEventArgs e)
        {
            dgOverzicht.ItemsSource = null;
            if (DataManager.GetLeveranciers() != null)
            {
                dgOverzicht.ItemsSource = DataManager.GetLeveranciers();
            }
            else
            {
                MessageBox.Show("Er staan momenteel geen leveranciers in onze database.");
            }
        }

        private void btnProducten_Click(object sender, RoutedEventArgs e)
        {
            dgOverzicht.ItemsSource = null;
            if (DataManager.GetProducten() != null)
            {
                dgOverzicht.ItemsSource = DataManager.GetProducten();
            }
            else
            {
                MessageBox.Show("Er staan momenteel geen producten in onze database.");
            }
        }

        private void btnBestellingen_Click(object sender, RoutedEventArgs e)
        {
            dgOverzicht.ItemsSource = null;
            if (DataManager.GetBestellingen() != null)
            {
                dgOverzicht.ItemsSource = DataManager.GetBestellingen();
            }
            else
            {
                MessageBox.Show("Er staan momenteel geen bestellingen in onze database.");
            }
        }

        private void btnBestellingProducten_Click(object sender, RoutedEventArgs e)
        {
            dgOverzicht.ItemsSource = null;
            if (DataManager.GetBestellingProducten() != null)
            {
                dgOverzicht.ItemsSource = DataManager.GetBestellingProducten();
            }
            else
            {
                MessageBox.Show("Er staan momenteel geen bestelde producten in onze database.");
            }
        }

        private void btnPersoneel_Click(object sender, RoutedEventArgs e)
        {
            dgOverzicht.ItemsSource = null;
            dgOverzicht.ItemsSource = DataManager.GetPersoneelsleden();
            if (dgOverzicht.ItemsSource == null)
            {
                dgOverzicht.Items.Add("blabla");
            }
        }

        private void btnCatagorie_Click(object sender, RoutedEventArgs e)
        {
            dgOverzicht.ItemsSource = null;
            if (DataManager.GetCategorieën() != null)
            {
                dgOverzicht.ItemsSource = DataManager.GetCategorieën();
            }
            else
            {
                MessageBox.Show("Geen categorieën in de database.");
            }
        }
    }
}
