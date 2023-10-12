using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;


namespace DZ_5_2_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> path = new List<string>();
            for (int i = 1; i < 13; i++)
            {
                path.Add($"{Environment.CurrentDirectory}@\\Image({i}).png\\");
                path.Add($"{Environment.CurrentDirectory}@\\Image({i}.{i}).png\\");
            }
            Console.WriteLine("Список до перемешивания:");
            for (int i = 0;i < path.Count;i++) 
            {
                Console.WriteLine(path[i]);
            }
            for (int i = 2; i < path.Count;i += 2) 
            {
                string temp = path[i];
                path[i] = path[i - 1];
                path[i - 1] = temp;
            }
            Console.WriteLine("После:");
            for (int i = 0; i < path.Count; i++)
            {
                Console.WriteLine(path[i]);
            }
            Console.ReadKey();
        }
    }
}
