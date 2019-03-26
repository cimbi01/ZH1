using System;
using System.Collections.Generic;
using System.Text;

namespace CzimbalBalázsDCsop
{
    class Media
    {
        public string Cim { get; private set; }
        private int hosszperc;
        public int MegjelenesEve { get; private set; }
        public Media(string _cim, int _hosszperc, int _megjeleve)
        {
            Cim = _cim;
            this.hosszperc = _hosszperc;
            this.MegjelenesEve = _megjeleve;
        }
        public virtual void Kiir(string mediatipusa = "")
        {
            Console.WriteLine("{0} Adatai:" +
                "\nCíme: {1}" +
                "\nHossza: {2}" +
                "\nMegjelenésének éve: {3}",
                mediatipusa, Cim, this.hosszperc, MegjelenesEve);
        }
    }
}
