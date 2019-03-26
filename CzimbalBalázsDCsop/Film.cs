using System;
using System.Collections.Generic;
using System.Text;

namespace CzimbalBalázsDCsop
{
    class Film : Media
    {
        // erre van az enum
        // a stringek feleslegesek, mert nem használjuk külön sehol őket, csak a statikus init-nél
        // film műfajok
        private const string MUFAJAKCIO = "akció";
        private const string MUFAJCSALADI = "csaladi";
        private const string MUFAJHORROR = "horror";
        private const string MUFAJROMANTIKUS = "romantikus";
        private const string MUFAJDRAMA = "drama";
        private const string MUFAJELETRAJZI = "életrajzi";
        public static readonly List<string> MUFAJOK = new List<string>();
        static Film()
        {
            MUFAJOK.Add(MUFAJAKCIO);
            MUFAJOK.Add(MUFAJCSALADI);
            MUFAJOK.Add(MUFAJHORROR);
            MUFAJOK.Add(MUFAJROMANTIKUS);
            MUFAJOK.Add(MUFAJDRAMA);
            MUFAJOK.Add(MUFAJELETRAJZI);
        }

        // rate
        private int minoseg;
        private string mufaj;
        public Film(string _cim, int _hossz, int _megjel, int _minoseg, string _muf) : base(_cim, _hossz, _megjel)
        {
            this.minoseg = _minoseg;
            this.mufaj = _muf;
        }
        public override void Kiir(string mediatipusa = "")
        {
            base.Kiir("Filmek");
            Console.WriteLine("A film minősége: {0}\n" +
                                "A film műfaja: {1}",
                                minoseg, mufaj);
        }
    }
}
