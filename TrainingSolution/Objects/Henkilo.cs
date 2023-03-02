using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objects
{
    class Henkilo
    {
        public string enimi;
        public string snimi;
        public int ika;
        public string lahios;
        public int puh;

        public Henkilo()
        {

        }

        public Henkilo(string aEnimi, string aSnimi, string aLahios, int aIka, int aPuh) 
        {
            enimi = aEnimi; 
            snimi = aSnimi; 
            ika = aIka;
            puh = aPuh;
            lahios = aLahios;
        }

        public bool Alle40()
        {
            if (ika < 40)
            {
                return true;
            }
            return false;
        }
    }
}
