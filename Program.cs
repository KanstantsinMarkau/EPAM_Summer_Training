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
            Word w = new Word();
            if (w.IsWord("QwQ")) Console.WriteLine("1");
            if (w.IsWord("qwe")) Console.WriteLine("2");
        }
    }
}
