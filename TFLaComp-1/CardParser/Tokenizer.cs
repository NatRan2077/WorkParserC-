using System.Collections.Generic;
using System.Text;
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

                // <<
                if (c == '<' && i + 1 < input.Length && input[i + 1] == '<')
                {
                    Tokens.Add("<<");
                    i += 2;
                    continue;
                }

                // одиночный <
                if (c == '<')
                {
                    Errors.Add(new SyntaxError(i, "Одиночный символ '<' недопустим. Используйте '<<'", ErrorType.Lexical));
                    i++;
                    continue;
                }

                // ;
                if (c == ';')
                {
                    Tokens.Add(";");
                    i++;
                    continue;
                }

                // потенциальный идентификатор (с одним ошибочным символом)
                if (IsLatinLetter(c) || c == '_')
                {
                    int start = i;
                    StringBuilder buffer = new();
                    bool errorLogged = false;

                    while (i < input.Length)
                    {
                        char ch = input[i];

                        if (IsLatinLetter(ch) || char.IsDigit(ch) || ch == '_')
                        {
                            buffer.Append(ch);
                            i++;
                        }
                        else if (!errorLogged && IsInvalidInIdentifier(ch))
                        {
                            Errors.Add(new SyntaxError(i, $"Недопустимый символ: '{ch}'", ErrorType.Lexical));
                            errorLogged = true;
                            i++; // Пропускаем один недопустимый символ
                        }
                        else
                        {
                            break;
                        }
                    }

                    if (buffer.Length > 0)
                        Tokens.Add(buffer.ToString());

                    continue;
                }

                // числа — ошибка
                if (char.IsDigit(c))
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

                // всё остальное — просто ошибка
                Errors.Add(new SyntaxError(i, $"Недопустимый символ: '{c}'", ErrorType.Lexical));
                i++;
            }
        }

        private bool IsLatinLetter(char c) =>
            (c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z');

        private bool IsInvalidInIdentifier(char c) =>
            "!@#$%^&*()+=[]{}\\|:,.?/`~\"'".Contains(c);
    }
}