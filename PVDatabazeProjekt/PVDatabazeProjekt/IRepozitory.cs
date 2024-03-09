using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PVDatabazeProjekt
{
    public interface IRepozitory<T> where T : IBaseClass
    {
        T PodleID(int id);
        IEnumerable<T> Vsechny();
        void Vlozeni(T element);
        void Smazat(T element);
    }
}
