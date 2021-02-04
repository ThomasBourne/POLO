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
        public string Command(string file)
        {
            string command = "";
            char currentChar = '-';
            int i = 0;
            while (currentChar != ';')
            {
                currentChar = file[i];
                if (currentChar != ' ' && currentChar != ';')
                    command += currentChar;
                i++;
            }
            return command;
        }
        public int ExecuteNumeric(string command)
        {
            int? num1 = null;
            int? num2 = null;
            char symbol = 'a';
            for (int i = 0; i < command.Length; i++)
            {
                char focus = command[i];
                if (int.TryParse(Convert.ToString(command[i]), out int asdasd))
                {
                    if(num1 == null)
                        num1 = int.Parse(Convert.ToString(command[i]));
                    else
                        num2 = int.Parse(Convert.ToString(command[i]));
                }
                else
                {
                    symbol = focus;
                }
            }
            for (int j = 0; j < Store.mathsSymbols.Length; j++)
            {
                if (Store.mathsSymbols[j] == symbol)
                {
                    if (symbol == ' ' || symbol == '\n') { }
                    if (symbol == '+')
                        return num1.Value + num2.Value;
                    if (symbol == '-')
                        return num1.Value - num2.Value;
                    if (symbol == '*')
                        return num1.Value * num2.Value;
                    if (symbol == '/')
                        return num1.Value / num2.Value;
                    if (symbol == '%')
                        return num1.Value % num2.Value;
                    if (symbol == '^')
                    {
                        for (int x = 0; x < num2.Value - 1; x++)
                        {
                            num1 *= num1;
                        }
                        return num1.Value;
                    }
                }
            }
            return 0;
        }
    }
}
