using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PVDatabazeProjekt
{
    public class MenuVnitrek
    {
        private string description;
        private Action action;

        public MenuVnitrek(string popis, Action akce)
        {
            this.description = popis;
            this.action = akce;
        }

        public override string ToString()
        {
            return description;
        }

        public void Execute()
        {
            action();
        }
    }
}
