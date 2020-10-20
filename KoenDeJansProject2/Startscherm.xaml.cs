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
    /// Interaction logic for Startscherm.xaml
    /// </summary>
    public partial class Startscherm : Window
        // Dit is mijn scherm na de login
    {
        public Startscherm()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            lblWelkom.Content = "Welkom " + ((MainWindow)Application.Current.MainWindow).cbGebruiker.SelectedValue + "  " + ((MainWindow)Application.Current.MainWindow).txtNaam.Text;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnOverzicht_Click(object sender, RoutedEventArgs e)
        {
            Administrator_Overzicht adminoverzicht = new Administrator_Overzicht();
            adminoverzicht.ShowDialog();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Administrator_Databeheer admindatabeheer = new Administrator_Databeheer();
            admindatabeheer.ShowDialog();
        }
    }
}
