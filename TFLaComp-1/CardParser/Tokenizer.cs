using System.Collections.Generic;
using TFLaComp_1.CardParser.Interface;

namespace TFLaComp_1.CardParser
{
    public class Tokenizer : ITokenizer
    {
        public List<string> Tokens { get; } = new();
        public List<SyntaxError> Errors { get; } = new();

        IEnumerable<ISyntaxError> ITokenizer.Errors => Errors;

        public Tokenizer(string input)
        {
            Tokenize(input);
        }

        private void Tokenize(string input)
        {
            int i = 0;
            while (i < input.Length)
            {
                char c = input[i];

                if (char.IsWhiteSpace(c))
                {
                    i++;
                    continue;
                }

                if (c == '<' && i + 1 < input.Length && input[i + 1] == '<')
                {
                    Tokens.Add("<<");
                    i += 2;
                    continue;
                }
                else if (c == '>' && i + 1 < input.Length && input[i + 1] == '<')
                {
                    Errors.Add(new SyntaxError(i, "Недопустимая последовательность '><'", ErrorType.Lexical));
                    i += 2;
                    continue;
                }
                else if (c == '<')
                {
                    Errors.Add(new SyntaxError(i, "Одиночный символ '<' недопустим. Используйте '<<'", ErrorType.Lexical));
                    i++;
                    continue;
                }
                else if (c == ';')
                {
                    Tokens.Add(";");
                    i++;
                    continue;
                }
                else if (char.IsLetter(c))
                {
                    string id = "";
                    while (i < input.Length && (char.IsLetter(input[i]) || input[i] == '_' || char.IsDigit(input[i])))
                    {
                        id += input[i];
                        i++;
                    }
                    Tokens.Add(id);
                    continue;
                }
                else if (char.IsDigit(c))
                {
                    int start = i;
                    string number = "";
                    while (i < input.Length && char.IsDigit(input[i]))
                    {
                        number += input[i];
                        i++;
                    }
                    Errors.Add(new SyntaxError(start, $"Недопустимая лексема: {number}", ErrorType.Lexical));
                    continue;
                }
                else
                {
                    int start = i;
                    string invalid = "";
                    while (i < input.Length &&
                           !char.IsWhiteSpace(input[i]) &&
                           !char.IsLetter(input[i]) &&
                           !char.IsDigit(input[i]) &&
                           input[i] != '<' &&
                           input[i] != ';')
                    {
                        invalid += input[i];
                        i++;
                    }
                    Errors.Add(new SyntaxError(start, $"Недопустимая лексема: {invalid}", ErrorType.Lexical));
                    continue;
                }
            }
        }
    }
}
