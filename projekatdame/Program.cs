using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekatdame
{
    class Program
    {
        static void Ispisi(int[,] matrica, int a)//mika
        {

        }
        static bool Bezbedan(int[,] tabla, int red, int kolona, int n)//marko!(to sam ja)
        {
            int i, j;
            for (i = 0; i < kolona; i++)
                if (tabla[red, i] == 1)
                    return false;
            for (i = red, j = kolona; i >= 0 && j >= 0; i--, j--)
                if (tabla[i, j] == 1)
                    return false;
            for (i = red, j = kolona; j >= 0 && i < n; i++, j--)
                if (tabla[i, j] == 1)
                    return false;
            return true;
        }
        static bool NadjiResenje(int[,] tabla, int kolona, int n)
        {
            if (kolona >= n)
            {
                return true;
            }
            for (int pr = 0; pr < n; pr++)
            {
                if (Bezbedan(tabla, pr, kolona, n))//marko(to sam ja!)
                {
                    tabla[pr, kolona] = 1;
                    if (NadjiResenje(tabla, kolona + 1, n) == true)
                    {
                        Ispisi(tabla, n);//mika
                    }
                    tabla[pr, kolona] = 0;
                }
            }
            return false;
        }
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] tabla = new int[n, n];
            NadjiResenje(tabla, 0, n);

        }
    }
}

