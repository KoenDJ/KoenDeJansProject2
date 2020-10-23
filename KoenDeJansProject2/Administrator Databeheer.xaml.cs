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
    /// Interaction logic for Administrator_Databeheer.xaml
    /// </summary>
    public partial class Administrator_Databeheer : Window
    {
        public Administrator_Databeheer()
        {
            InitializeComponent();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void mnLeverancier_Click(object sender, RoutedEventArgs e)
        {

        }

        private void mnKlant_Click(object sender, RoutedEventArgs e)
        {
            Databeheer_Klant Dataklant = new Databeheer_Klant();
            Dataklant.ShowDialog();
        }

        private void mnProduct_Click(object sender, RoutedEventArgs e)
        {

        }

        private void mnCategorie_Click(object sender, RoutedEventArgs e)
        {

        }

        private void mnPersoneelslid_Click(object sender, RoutedEventArgs e)
        {

        }

        private void mnBestelling_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
