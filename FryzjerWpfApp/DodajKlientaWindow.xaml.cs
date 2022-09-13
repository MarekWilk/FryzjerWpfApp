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
    /// Logika interakcji dla klasy DodajKlientaWindow.xaml
    /// </summary>
    public partial class DodajKlientaWindow : Window
    {
        KlienciWindow kw;

        public DodajKlientaWindow(KlienciWindow kw)
        {
            InitializeComponent();
            this.kw = kw;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrEmpty(imieTxt.Text) || string.IsNullOrEmpty(nazwiskoTxt.Text))
            {
                MessageBox.Show("Wprowadź imie i nazwisko");
            }
            else if(string.IsNullOrEmpty(telefonTxt.Text) || telefonTxt.Text.Length != 9 || !int.TryParse(telefonTxt.Text,out _))
            {
                MessageBox.Show("Niepoprawny numer telefonu. Telefon powinien składać się z 9 cyfr");
            }
            else
            {
                Klient k = new Klient(imieTxt.Text, nazwiskoTxt.Text, telefonTxt.Text);
                FryzjerDb.Instance.Klienci.Add(k);
                FryzjerDb.Instance.SaveChanges();


                kw.Load();
                this.Close();
            }
        }
    }
}
