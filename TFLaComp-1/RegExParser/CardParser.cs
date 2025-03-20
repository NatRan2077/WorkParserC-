using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TFLaComp_1.DTO;
using static System.Net.Mime.MediaTypeNames;

namespace TFLaComp_1.RegExParser
{
    public class CardParser
    {
        public List<CardDTO> Parse(string input) {
            List<CardDTO> cards = new List<CardDTO>();

            input = input.Trim();

            string patternWithout = "\\d{16}";
            string patternWithSpacess = "\\d{4}( \\d{4}){3}";
            //пробел перед началом добавить
            string pattern = @"(^| )((" + patternWithout + ")" + "|" + "(" + patternWithSpacess + "))($?)";

            Match match = Regex.Match(input, pattern);
            while (match.Success)
            {
                string value = match.Value.Replace(" ", "");
                CardDTO card = new CardDTO(value, match.Index, match.Index + match.Value.Length - 1);
                cards.Add(card);
                match = match.NextMatch();
            }

            return cards;
        }
    }
}
