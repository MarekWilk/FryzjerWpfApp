using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FryzjerWpfApp
{
    public class Pracownik
    {
        public int Id { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }

        public ICollection<Wizyta> Wizyty { get; set; }

        public Pracownik(string imie, string nazwisko)
        {
            Imie = imie;
            Nazwisko = nazwisko;
        }

        public override string ToString()
        {
            return $"{Imie} {Nazwisko}";
        }

    }
}
