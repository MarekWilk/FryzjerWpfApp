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
    /// Logika interakcji dla klasy DodajWizyteWindow.xaml
    /// </summary>
    public partial class DodajWizyteWindow : Window
    {

        private WizytyWindow ww;

        public DodajWizyteWindow(WizytyWindow ww)
        {
            InitializeComponent();
            this.ww = ww;

            klientCmb.ItemsSource = FryzjerDb.Instance.Klienci.ToList();
            klientCmb.SelectedIndex = 0;
            pracownikCmb.ItemsSource = FryzjerDb.Instance.Pracownicy.ToList();
            pracownikCmb.SelectedIndex = 0;
            uslugaCmb.ItemsSource = FryzjerDb.Instance.Uslugi.ToList();
            uslugaCmb.SelectedIndex = 0;
            godzinaCmb.ItemsSource = new string[] { "08:00", "09:00", "10:00", "11:00", "12:00", "13:00", "14:00", "15:00", "16:00", "17:00", "18:00", "19:00" };
            godzinaCmb.SelectedIndex = 0;
        }

        private void zapiszBtn_Click(object sender, RoutedEventArgs e)
        {
            if(dataCal.SelectedDate == null)
            {
                MessageBox.Show("Wybierz datę wizyty");
            }
            else if(klientCmb.SelectedItem == null)
            {
                MessageBox.Show("Wybierz klienta");
            }
            else if (pracownikCmb.SelectedItem == null)
            {
                MessageBox.Show("Wybierz pracownika");
            }
            else if (uslugaCmb.SelectedItem == null)
            {
                MessageBox.Show("Wybierz usługę");
            }
            else
            {
                int g = int.Parse(godzinaCmb.SelectedItem.ToString().Substring(0, 2));

                DateTime d = dataCal.SelectedDate.Value.AddHours(g);
                Klient k = (Klient)klientCmb.SelectedItem;
                Pracownik p = (Pracownik)pracownikCmb.SelectedItem;
                Usluga u = (Usluga)uslugaCmb.SelectedItem;


                if (FryzjerDb.Instance.Wizyty.Any(a=>a.Pracownik == p && a.Data == d))
                {
                    MessageBox.Show("Wybrany pracownik jest już zajęty w tym terminie");
                }
                else
                {
                    Wizyta w = new Wizyta(k.Id, p.Id, u.Id,d);

                    FryzjerDb.Instance.Add(w);
                    FryzjerDb.Instance.SaveChanges();

                    ww.Load();
                    this.Close();
                }
            }
        }
    }
}
