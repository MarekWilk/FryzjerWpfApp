using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FryzjerWpfApp
{
    public class Wizyta
    {
        public int Id { get; set; }
        public int KlientId { get; set; }
        public int PracownikId { get; set; }
        public int UslugaId { get; set; }
        public DateTime Data { get; set; }

        public Klient Klient { get; set; }
        public Pracownik Pracownik { get; set; }
        public Usluga Usluga { get; set; }

        public Wizyta(int klientId, int pracownikId, int uslugaId, DateTime data)
        {
            KlientId = klientId;
            PracownikId = pracownikId;
            UslugaId = uslugaId;
            Data = data;
        }
    }
}
