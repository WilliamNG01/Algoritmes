using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Algorithmes.RechercheTri
{
    public interface IConsole
    {
        string ReadLine();
        char ReadKey();
        void WriteLine(string message);
        void Write(string message);
    }

    public class ConsoleWrapper : IConsole
    {
        public string ReadLine() => Console.ReadLine();
        public char ReadKey() => ((char)Console.ReadKey().Key);
        public void WriteLine(string message) => Console.WriteLine(message);
        public void Write(string message) => Console.WriteLine(message);
    }
    public class RechercheDansFichierOrArray
    {
        private readonly IConsole _console;

        public RechercheDansFichierOrArray(IConsole console)
        {
            _console = console ?? throw new ArgumentNullException(nameof(console));
        }
        public bool GetLastXRows(int? n, string path)
        {
            int num = 0;
            if (n == null || n == 0)
            {
                _console.WriteLine("/\n\t\tinsert un nombre de line superieru à zero");
                var x = _console.ReadLine();
                if (int.TryParse(x, out num))
                {
                    _console.WriteLine("bien");
                }
                else
                {
                    _console.WriteLine("vous n'avez pasinserer un nombre entier");
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
                _console.WriteLine("le fichier est vide ou n'existe pas");
                return false;
            }
        }
        public bool Print(List<string> lastNrow)
        {

            if (lastNrow.Count > 0)
            {
                foreach (var item in lastNrow)
                {
                    _console.WriteLine("  -*-  " + item);
                }
            }
            _console.WriteLine("voulez vous continuer Oui 'O' ou Non 'N'");
            return _console.ReadKey().ToString() == ConsoleKey.O.ToString();
        }

        public bool GetElementDistinct(bool yes)
        {
            string[] arrA = ["a", "e", "e", "e", "b"];
            string[] arrB = ["b", "b", "c", "e", "e", "g"];

            _console.WriteLine(@"Soit les listes suivantes: A[" + string.Join(", ", arrA) + "] et \t B [" + string.Join(", ", arrB) + "]");
            _console.WriteLine("voulez vous trouver des caractère commun Oui 'O' ou Non 'N'");

            yes = _console.ReadKey().ToString() == ConsoleKey.O.ToString();
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

            _console.WriteLine(@"[" + text + "]");
            _console.WriteLine("voulez vous continuer Oui 'O' ou Non 'N'");
            return _console.ReadKey().ToString() == ConsoleKey.O.ToString();
        }

        public static int count = 0;
        public static readonly object locker = new();

        public void SayHello(string onThread)
        {
            //_console.WriteLine("SayHello {0}", onThread);
            while (count < 10)
            {
                lock (locker)
                {
                    _console.Write("Salut ");
                    count++;
                    Thread.Sleep(1000);
                }
                //await Task.Delay(1000);
            }
        }
        public void SayName(string onThread)
        {
            //_console.WriteLine("SayName {0}", onThread);
            while (count < 10)
            {
                lock (locker)
                {
                    _console.Write("William ");
                    count++;
                    Thread.Sleep(1000);
                }
                //await Task.Delay(1000);
            }
        }

        public string DecimalToHexadecimal()
        {
            int nombre = 0;

            // Convertir le nombre signé en entier non signé
            uint dividente = 0;  // "unchecked" pour éviter le débordement

            Dictionary<int, char> dictionairHexadecimal = new()
            {
                { 10,'A'},{ 11,'B'},{ 12,'C'},{ 13,'D'},{ 14,'E'},{ 15,'F'},
            };
            _console.WriteLine("/\n\t\tinsert un nombre superieru à zero");
            var x = _console.ReadLine();
            if (int.TryParse(x, out nombre) && nombre>0)
            {
                dividente = unchecked((uint)nombre);
                _console.WriteLine("bien");
            }
            else
            {
                if(nombre == 0) { return "0"; }
                else
                { 
                    // Gestion des nombres négatifs en utilisant le complément à deux
                    if (nombre < 0)
                    {
                        dividente = unchecked((uint)nombre);
                    }
                }
            }
            List<string> hexadecimal = new();
            bool continuer = true;

            while (continuer)
            {
                var quotient = dividente / 16;
                var reste = dividente % 16;

                if (reste >= 10) hexadecimal.Add(dictionairHexadecimal[(int)reste].ToString());
                    
                else hexadecimal.Add(reste.ToString());

                dividente = quotient;
                if (quotient ==0)
                    continuer = false;
            }
            hexadecimal.Reverse();
            _console.WriteLine("" + string.Join("", hexadecimal));

            return string.Join("", hexadecimal);

        }
    }
}
