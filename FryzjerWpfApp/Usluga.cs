using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FryzjerWpfApp
{
    public class Usluga
    {
        public int Id { get; set; }
        public string Nazwa { get; set; }
        public string Opis { get; set; }
        public decimal Cena { get; set; }
        public int Czas { get; set; }

        public ICollection<Wizyta> Wizyty { get; set; }

        public Usluga(string nazwa, string opis, decimal cena, int czas)
        {
            Nazwa = nazwa;
            Opis = opis;
            Cena = cena;
            Czas = czas;
        }

        public override string ToString()
        {
            return $"{Nazwa} - {Cena}";
        }
    }
}
