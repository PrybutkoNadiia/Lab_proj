using LabLibrary;
using System;

class Program
{
    static void Main()
    {
        Text myText = new Text();
        myText.AddLine("Hello world");
        myText.AddLine("OOP");
        myText.AddLine("Laboratory");

        myText.ToUpperCase();
        Console.WriteLine("Number of lines with the word 'world': " + myText.CountOccurrences("WORLD"));

        myText.RemoveByLength(3); // Видалить "ООП"

        foreach (var line in myText.GetLines())
            Console.WriteLine(line.Value);
    }
}