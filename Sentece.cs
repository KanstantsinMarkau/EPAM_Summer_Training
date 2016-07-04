using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library1
{
    public class Sentece : ISentence
    {
        private ICollection<ISymbol> components;
        public Sentece(string s)
        {
            components = new List<ISymbol>();


        }

        public void deleteWhiteSpaces()
        {

        }

    }
}
