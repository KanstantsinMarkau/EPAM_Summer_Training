using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library1
{
    public class Text : IText
    {
        private ICollection<ISentence> sentences;

        public Text(string str)
        {
            sentences = this.Parse(str);

        }

        public ICollection<ISentence> Parse(string s)
        {
            Sign sign = new Sign();
            ICollection<ISentence> col = new List<ISentence>();
            int i = 0;
            string tmp = String.Empty;
            foreach (var x in s)
                if (sign.IsEndSign(s[i].ToString()))
                {
                    tmp += s[i];
                    col.Add(new Sentece(tmp));
                    i++;
                    while (s[i] == ' ') i++;
                    tmp = String.Empty;
                }
                else
                {
                    i++;
                    tmp += s[i];
                }
            return col;
        }


    }
}
