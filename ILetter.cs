using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library1
{
    public interface ILetter
    {
        bool IsVowel(string s);
        bool IsConsonant(string s);
    }
}
