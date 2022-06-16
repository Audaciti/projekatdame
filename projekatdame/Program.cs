using System;
using System.IO;

namespace projekatdame
{
    class Program
    {
        static int brojac = 0; //brojac koji broji svaki slucaj
        static void Ispisi(int[,] tabla, StreamWriter ispis) //Metod koji ispisuje funkciju
        {
            int n = tabla.GetLength(0);
            ispis.WriteLine("Slucaj broj " + ++brojac);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                    ispis.Write(" " + tabla[i, j] + " ");
                ispis.WriteLine();
            }
            ispis.WriteLine();
        }
        static bool Bezbedan(int[,] tabla, int red, int kolona) /*Funkcija koja gleda da li se dama moze postaviti na odredjeno mesto.                                                     Dovoljno je gledati samo levu stranu, jer dame postavljamo od nulte do n-te kolone*/
        {
            int i, j;
            int n = tabla.GetLength(0);
            for (i = 0; i < kolona; i++) //gledamo red sa leve strane
            {
                if (tabla[red, i] == 1) //proveravamo da li se negde sa leve strane nalazi dama, ako se nalazi vracamo false
                {
                    return false;
                }
            }
            for (i = red, j = kolona; i >= 0 && j >= 0; i--, j--) //proveravamo gornje-levu dijagonalu
            {
                if (tabla[i, j] == 1)
                {
                    return false;
                }
            }
            for (i = red, j = kolona; j >= 0 && i < n; i++, j--) //proveravamo donje-levu dijagonalu
                if (tabla[i, j] == 1)
                {
                    return false;
                }
            return true; //ukoliko se ne nalazi dama ni na jednoj dijagonali niti u istom redu, vracamo true i dama se moze postaviti na zeljeno mesto [i,j]
        }
        static bool NadjiResenje(int[,] tabla, int kolona, StreamWriter ispis)//metoda koja nalazi resenja
        {
            int n = tabla.GetLength(0);//broj dama
            if (kolona >= n) //ukoliko smo popunili poslednju kolonu, dosli smo do kraja i ovo je tacno resenje
            {
                return true;
            }
            for (int i = 0; i < n; i++) //gledamo ovu kolonu i pokusacemo da postavimo damu na svim mestima jednu po jednu
            {
                if (Bezbedan(tabla, i, kolona)) //gledamo da li moze da se postavi
                {
                    tabla[i, kolona] = 1; //stavljamo damu
                    if (NadjiResenje(tabla, kolona + 1, ispis) == true) //ukoliko je resenje tacno, ispisacemo ga
                    {
                        Ispisi(tabla,ispis);
                    }
                    tabla[i, kolona] = 0; //ako ne uspemo da dodjemo do poslednje kolone, znaci da ne dolazimo do resenja; BACKTRACKING, brisemo poslednju postavljenu damu i idemo dalje
                }
            }
            return false; //ako se dama ne moze postaviti ni u jednom redu vracamo false
        }
        static void Main(string[] args)
        {
            string nazivfajla = "fajl" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".txt"; //naziv fajla sadrzi datum kada ce tekstualni fajl biti ispisan
            StreamWriter ispis = new StreamWriter(nazivfajla); //definisanje streamwritera koji pravi novi fajl u kome ce biti ispis
            Console.Write("Unesite broj dama: ");
            int n = int.Parse(Console.ReadLine()); //broj dama/sirina/duzina table
            int[,] tabla = new int[n, n];
            NadjiResenje(tabla, 0, ispis); //pozivamo metodu koja ima zadatak da pronadje sva resenja, uzimamo tablu i pocetnu kolonu
            if (brojac > 0)
            {
                Console.WriteLine("Broj resenja: " + brojac);
                Console.WriteLine("Kako biste videli sva resenja, pogledajte fajl " + Directory.GetCurrentDirectory() + "\\" + nazivfajla);
            }
            else
            {
                Console.WriteLine("Nema resenja.");
            }
            ispis.Close();
        }
    }
}
