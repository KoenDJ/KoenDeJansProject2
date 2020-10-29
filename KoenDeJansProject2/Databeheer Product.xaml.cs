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
    /// Interaction logic for Databeheer_Product.xaml
    /// </summary>
    public partial class Databeheer_Product : Window
    {
        public Databeheer_Product()
        {
            InitializeComponent();
            cbCatID.ItemsSource = DataManager.GetCategorieën();
            cbLevID.ItemsSource = DataManager.GetLeveranciers();
        }

        private void btnOverzicht_Click(object sender, RoutedEventArgs e)
        {

            grdProducten.ItemsSource = null;
            grdProducten.ItemsSource = DataManager.GetProducten();
        }

        private void btnVerwijderen_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Bent u zeker dat u dit product wilt verwijderen", "Opgelet", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                try
                {
                    Product p = DataManager.GetProductById(Convert.ToInt32(txtID.Text));
                    {
                        int ok = DataManager.DeleteProduct(p);
                        if (ok > 0)
                        {
                            grdProducten.ItemsSource = null;
                            grdProducten.ItemsSource = DataManager.GetProducten();
                            MessageBox.Show("Het verwijderen van het product is gelukt");
                            Opruimen();
                        }
                        else
                        {
                            MessageBox.Show("Het verwijderen van de klant is niet gelukt");
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
                Product p = new Product()
                {
                    ProductID = Convert.ToInt32(txtID.Text),
                    Eenheid = txtEenheid.Text,
                    LeverancierID = Convert.ToInt32(cbLevID.SelectedItem.ToString()),
                    Inkoopprijs = Convert.ToDecimal(txtPrijs.Text),
                    Marge = Convert.ToDouble(txtMarge.Text),
                    Naam = txtNaam.Text,
                    BTW = Convert.ToDouble(txtBTW.Text),
                    CategorieID = Convert.ToInt32(cbCatID.SelectedItem.ToString())
                };
                int ok = DataManager.InsertProduct(p);
                if (ok > 0)
                {
                    grdProducten.ItemsSource = null;
                    grdProducten.ItemsSource = DataManager.GetProducten();
                    MessageBox.Show("Het toevoegen van het product is gelukt");
                    Opruimen();
                }
                else
                {
                    MessageBox.Show("Het toevoegen van het product is niet gelukt");
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
                Product p = DataManager.GetProductById(Convert.ToInt32(txtID.Text));
                if (p != null)
                {
                    if (MessageBox.Show("Bent u zeker dat u het product op deze manier wilt wijzigen?", "vraag", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                    {
                        try
                        {

                            p.ProductID = Convert.ToInt32(txtID.Text);
                            p.Eenheid = txtEenheid.Text;
                            p.LeverancierID = Convert.ToInt32(cbLevID.SelectedItem);
                            p.Inkoopprijs = Convert.ToDecimal(txtPrijs.Text);
                            p.Naam = txtNaam.Text;
                            p.BTW = Convert.ToDouble(txtBTW.Text);
                            p.CategorieID = Convert.ToInt32(cbCatID.SelectedItem);
                            int ok = DataManager.ProductWijzigen(p);
                            if (ok > 0)
                            {
                                DataManager.GetProducten().Clear();
                                grdProducten.ItemsSource = null;
                                grdProducten.ItemsSource = DataManager.GetProducten();
                                MessageBox.Show("Het wijzigen van het product is gelukt");
                                Opruimen();
                            }
                            else
                            {
                                MessageBox.Show(" Het wijzigen van het product is niet gelukt");
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
                    MessageBox.Show("Er staat geen product met dit ID in de databank");
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
                Product p = DataManager.GetProductById(Convert.ToInt32(txtID.Text));
                if (p != null)
                {
                    txtID.Text = p.ProductID.ToString();
                    txtEenheid.Text = p.Eenheid;
                    cbLevID.SelectedIndex = Convert.ToInt32(p.LeverancierID);
                    txtPrijs.Text = p.Inkoopprijs.ToString();
                    txtNaam.Text = p.Naam;
                    txtBTW.Text = p.BTW.ToString();
                    cbCatID.SelectedIndex = Convert.ToInt32(p.CategorieID);
                }
                else
                {
                    MessageBox.Show("Er staat geen product met dit ID in de databank");
                    Opruimen();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cbCatID_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Opruimen()
        {
            cbCatID.SelectedIndex = 0;
            txtEenheid.Clear();
            cbLevID.SelectedIndex = 0;
            txtMarge.Clear();
            txtNaam.Clear();
            txtBTW.Clear();
            txtPrijs.Clear();
            txtID.Clear();
        }

        private void grdProducten_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                Product p = (Product)grdProducten.SelectedItem;
                txtID.Text = p.ProductID.ToString();
                txtEenheid.Text = p.Eenheid;
                cbLevID.SelectedIndex = Convert.ToInt32(p.LeverancierID);
                txtPrijs.Text = p.Inkoopprijs.ToString();
                txtNaam.Text = p.Naam;
                txtBTW.Text = p.BTW.ToString();
                cbCatID.SelectedIndex = Convert.ToInt32(p.CategorieID);
                DataManager.ProductWijzigen(p);
            }

            catch
            {
                MessageBox.Show("Gelieve geen lege rij te selecteren");
            }
        }
    }
}
