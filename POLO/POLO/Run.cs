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
            Console.Write("Enter path for main POLO file (leave blank for terminal):\n>>> ");
            string path = Console.ReadLine();
            List<string> commands = new List<string>();
            if (path != "")
            {
                Console.Clear();
                if (!polo.validPath(path))
                    Environment.Exit(0);
                string file = File.ReadAllText(path);
                //make this bit run multiple times for each ;
                commands = polo.Command(file);
                Console.WriteLine($"FILE CONTENTS:\n{file}\n\n\n\n");
                Console.Write($"OUTPUT:\n");
            } else
            {
                string tmp = "";
                int index = 1;
                Console.WriteLine("Enter functons below (semi colon not required) and type 'END' to exexute: ");
                while (tmp != "END")
                {
                    Console.Write($"{index}. ");
                    tmp = Console.ReadLine();
                    if (tmp.ToUpper() != "END")
                    {
                        if (tmp[tmp.Length - 1] == ';')
                            tmp = tmp.Replace(";", string.Empty);
                        commands.Add(tmp);
                        tmp = tmp.ToUpper();
                    }
                    index++;
                }
                Console.WriteLine(Environment.NewLine);
            }
            for (int i = 0; i < commands.Count(); i++)
            {
                double? output = polo.ExecuteNumeric(commands[i]);
                if (output == null)
                    Environment.Exit(0);
                else
                {
                    Console.Write($"{output}\n");
                }
            }
            if (path == "")
                Notification.EndedProgram("Terminal");
            else
                Notification.EndedProgram("Program");
            Console.ReadKey();
        }
    }
}
