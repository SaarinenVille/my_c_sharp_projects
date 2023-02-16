using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

int[] noppaArvot = new int[] { 1, 2, 1, 2, 1 };
Array.Sort(noppaArvot);

for (int i = 0; i < noppaArvot.Length; i++) 
{
    for (int j = i+1; j < noppaArvot.Length; j++)
    {
        if (noppaArvot[i] == noppaArvot[j])
        {
            Console.WriteLine("Taulukossa on pari");
        }
    }
}

// Laskutoimitus


