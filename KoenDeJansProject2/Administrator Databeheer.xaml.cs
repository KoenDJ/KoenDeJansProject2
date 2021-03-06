﻿using System;
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
        // In dit window: klikken op vb leverancier brengt je naar window leverancier
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
            Databeheer_Leverancier DataLeverancier = new Databeheer_Leverancier();
            DataLeverancier.ShowDialog();
        }

        private void mnKlant_Click(object sender, RoutedEventArgs e)
        {
            Databeheer_Klant Dataklant = new Databeheer_Klant();
            Dataklant.ShowDialog();
        }

        private void mnProduct_Click(object sender, RoutedEventArgs e)
        {
            Databeheer_Product DataProduct = new Databeheer_Product();
            DataProduct.ShowDialog();
        }

        private void mnCategorie_Click(object sender, RoutedEventArgs e)
        {
            Databeheer_Categorie DataCategorie = new Databeheer_Categorie();
            DataCategorie.ShowDialog();
        }

        private void mnPersoneelslid_Click(object sender, RoutedEventArgs e)
        {
            Databeheer_Personeelsleden DataPersoneel = new Databeheer_Personeelsleden();
            DataPersoneel.ShowDialog();
        }

        private void mnBestelling_Click(object sender, RoutedEventArgs e)
        {
            Databeheer_Bestelling DataBestelling = new Databeheer_Bestelling();
            DataBestelling.ShowDialog();
        }
    }
}
