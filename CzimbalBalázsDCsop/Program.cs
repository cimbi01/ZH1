﻿using System;

namespace CzimbalBalázsDCsop
{
    class Program
    {
        private static Random rnd = new Random();
        // bekérés > kiírja a bekérő szöveget > bekéri az adatot, ha tudja konvertálni, akkor visszaadja az adatot, ha nem akkor ujra probálja
        private static T AdatBekeres<T>(string bekeroszoveg, bool mufaj = false)
        {
            T adatkonvertalt = default(T);
            Console.WriteLine(bekeroszoveg);
            string adat = Console.ReadLine();
            try
            {
                adatkonvertalt = (T)Convert.ChangeType(adat, typeof(T));
            }
            catch (FormatException e)
            {
                Console.WriteLine("Hibás adat: {0}", e.Message);
                adatkonvertalt = AdatBekeres<T>(bekeroszoveg);
            }
            // A bekérés tipusa bekero és a film mufajok-jában nincs benne a kapott érték
            if (mufaj && !Film.MUFAJOK.Contains(Convert.ToString(adatkonvertalt)))
            {
                Console.WriteLine("Hibás adat:\nNincs benne a megadott mufaji listában");
                adatkonvertalt = AdatBekeres<T>(bekeroszoveg, true);
            }
            return adatkonvertalt;
        }
        // mediak: 5 film, 5 zene
        private static Media[] mediak = new Media[10];
        static void Main(string[] args)
        {
            // init
            #region init
            int hossz = 0, minoseg = 0;
            string mufaj = "", stilus = "", eloado = "", kodolas = "";
            for (int i = 0; i < mediak.Length; i++)
            {
                string bekero = "Add meg a ";
                // első 5 film
                if (i < 5)
                {
                    bekero += "film";
                    hossz = rnd.Next(45, 121);
                    minoseg = AdatBekeres<int>(bekero + " minőségét!");
                    mufaj = AdatBekeres<string>(bekero + " műfaját!", true);
                }
                // utolsó 5 zene
                else
                {
                    bekero += "zene";
                    hossz = rnd.Next(3, 11);
                    stilus = AdatBekeres<string>(bekero + " stílusát!");
                    eloado = AdatBekeres<string>(bekero + " előadóját!");
                    kodolas = AdatBekeres<string>(bekero + " kódolását!");
                }
                string cim = AdatBekeres<string>(bekero + " címét!");
                int megjelev = AdatBekeres<int>(bekero + " megjelenési évét!");
                if(bekero.Contains("zene"))
                {
                    mediak[i] = new Zene(cim, hossz, megjelev, stilus, eloado, kodolas);
                }
                else
                {
                    mediak[i] = new Film(cim, hossz, megjelev, minoseg, mufaj);
                }
                mediak[i].Kiir("");
            }
            #endregion

            #region minkeresmegjelv
            Console.WriteLine("A legkorábbi szerzemény címe: {0}", MinKeres(mediak));
            #endregion

            Console.WriteLine("Program Vége");
            Console.ReadKey();
        }
        // nem kell a Media[] mediatar, mert a Media[] mediak statikus ezért hozzá tudna férni
        private static string MinKeres(Media[] mediatar)
        {
            int minindex = 0;
            for (int i = 0; i < mediatar.Length; i++)
            {
                // item felesleges, elég lenne az index szerint hivatkozni rá
                Media item = mediatar[i];
                if (item.MegjelenesEve < mediatar[minindex].MegjelenesEve)
                {
                    minindex = i;
                }
            }
            // cim felesleges, mert nem használjuk csak visszaadjuk
            string cim = mediatar[minindex].Cim;
            return cim;
        }
    }
}
