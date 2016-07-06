using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library1
{
    public class Sign : ISymbol
    {

        private string sign;

        private string[] sentenceSeparators = new string[] { "...", "?!", "?", "!", "." };
        private string[] wordSeparators = new string[] { " ", " - ", ";", "," };
        private string[] allSeparators = new string[] { ",",  " ", " - ", ";", "...", "?!", "?", "!", "." };

        public Sign(string inp)
        {
            this.sign = inp;
        }

        public Sign()
        {
            this.sign = String.Empty;
        }

        public bool IsEndSign(string s)
        {
            if (sentenceSeparators.Contains(s))
                return true;
            return false;

            //Regex delimiters = new Regex("[.?!]");
            //if (delimiters.Match(s).ToString().Equals(s))
            //{
            //    return true;
            //}
            //return false;
        }

        public bool IsWordDelimiter(string s)
        {
            if (wordSeparators.Contains(s))
                return true;
            return false;

            //Regex delimiters = new Regex("[,-;]");
            //if (delimiters.Match(s).ToString().Equals(s))
            //{
            //    return true;
            //}
            //return false;
        }

        public IEnumerable<string> SentenceSeparators()
        {
            return sentenceSeparators.AsEnumerable();
        }

        public IEnumerable<string> WordSeparators()
        {
            return wordSeparators.AsEnumerable();
        }

        public IEnumerable<string> All()
        {
            return allSeparators.AsEnumerable();
        }
    }
}
