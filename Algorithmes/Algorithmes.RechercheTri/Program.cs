// See https://aka.ms/new-console-template for more information
using Algorithmes.RechercheTri;
using System;

Console.WriteLine("Hello, World!");
// Création d'une instance de ConsoleWrapper (implémente IConsole)
IConsole console = new ConsoleWrapper();
RechercheDansFichierOrArray recherche = new(console);  // Injecter ConsoleWrapper

//algoritme de recherche des X dernière ligne d'un fichier
//Console.WriteLine("RechercheDansFichier.GetLastXRows");
//string path = @"C:\Users\WilliamNanfack\Downloads\textlorem.txt";

//Console.WriteLine("voulez vous commencer Oui 'o' ou Non 'n'");
//var reponse = Console.ReadKey().Key == ConsoleKey.O; // rechecher n fois
//while (reponse)
//{
//    //reponse = recherche.GetLastXRows(null, path);
//    //reponse = recherche.GetElementDistinct(false);
//}

//Task tsk1 = Task.Run(() => recherche.SayHello("task1 "));
//Task tsk2 = Task.Run(() => recherche.SayName("task2 "));

//Task.WaitAll(tsk2, tsk1);

//Thread thread1 = new Thread(()=>recherche.SayHello(onThread: "trd1"));
//Thread thread2 = new Thread(()=>recherche.SayName(onThread: "trd2"));

//thread2.Start();
//thread1.Start();

//thread1.Join();
//thread2.Join();

Console.WriteLine("voulez vous commencer l'algo decimal to hexadecimal Oui 'o' ou Non 'n'");
var reponse = Console.ReadKey().Key == ConsoleKey.O; // rechecher n fois
while (reponse)
{
    var result = recherche.DecimalToHexadecimal();
    Console.WriteLine("voulez vous continuer Oui 'O' ou Non 'N'");
    reponse =Console.ReadKey().Key == ConsoleKey.O;
}

Console.WriteLine("\n\t arréter le programme Oui 'O' ou Non 'N'");
//if(Console.ReadKey().Key != null) Environment.Exit(1);
//OR
Console.ReadLine();