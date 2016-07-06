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
            //Text t = new Text("QwQ. me . hd.");
            Text t = new Text();
            t = t.Parse("but? it's so speciefic. no, aaaaa! aaa?!");
            t.PrintText();
            t.PrintSentencesByIncrement();
        }
    }
}
