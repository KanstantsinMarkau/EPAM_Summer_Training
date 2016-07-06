using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Library1
{
    public class Sentence : ISentence
    {
        private ICollection<ISymbol> components;
        public Sentence()
        {
            components = new List<ISymbol>();

        }

        public Sentence ParseSentence(string s)
        {
            Sign sign = new Sign();
            var allSeparators = sign.All();
            int bufferlength = 10000;
            Sentence sentence = new Sentence();
            StringBuilder buffer = new StringBuilder(bufferlength);
            buffer.Clear();
            while (s != null)
            {
                int firstSentenceSeparator = -1;
                string fstSentenceSeparator = allSeparators.FirstOrDefault(
                    x =>
                    {
                        firstSentenceSeparator = s.IndexOf(x);
                        return firstSentenceSeparator >= 0;
                    });
                if (fstSentenceSeparator != null)
                {
                    buffer.Append(s.Substring(0, firstSentenceSeparator));
                    Word word = new Word(buffer.ToString());
                    sentence.components.Add(word);
                    sign = new Sign(s.Substring(firstSentenceSeparator, fstSentenceSeparator.Length));
                    sentence.components.Add(sign);
                    buffer.Clear();
                    int numberSubstring = firstSentenceSeparator + fstSentenceSeparator.Length + 1;
                    if (numberSubstring < s.Length)
                        s = s.Substring(numberSubstring, s.Length - numberSubstring);
                    else s = null;
                }

            }
            return sentence;
        }
        public override string ToString()
        {
            string s = String.Empty;
            foreach (ISymbol sym in components)
            {
                s += sym.Value;
                if (sym.GetType() == typeof(Sign))
                    s += " ";
            }
            return s;
        }

        public int WordsCount()
        {
            int i = 0;
            foreach (ISymbol sym in components)
            {
                if (sym.GetType() == typeof(Word))
                    i++;
            } Console.WriteLine(i);
            return i;
        }

    }
}
