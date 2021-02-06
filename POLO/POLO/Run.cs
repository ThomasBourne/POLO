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
            //string path C:\Users\Thomas\Desktop\POLO\POLO FILES\Main.p
            Console.Write("Enter path for main POLO file:\n>>> ");
            string path = Console.ReadLine();
            Console.Clear();
            if (!polo.validPath(path))
                Environment.Exit(0);
            string file = File.ReadAllText(path);
            //make this bit run multiple times for each ;
            List<string> commands = polo.Command(file);
            Console.WriteLine($"FILE CONTENTS:\n{file}\n\n\n\n");
            Console.Write($"OUTPUT:\n");
            for (int i = 0; i < commands.Count(); i++)
            {
                int? output = polo.ExecuteNumeric(commands[i]);
                if (output == null)
                    Environment.Exit(0);
                else
                {
                    Console.Write($"{output}\n");
                }
            }
        }
    }
}
