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

namespace FryzjerWpfApp
{
    /// <summary>
    /// Logika interakcji dla klasy KlienciWindow.xaml
    /// </summary>
    public partial class KlienciWindow : Window
    {
        public KlienciWindow()
        {
            InitializeComponent();

            Load();
        }

        public void Load()
        {
            klienciGrid.ItemsSource = null;
            klienciGrid.ItemsSource = FryzjerDb.Instance.Klienci.ToList();
        }

        private void dodajBtn_Click(object sender, RoutedEventArgs e)
        {
            DodajKlientaWindow dk = new DodajKlientaWindow(this);
            dk.ShowDialog();
        }

        private void usunBtn_Click(object sender, RoutedEventArgs e)
        {
            if (klienciGrid.SelectedItem != null && klienciGrid.SelectedItem is Klient)
            {
                Klient k = (Klient)klienciGrid.SelectedItem;
                FryzjerDb.Instance.Remove(k);
                FryzjerDb.Instance.SaveChanges();

                Load();
            }
            else
            {
                MessageBox.Show("Wybierz klienta do usunięcia");
            }
        }

        private void klienciGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            string name = e.Column.Header.ToString();

            if (name == "Id" || name == "Wizyty")
            {
                e.Cancel = true;
            }
        }
    }
}
