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
    /// Logika interakcji dla klasy DodajUslugeWindow.xaml
    /// </summary>
    public partial class DodajUslugeWindow : Window
    {
        private UslugiWindow uw;

        public DodajUslugeWindow(UslugiWindow uw)
        {
            InitializeComponent();

            this.uw = uw;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrEmpty(nazwaTxt.Text))
            {
                MessageBox.Show("Wprowadź nazwę usługi");
            }
            else if(!decimal.TryParse(cenaTxt.Text,out decimal cena))
            {
                MessageBox.Show("Podano niepoprawną liczbę dla ceny");
            }
            else if (!int.TryParse(czasTxt.Text, out int czas))
            {
                MessageBox.Show("Podano niepoprawną liczbę dla czasu usługi");
            }
            else
            {
                Usluga u = new Usluga(nazwaTxt.Text, opisTxt.Text, cena, czas);
                FryzjerDb.Instance.Uslugi.Add(u);
                FryzjerDb.Instance.SaveChanges();

                uw.Load();
                this.Close();
            }

        }
    }
}
