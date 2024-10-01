// See https://aka.ms/new-console-template for more information
using Algorithmes.RechercheTri;

Console.WriteLine("Hello, World!");

//algoritme de recherche des X dernière ligne d'un fichier
    //Console.WriteLine("RechercheDansFichier.GetLastXRows");
//string path = @"C:\Users\WilliamNanfack\Downloads\textlorem.txt";

//Console.WriteLine("voulez vous commencer Oui 'o' ou Non 'n'");
//var reponse = Console.ReadKey().Key == ConsoleKey.O; // rechecher n fois
//while (reponse)
//{
//    //reponse = RechercheDansFichierOrArray.GetLastXRows(null, path);
//    //reponse = RechercheDansFichierOrArray.GetElementDistinct(false);
//}

//RechercheDansFichierOrArray.SayHelloBoy();


Task tsk1 = Task.Run(() => RechercheDansFichierOrArray.SayHello("task1 "));
Task tsk2 = Task.Run(() => RechercheDansFichierOrArray.SayName("task2 "));

Task.WaitAll(tsk1, tsk2);

//Thread thread1 = new Thread(RechercheDansFichierOrArray.SayHello);
//Thread thread2 = new Thread(RechercheDansFichierOrArray.SayName);

//thread1.Start();
//thread2.Start();

//thread1.Join();
//thread2.Join();

Console.WriteLine("\n\t voulez vous continuer Oui 'O' ou Non 'N'");
//if(Console.ReadKey().Key != null) Environment.Exit(1);
//OR
Console.ReadLine();