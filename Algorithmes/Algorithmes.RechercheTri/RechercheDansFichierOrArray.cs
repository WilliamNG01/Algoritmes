using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Algorithmes.RechercheTri
{
    public class RechercheDansFichierOrArray
    {
        public static bool GetLastXRows(int? n, string path)
        {
            int num = 0;
            if (n == null || n == 0)
            {
                Console.WriteLine("/\n\t\tinsert un nombre de line superieru à zero");
                var x = Console.ReadLine();
                if (int.TryParse(x, out num))
                {
                    Console.WriteLine("bien");
                }
                else
                {
                    Console.WriteLine("vous n'avez pasinserer un nombre entier");
                    Environment.Exit(0);
                }
            }
            else
            {
                num = n.Value;
            }
            var rows = File.ReadAllLines(path);
            if (rows.Length > 0)
                return Print(rows.Reverse().Take(num).Reverse().ToList());
            else
            {
                Console.WriteLine("le fichier est vide ou n'existe pas");
                return false;
            }
        }
        public static bool Print(List<string> lastNrow)
        {

            if (lastNrow.Count > 0)
            {
                foreach (var item in lastNrow)
                {
                    Console.WriteLine("  -*-  " + item);
                }
            }
            Console.WriteLine("voulez vous continuer Oui 'O' ou Non 'N'");
            return Console.ReadKey().Key == ConsoleKey.O;
        }

        public static bool GetElementDistinct(bool yes)
        {
            string[] arrA = ["a", "e", "e", "e", "b"];
            string[] arrB = ["b", "b", "c", "e", "e", "g"];

            Console.WriteLine(@"Soit les listes suivantes: A[" + string.Join(", ", arrA) + "] et \t B ["+ string.Join(", ", arrB) + "]");
            Console.WriteLine("voulez vous trouver des caractère commun Oui 'O' ou Non 'N'");
            
            yes = Console.ReadKey().Key == ConsoleKey.O;
            var distinctArrA = arrA.Distinct().ToList();
            var distinctArrB = arrB.Distinct().ToList();
            string text = "";
            if (yes)
            {
                //utilisation des HashSet pour la performance; dans les cas de tableaux volumineux et dont il y'a necessité d'y accéder continuellement
                HashSet<string> plusLongArray = new(distinctArrB);
                var result = distinctArrA.Intersect(plusLongArray);
                text = string.Join(", ", result);
            }
            else
            {
                var result = distinctArrB.Union(distinctArrA);
                text = string.Join(", ", result);
            }

            Console.WriteLine(@"[" + text +"]");
            Console.WriteLine("voulez vous continuer Oui 'O' ou Non 'N'");
            return Console.ReadKey().Key == ConsoleKey.O;
        }

        public static int count = 0;
        public static readonly object locker = new();

        public static void SayHello(string onThread)
        {
            //Console.WriteLine("SayHello {0}", onThread);
            while (count < 10)
            {
                lock (locker)
                {
                    Console.Write("Salut ");
                    count++;
                    Thread.Sleep(1000);
                }
                //await Task.Delay(1000);
            }
        }
        public static void SayName(string onThread)
        {
            //Console.WriteLine("SayName {0}", onThread);
            while (count < 10)
            {
                lock (locker)
                {
                    Console.Write("William ");
                    count++;
                    Thread.Sleep(1000);
                }
                //await Task.Delay(1000);
            }
        }
    }
}
