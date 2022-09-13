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
    /// Logika interakcji dla klasy PracownicyWindow.xaml
    /// </summary>
    public partial class PracownicyWindow : Window
    {
        public PracownicyWindow()
        {
            InitializeComponent();

            Load();
        }

        public void Load()
        {
            pracownicyGrid.ItemsSource = null;
            pracownicyGrid.ItemsSource = FryzjerDb.Instance.Pracownicy.ToList();
        }

        private void dodajBtn_Click(object sender, RoutedEventArgs e)
        {
            DodajPracownikaWindow dp = new DodajPracownikaWindow(this);
            dp.ShowDialog();
        }

        private void usunBtn_Click(object sender, RoutedEventArgs e)
        {
            if (pracownicyGrid.SelectedItem != null && pracownicyGrid.SelectedItem is Pracownik)
            {
                Pracownik p = (Pracownik)pracownicyGrid.SelectedItem;
                FryzjerDb.Instance.Remove(p);
                FryzjerDb.Instance.SaveChanges();

                Load();
            }
            else
            {
                MessageBox.Show("Wybierz pracownika do usunięcia");
            }
        }

        private void pracownicyGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            string name = e.Column.Header.ToString();

            if (name == "Id" || name == "Wizyty")
            {
                e.Cancel = true;
            }
        }
    }
}
