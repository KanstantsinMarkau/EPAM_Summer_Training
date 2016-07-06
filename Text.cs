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
            var sentenceSeparators = sign.SentenceSeparators();
            int bufferlength = 10000;
            Text text = new Text();
            StringBuilder buffer = new StringBuilder(bufferlength);
            buffer.Clear();
            while (s != null)
            {
                int firstSentenceSeparator = -1;
                string fstSentenceSeparator = sentenceSeparators.FirstOrDefault(
                    x =>
                    {
                        firstSentenceSeparator = s.IndexOf(x);
                        return firstSentenceSeparator >= 0;
                    });
                if (fstSentenceSeparator != null)
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
    }
}
