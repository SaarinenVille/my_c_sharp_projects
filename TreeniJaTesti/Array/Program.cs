using Array;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Security.Cryptography.X509Certificates;

internal class Program
{
    
    private static void Main(string[] args)
    {
    aloitus:

        string kluku;
        int numero;

        Console.WriteLine();
        Console.WriteLine("Heitä noppaa. Ohjelma tulostaa viiden nopan silmäluvut.");
        Console.WriteLine("1. Heitä noppaa: ");
        Console.WriteLine("2. Tee jotain muuta: ");
        kluku = Console.ReadLine();

        numero = Int32.Parse(kluku);

        switch (numero) 
        {
            case 1: Nopat.NopanHeitto(); 
                break;
            case 2: Console.WriteLine("Väärä valinta. Heippa!");
                break;
            default: Console.WriteLine("Syötä oikea numero.");
                break;
                
        }
        goto aloitus;
    }
}