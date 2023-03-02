// See https://aka.ms/new-console-template for more information
using Objects;
using System.Globalization;
using System.Net.Cache;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;

namespace Objektit;
class Program
{
    static void Main(string[] args)
    {
        Henkilo henkilo1 = new Henkilo("Ville ", "Saarinen", "Jabbankatu 4", 38 , 507859878 );
        Henkilo henkilo2 = new Henkilo("Pekka", "Pouta", "Aruinkokatu 3", 52, 0405863251);
        Henkilo henkilo3 = new Henkilo();

        Console.WriteLine(henkilo1.Alle40());
        Console.WriteLine(henkilo2.Alle40());


        /*
        Console.Write(henkilo1.enimi + henkilo1.snimi + ", " + henkilo1.lahios + ", " + henkilo1.ika + ", " + henkilo1.puh  );
       
        Console.WriteLine(henkilo1.Enimi + " " + henkilo1.Snimi + ", " + henkilo1.Ika);
        Console.WriteLine(henkilo2.Enimi + " " + henkilo2.Snimi + ", " + henkilo2.Ika);
        */
    }
}
