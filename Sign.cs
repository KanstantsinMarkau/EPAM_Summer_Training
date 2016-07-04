using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Library1
{
    public class Sign : ISymbol
    {
        public string sign;

        public bool IsEndSign(string s)
        {
            Regex delimiters = new Regex("[.?!]");
            if (delimiters.Match(s).ToString().Equals(s))
            {
                return true;
            }
            return false;
        }


    }
}
