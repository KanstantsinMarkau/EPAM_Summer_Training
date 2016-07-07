using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library1
{
    public interface ISentence
    {
        Sentence ParseSentence(string s);
        string ToString();

        int WordsCount();
        bool IsInterrogativeSentence();
        ICollection<ISymbol> FindByLength(int len);
        Sentence DeleteConsonance(int length);
        Sentence ReplaceWord(int length, string substring);
    }
}
