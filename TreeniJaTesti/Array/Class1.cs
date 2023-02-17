using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Array
{
    public class Nopat
    {
        public static void NopanHeitto()
        {
            int[] noppaArvot = new int[] { 1, 2, 3, 4, 5 };


            Random satunnainen = new Random();
            int numero = satunnainen.Next();

            for (int i = 0; i < noppaArvot.Length; i++)
            {
                Console.Write(satunnainen.Next(1, 7));
            }
        }
    }
}
