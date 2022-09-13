using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FryzjerWpfApp
{
    public class Klient
    {
        public int Id { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Telefon { get; set; }

        public ICollection<Wizyta> Wizyty { get; set; }

        public Klient(string imie, string nazwisko, string telefon)
        {
            Imie = imie;
            Nazwisko = nazwisko;
            Telefon = telefon;
        }

        public override string ToString()
        {
            return $"{Imie} {Nazwisko}";
        }
    }
}
