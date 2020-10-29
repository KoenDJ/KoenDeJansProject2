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
    /// Interaction logic for Bestelling_Klant_aanmaken.xaml
    /// </summary>
    public partial class Bestelling_Klant_aanmaken : Window
    {
        public Bestelling_Klant_aanmaken()
        {
            InitializeComponent();
            CbCategorieën.ItemsSource = DataManager.GetCategorieën();
        }

        private void CbCategorieën_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
