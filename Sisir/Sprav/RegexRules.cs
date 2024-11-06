using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Sisir.Sprav
{
    internal class RegexRules
    {
        public Regex numberOnly = new Regex("[0-9]+");
        public Regex lettersOnly = new Regex("[А-яёЁA-z]+");
        public Regex adress = new Regex("[0-9 ,.\\- \\ /А-яёЁA-z]+");

        public Regex phone = new Regex("^[\\+]?[(]?[0-9]{3}[)]?[-\\s\\.]?[0-9]{3}[-\\s\\.]?[0-9]{4,6}$");
        public Regex email = new Regex("[^@ \\t\\r\\n]+@[^@ \\t\\r\\n]+\\.[^@ \\t\\r\\n]+");
        public Regex floatNumber = new Regex("[0-9]+[,.]{0,1}[0-9]{0,2}");
        public Regex tg = new Regex("@.+");
        public Regex passSerie = new Regex("[0-9]{4}");
        public Regex passNumber = new Regex("[0-9]{6}");

    }
}
