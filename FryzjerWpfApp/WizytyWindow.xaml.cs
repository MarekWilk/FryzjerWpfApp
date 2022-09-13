using Microsoft.EntityFrameworkCore;
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
    /// Logika interakcji dla klasy WizytyWindow.xaml
    /// </summary>
    public partial class WizytyWindow : Window
    {
        /// <summary>
        /// Konstruktor bezparametrowy okna wizyta window
        /// </summary>
        public WizytyWindow()
        {
            InitializeComponent();

            Load();
        }

        /// <summary>
        /// Funkcja zaczytuje z bazy danych Wizyty i wstawia je do kontrolki DataGrid
        /// </summary>
        public void Load()
        {
            wizytyGrid.ItemsSource = null;
            wizytyGrid.ItemsSource = FryzjerDb.Instance.Wizyty.Include(i=>i.Klient).Include(i=>i.Pracownik).Include(i=>i.Usluga).OrderBy(o=>o.Data).ToList();
        }

        private void dodajBtn_Click(object sender, RoutedEventArgs e)
        {
            DodajWizyteWindow dw = new DodajWizyteWindow(this);
            dw.ShowDialog();
        }

        private void usunBtn_Click(object sender, RoutedEventArgs e)
        {
            if (wizytyGrid.SelectedItem != null && wizytyGrid.SelectedItem is Wizyta)
            {
                Wizyta w = (Wizyta)wizytyGrid.SelectedItem;
                FryzjerDb.Instance.Remove(w);
                FryzjerDb.Instance.SaveChanges();

                Load();
            }
            else
            {
                MessageBox.Show("Wybierz klienta do usunięcia");
            }
        }

        private void wizytyGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            string name = e.Column.Header.ToString();

            if (name == "Id" || name == "KlientId" || name == "PracownikId" || name == "UslugaId")
            {
                e.Cancel = true;
            }

            if (e.PropertyType == typeof(System.DateTime))
            {
                (e.Column as DataGridTextColumn).Binding.StringFormat = "yyyy-MM-dd HH:mm:ss";
            }
        }
    }
}
