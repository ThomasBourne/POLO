using System;
using System.Collections.Generic;
using System.IO;

namespace POLO
{
    class Run
    {
        static void Main(string[] args)
        {
            POLO polo = new POLO();
            //string path = @"C:\Users\Thomas\Desktop\POLO\POLO FILES\Main.p";
            Console.Write("Enter path for main POLO file:\n>>> ");
            string path = Console.ReadLine();
            Console.Clear();
            if (!polo.validPath(path))
            {
                Environment.Exit(0);
            }
            string file = File.ReadAllText(path);
            string command = polo.Command(file);
            int output = polo.ExecuteNumeric(command);
            Console.WriteLine(output);
            Console.ReadKey();
        }
    }
}
