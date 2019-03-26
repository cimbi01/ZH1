using System;
using System.Collections.Generic;
using System.Text;

namespace CzimbalBalázsDCsop
{
    class Zene : Media
    {
        private string stilus, kodolas, eloado;
        public Zene(string _cim, int _hossz, int _megjel, string _stil, string _eload, string _kod) : base(_cim, _hossz, _megjel)
        {
            this.stilus = _stil;
            this.eloado = _eload;
            this.kodolas = _kod;
        }
        public override void Kiir(string mediatipusa = "")
        {
            base.Kiir("Zene");
            Console.WriteLine("A zene stílusa: {0}\n" +
                            "A zene kódolása: {1}" +
                            "\nA zene előadója: {2}",
                            stilus, kodolas, eloado);
        }
    }
}
