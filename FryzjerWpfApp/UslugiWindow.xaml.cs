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
    /// Logika interakcji dla klasy UslugiWindow.xaml
    /// </summary>
    public partial class UslugiWindow : Window
    {

        public UslugiWindow()
        {
            InitializeComponent();

            Load();
        }

        public void Load()
        {
            uslugiGrid.ItemsSource = null;
            uslugiGrid.ItemsSource = FryzjerDb.Instance.Uslugi.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DodajUslugeWindow dw = new DodajUslugeWindow(this);
            dw.ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //usuwanie
            if(uslugiGrid.SelectedItem != null && uslugiGrid.SelectedItem is Usluga)
            {
                Usluga u = (Usluga)uslugiGrid.SelectedItem;
                FryzjerDb.Instance.Remove(u);
                FryzjerDb.Instance.SaveChanges();

                Load();
            }
            else
            {
                MessageBox.Show("Wybierz usługe do usunięcia");
            }
        }

        private void uslugiGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            string name = e.Column.Header.ToString();

            if (name == "Id" || name == "Wizyty")
            {
                e.Cancel = true;
            }
        }
    }
}
