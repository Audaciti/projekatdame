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
        static bool Proveri(int[,]matrica, int x, int y, int a)//marko
        {
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
                if (Proveri(tabla, pr, kolona, n))//marko
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
