using System;
using System.Collections.Generic;
using System.Linq;
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
                Environment.Exit(0);
            string file = File.ReadAllText(path);
            int lastPos = 0;
            string gatherString = "";
            file = file.Trim();
            Console.WriteLine(file);
            //make this bit run multiple times for each ;
            for (int i = 0; i < file.Count(f => (f == ';')); i++)
            {
                for (int j = i; j < file.IndexOf(';', file.Length - lastPos); j++)
                {
                    gatherString += file[j];
                    lastPos++;
                }
                string command = polo.Command(file);
                int? output = polo.ExecuteNumeric(command);
                if (output == null)
                    Environment.Exit(0);
                else
                {
                    Console.WriteLine(output);
                }
            }
        }
    }
}
