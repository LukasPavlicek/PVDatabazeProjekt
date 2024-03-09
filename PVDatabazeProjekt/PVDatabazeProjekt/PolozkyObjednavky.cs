using PVDatabazeProjekt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PVDatabazeProjekt
{
    internal class PolozkyObjednavky
    {
        private int idProdukt;
        private int idObjednavky;
        private int mnozstvi;
        private float cena;

        public PolozkyObjednavky(int idProdukt, int idObjednavky, int mnozstvi, float cena)
        {
            this.IdProdukt = idProdukt;
            this.IdObjednavky = idObjednavky;
            this.Mnozstvi = mnozstvi;
            this.Cena = cena;
        }

        public int IdProdukt { get => idProdukt; set => idProdukt = value; }
        public int IdObjednavky { get => idObjednavky; set => idObjednavky = value; }
        public int Mnozstvi { get => mnozstvi; set => mnozstvi = value; }
        public float Cena { get => cena; set => cena = value; }
    }
}