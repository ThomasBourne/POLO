using System;
using System.Collections.Generic;
using System.Text;

namespace POLO
{
    class Errors
    {
        public static void InvalidPath(string path) { Console.WriteLine($@"Interpreter Error: Path {path} was not found."); }
        public static void InvalidFileExtension(string path) { Console.WriteLine($@"Interpreter Error: Path {path} is not a valid POLO file."); }
        public static void NumericalError(string line) { Console.WriteLine($"Syntax Error: The numerical function {line} is not valid."); }
        public static void BracketError(string line) { Console.WriteLine($"Syntax Error: The brakets in {line} were either not closed or invalid."); }
    }
    class Notification
    {
        public static void EndedProgram(string wasTerminal) { Console.WriteLine($"\n{wasTerminal} Was executes sucessfully with Error code 0"); }
    }
}
