using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Library1
{
    public class Word : ISymbol
    {
        public string Value
        {
            get;
            set;
        }

        public int Length
        {
            get;
            private set;
        }

        public Word()
        {
            this.Value = String.Empty;
            Length = 0;
        }

        public Word(string s)
        {
            this.Value = s;
            Length = s.Length;
        }

        public bool IsWord(string s)
        {
            if (s != String.Empty)
            {
                Regex reg = new Regex("(([A-Z]+[a-z]*)|([A-Z]*[a-z]+))+");
                if (reg.Match(s).ToString().Equals(s))
                {
                    return true;
                }
            }
            return false; 
        }

    }
}
