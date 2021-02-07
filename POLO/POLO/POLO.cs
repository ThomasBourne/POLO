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
                    if (currentChar != ' ' && currentChar != '\n'&& currentChar != ';' )
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
        public double? ExecuteNumeric(string command)
        {
            System.Data.DataTable table = new System.Data.DataTable();
            try
            {
                return Convert.ToDouble(table.Compute(command, String.Empty));

            }
            catch (System.Data.EvaluateException)
            {
                Console.WriteLine($"At the moment ^ does not work");
                Errors.NumericalError(command);
                return null;
            }

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
