using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PVDatabazeProjekt
{
    internal class Zakaznik : IBaseClass
    {
        private int id;
        private string jmeno;
        private string adresa;
        private string telefonCislo;

        public Zakaznik(int id, string jmeno, string adresa, string telefonCislo)
        {
            ID = id;
            this.Jmeno = jmeno;
            this.Adresa = adresa;
            this.TelefonCislo = telefonCislo;
        }
        public Zakaznik() { }

        public int ID { get => id; set => id = value; }
        public string Jmeno { get => jmeno; set => jmeno = value; }
        public string Adresa { get => adresa; set => adresa = value; }
        public string TelefonCislo { get => telefonCislo; set => telefonCislo = value; }
    }
}
