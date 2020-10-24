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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KoenDeJansProject2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cbGebruiker.Items.Add("Administrator");
            cbGebruiker.Items.Add("Verkoper");
            cbGebruiker.Items.Add("Magazijnier");
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                if (cbGebruiker.SelectedValue == null)
                {
                    MessageBox.Show("Gelieve een gebruikerstype aan te duiden.");
                }
                else
                {
                    if (txtNaam.Text == "Koen De Jans" && txtWachtwoord.Password == "123" && cbGebruiker.SelectedValue == "Administrator")
                    {
                        Startscherm startscherm = new Startscherm();
                        Hide();
                        startscherm.ShowDialog();
                    }
                    else if (txtNaam.Text == "Koen" && txtWachtwoord.Password == "" && cbGebruiker.SelectedValue == "Magazijnier")
                    {
                        Startscherm startscherm = new Startscherm();
                        Hide();
                        startscherm.ShowDialog();
                    }
                    else if (txtNaam.Text == "koen" && txtWachtwoord.Password == "" && cbGebruiker.SelectedValue == "Verkoper")
                    {
                        Startscherm startscherm = new Startscherm();
                        Hide();
                        startscherm.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Je dient een geldige gebruikersnaam en wachtwoord in te geven");
                        txtNaam.Clear();
                        txtWachtwoord.Clear();
                    }

                }

            }
            catch (FormatException fex)
            {
                MessageBox.Show("Invalid format", fex.GetType().ToString());
            }
            catch (OverflowException oex)
            {
                MessageBox.Show("Enter smaller values", oex.GetType().ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }
    }
}
   


