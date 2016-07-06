using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library1
{
    class Program
    {
        static void Main(string[] args)
        {
            Text t = new Text();
            t = t.Parse("It's cold2. Yesterday was bright3! Would it be rainy tomorrow5? Internet said yes3?! But what if it mistakes5?");
            t.PrintText();
            Console.WriteLine("Sort by increase of words count:");
            t.PrintSentencesByIncrement();
            Console.WriteLine("Which words length do you preffer to write?");
            t.PrintWordsWithLength(int.Parse(Console.ReadLine()));


        }
    }
}
