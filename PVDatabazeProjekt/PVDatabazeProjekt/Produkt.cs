using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PVDatabazeProjekt
{
    internal class Produkt : IBaseClass
    {
        private int id;
        private string nazev;
        private float cena;
        private DateTime datumVyroby;

        public Produkt(int id, string nazev, float cena, DateTime datumVyroby)
        {
            ID = id;
            this.nazev = nazev;
            this.cena = cena;
            this.datumVyroby = datumVyroby;
        }
        public int ID { get => id; set => id = value; }
        public string Nazev { get => nazev; set => nazev = value; }
        public float Cena { get => cena; set => cena = value; }
        public DateTime DatumVyroby { get => datumVyroby; set => datumVyroby = value; }
    }
}
