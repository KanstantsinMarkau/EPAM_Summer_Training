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
            t = t.Parse("It's cold. Yesterday was bright! Would it be rainy tomorrow? Internet said yes?! But what if it mistakes?");
            t.PrintText();
            Console.WriteLine("Sort by increase of words count:");
            Text newt = t;
            newt.PrintSentencesByIncrement();
            Console.WriteLine("Which words length do you preffer to write?");
            t.PrintWordsWithLength(int.Parse(Console.ReadLine()));
            Console.WriteLine("Which words length do you want to delete?");
            newt = t.DeleteWordsStartingConsonance(int.Parse(Console.ReadLine()));
            newt.PrintText();
            Console.WriteLine("Which sentence do you want to change?");
            int numChange = int.Parse(Console.ReadLine())-1;
            Console.WriteLine("Which length of words do you want to change?");
            int lenWord = int.Parse(Console.ReadLine());
            Console.WriteLine("Which substring do you want to add?");
            newt = t.ReplaceWords(numChange, lenWord, Console.ReadLine());
            newt.PrintText();
        }
    }
}
