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
    /// Interaction logic for Databeheer_Bestelling.xaml
    /// </summary>
    public partial class Databeheer_Bestelling : Window
    {
        public Databeheer_Bestelling()
        {
            InitializeComponent();
        }

        private void btnOverzicht_Click(object sender, RoutedEventArgs e)
        {

        }        
        
        private void btnToevoegen_Click(object sender, RoutedEventArgs e)
        {
                Bestelling_Klant_aanmaken BestellingKlant = new Bestelling_Klant_aanmaken();
                BestellingKlant.ShowDialog();
        }
        
    }
}
