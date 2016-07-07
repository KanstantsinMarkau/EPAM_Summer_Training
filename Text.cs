using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library1
{
    public class Text : IText
    {
        private ICollection<ISentence> sentences;

        public Text()
        {
            sentences = new List<ISentence>();
        }

        public Text Parse(string s)
        {
            Sign sign = new Sign();
            var sentenceSeparators = sign.SentenceSeparators().OrderByDescending(x => x.Length);
            int bufferlength = 10000;
            Text text = new Text();
            StringBuilder buffer = new StringBuilder(bufferlength);
            buffer.Clear();
            while (s != null)
            {
                int firstSentenceSeparator = -1;
                string fstSentenceSeparator = String.Empty;
                foreach (var x in sentenceSeparators)
                {
                    if (firstSentenceSeparator >= 0 && s.IndexOf(x) >= 0)
                    {
                        if (s.IndexOf(x) < firstSentenceSeparator)
                        {
                            fstSentenceSeparator = x;
                        }
                        firstSentenceSeparator = Math.Min(s.IndexOf(x), firstSentenceSeparator);

                    }
                    if (firstSentenceSeparator == -1 && s.IndexOf(x) >= 0)
                    {
                        firstSentenceSeparator = s.IndexOf(x);
                        fstSentenceSeparator = x;
                    }
                }
                
                if (fstSentenceSeparator != String.Empty)
                {
                    buffer.Append(s.Substring(0, firstSentenceSeparator + fstSentenceSeparator.Length));
                    Sentence sen = new Sentence();
                    text.sentences.Add(sen.ParseSentence(buffer.ToString()));
                    buffer.Clear();
                    int numberSubstring = firstSentenceSeparator + fstSentenceSeparator.Length + 1;
                    if (numberSubstring < s.Length)
                        s = s.Substring(numberSubstring, s.Length - numberSubstring);
                    else s = null;
                }

            }
            return text;
        }
        public void PrintText()
        {
            foreach (var x in sentences)
            {
                Console.Write(x.ToString());
            }
            Console.WriteLine();
        }

        public void PrintSentencesByIncrement()
        {
            ICollection<ISentence> t = this.sentences;
            IEnumerable<ISentence> i = t.OrderBy(sentence => sentence.WordsCount());
            foreach (var x in i)
            {
                Console.Write(x.ToString());
            }
            Console.WriteLine();


        }

        public void PrintWordsWithLength(int i)
        {
            foreach (ISentence s in sentences)
            {
                if (s.IsInterrogativeSentence())
                {
                    ICollection<ISymbol> col = s.FindByLength(i);
                    IEnumerable<ISymbol> withoutRepeat = col.Distinct();
                    foreach (var x in withoutRepeat)
                    {
                        Console.WriteLine(x.Value);
                    }
                }
            }
        }

        public Text DeleteWordsStartingConsonance(int i)
        {
            Text t = new Text();
            foreach (ISentence s in this.sentences)
            {
                t.sentences.Add(s.DeleteConsonance(i));
            }
            return t;
        }

        public Text ReplaceWords(int numberString, int length, string substring)
        {
            Text t = new Text();
            int i = 0;
            foreach (ISentence s in this.sentences)
            {
                if (i != numberString)
                {
                    t.sentences.Add(s);
                }
                else
                {
                    t.sentences.Add(s.ReplaceWord(length, substring));
                }
                i++;
            }
            return t;
        }
    }
}
