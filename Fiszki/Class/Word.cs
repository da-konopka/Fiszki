using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiszki
{
    class Word
    {
        public int id;
        public string wordPL;
        public string wordANG;
        public string category;

        public Word(int id, string wordPL, string wordANG, string category)
        {
            this.id = id;
            this.wordPL = wordPL;
            this.wordANG = wordANG;
            this.category = category;
        }
    }
}
