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
    /// Logika interakcji dla klasy DodajPracownikaWindow.xaml
    /// </summary>
    public partial class DodajPracownikaWindow : Window
    {
        private PracownicyWindow pw;

        public DodajPracownikaWindow(PracownicyWindow pw)
        {
            InitializeComponent();
            this.pw = pw;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(imieTxt.Text) || string.IsNullOrEmpty(nazwiskoTxt.Text))
            {
                MessageBox.Show("Wprowadź imie i nazwisko");
            }
            else
            {
                Pracownik p = new Pracownik(imieTxt.Text, nazwiskoTxt.Text);
                FryzjerDb.Instance.Add(p);
                FryzjerDb.Instance.SaveChanges();

                pw.Load();
                this.Close();
            }
        }
    }
}
