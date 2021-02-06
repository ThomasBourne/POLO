using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POLO
{
    class POLO
    {
        public bool validPath(string path)
        {
            POLOLogic PoloLogic = new POLOLogic();
            if (PoloLogic.IsPolo(path))
                return true;
            return false;
        }
        public List<string> Command(string file)
        {
            List<string> ls = new List<string>();
            string command = "";
            char currentChar = file[0];
            int i = 0;
            while (i < file.Length)
            {
                while (currentChar != ';')
                {
                    currentChar = file[i];
                    if (currentChar != ' ' && currentChar != '\n')
                        command += currentChar;
                    i++;
                }
                ls.Add(command);
                i++;
                command = "";
                if (i < file.Length)
                    currentChar = file[i];
            }
            return ls;
        }
        public int? ExecuteNumeric(string command)
        {
            int? num1 = null;
            int? num2 = null;
            char symbol = 'a';
            for (int i = 0; i < command.Length; i++)
            {
                char focus = command[i];
                if (int.TryParse(Convert.ToString(command[i]), out int asdasd))
                {
                    if (num1 == null)
                    {
                        num1 = int.Parse(Convert.ToString(command[i]));
                        for (int f = i; f < command.Length; f++)
                        {
                            if (int.TryParse(Convert.ToString(command[i + 1]), out int qwer))
                            {
                                num1 = int.Parse(Convert.ToString(command[i + 1] + Convert.ToString(command[i])));
                                i++;
                            }
                            else
                                f = command.Length;
                        }
                        char[] invert = Convert.ToString(num1.Value).ToCharArray();
                        Array.Reverse(invert);
                        num1 = Convert.ToInt32(new string(invert));
                    }
                    else
                    {
                        num2 = int.Parse(Convert.ToString(command[i]));
                        for (int f = i; f < command.Length - 1; f++)
                        {
                            if (int.TryParse(Convert.ToString(command[i + 1]), out int qwer))
                            {
                                num2 = int.Parse(Convert.ToString(command[i + 1] + Convert.ToString(command[i])));
                                i++;
                            }
                            else
                                f = command.Length;
                        }
                        char[] invert = Convert.ToString(num2.Value).ToCharArray();
                        Array.Reverse(invert);
                        num2 = Convert.ToInt32(new string(invert));
                    }
                }
                else
                {
                    for (int u = 0; u < Store.mathsSymbols.Length; u++)
                    {
                        if (Store.mathsSymbols[u] == focus)
                            symbol = focus;
                    }
                }
            }
            /*
            Console.WriteLine(command);
            Console.WriteLine(num1);
            Console.WriteLine(symbol);
            Console.WriteLine(num2);
            */
            for (int j = 0; j < Store.mathsSymbols.Length; j++)
            {
                if (Store.mathsSymbols[j] == symbol)
                {
                    if (symbol == ' ' || symbol == '\n') { }
                    else if (symbol == '+')
                        return num1.Value + num2.Value;
                    else if (symbol == '-')
                        return num1.Value - num2.Value;
                    else if (symbol == '*')
                        return num1.Value * num2.Value;
                    else if (symbol == '/')
                        return num1.Value / num2.Value;
                    else if (symbol == '%')
                        return num1.Value % num2.Value;
                    else if (symbol == '^')
                    {
                        for (int x = 0; x < num2.Value - 1; x++)
                        {
                            num1 *= num1;
                        }
                        return num1.Value;
                    }
                }
            }
            Errors.NumericalError(command);
            return null;
        }
        public string RemovePreviousCommand(string str)
        {
            for (int i = 0; i < str.IndexOf(';'); i++)
            {
                str.Remove(0);
            }
            Console.WriteLine(str);
            return str;
        } 
    }
}
