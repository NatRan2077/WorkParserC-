using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace TFLaComp_1.RegExParser
{
    public class CardParser
    {
        public List<CardDTO> Parse(string input) {
            List<CardDTO> cards = new List<CardDTO>();

            string patternWithout = "(2|4|5)\\d{15}";
            string patternWithSapcess = "(2|4|5)\\d{3}( \\d{4}){3}";
            //пробел перед началом добавить
            string pattern = @"(" + patternWithout + ")" + "|" + "(" + patternWithSapcess + ")";

            Match match = Regex.Match(input, pattern);
            while (match.Success)
            {
                CardDTO card = new CardDTO(match.Value, match.Index, match.Index + match.Value.Length - 1);
                cards.Add(card);
                match = match.NextMatch();
            }

            return cards;
        }
    }
}
