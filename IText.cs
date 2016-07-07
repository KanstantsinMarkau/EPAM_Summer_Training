using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library1
{
    public interface IText
    {
        Text Parse(string s);
        void PrintText();
        void PrintSentencesByIncrement();
        Text ReplaceWords(int numberString, int length, string substring);
        Text DeleteWordsStartingConsonance(int i);
    }
}
