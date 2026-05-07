using System;
using StringLibrary;

class Program
{
    static void Main()
    {
        SymbolString str = new SymbolString("hello world");

        Console.WriteLine("Line: " + str.GetValue());
        Console.WriteLine("Length: " + str.GetLength());

        str.ReplaceChar('o', 'a');

        Console.WriteLine("After replacement: " + str.GetValue());
    }
}