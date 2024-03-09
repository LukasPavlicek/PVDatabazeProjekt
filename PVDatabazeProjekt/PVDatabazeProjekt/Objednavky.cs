using PVDatabazeProjekt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PVDatabazeProjekt
{
    internal class Objednavky : IBaseClass
    {
        private int id;
        private DateTime datumObjednani;
        private int idZakaznika;
        private int idPolozkyObjednavky;

        public Objednavky(int id, DateTime datumObjednani, int idZakaznika, int idPolozkyObjednavky)
        {
            ID = id;
            this.DatumObjednani = datumObjednani;
            this.IdZakaznika = idZakaznika;
            this.idPolozkyObjednavky = polozkyObjednavky;
        }

        public Objednavky() { }

        public int ID { get => id; set => id = value; }
        public DateTime DatumObjednani { get => datumObjednani; set => datumObjednani = value; }
        public int IdZakaznika { get => idZakaznika; set => idZakaznika = value; }
        public int IdPolozkyObjednavky { get => idPolozkyObjednavky; set => idPolozkyObjednavky = value; }
    }
}