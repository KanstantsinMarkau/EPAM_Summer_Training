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

        //public ICollection<ISentence> Parse(string s)
        //{
        //    Sign sign = new Sign();
        //    ICollection<ISentence> col = new List<ISentence>();
        //    int i = 0;
        //    string tmp = String.Empty;
        //    foreach (var x in s)
        //        if (sign.IsEndSign(s[i].ToString()))
        //        {
        //            tmp += s[i];
        //            col.Add(new Sentence(tmp));
        //            if(i<s.Length-1) i++;
        //            while (s[i] == ' ') if (i < s.Length - 1) i++;
        //            tmp = String.Empty;
        //        }
        //        else
        //        {
        //            if (i < s.Length - 1)
        //            {
        //                i++;
        //                tmp += s[i];
        //            }
        //        } Console.WriteLine("11");
        //    foreach (Sentence sent in col)
        //    {
        //        sent.ParseSentence(sent.ToString());
        //    }
        //    return col;
        //}

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
    }
}
