using System.Text;
using TFLaComp_1.CardParser.Interface;

namespace TFLaComp_1.CardParser
{
    public class Parser : IParser
    {
        private readonly List<string> tokens;
        private int position;
        public List<SyntaxError> Errors { get; } = new();
        IEnumerable<ISyntaxError> IParser.Errors => Errors;

        public Parser(List<string> tokens)
        {
            this.tokens = tokens;
            this.position = 0;
        }

        private string Current => position < tokens.Count ? tokens[position] : null;

        private void Match(string expected)
        {
            if (Current == expected)
            {
                position++;
            }
            else
            {
                Errors.Add(new SyntaxError(position, $"Ожидалось '{expected}', найдено '{Current ?? "конец"}'"));
            }
        }

        public void Parse()
        {
            while (position < tokens.Count)
            {
                Output();
            }

            // Явная проверка последнего токена
            if (tokens.Count > 0 && tokens.Last() != ";")
            {
                Errors.Add(new SyntaxError(tokens.Count - 1, "Пропущена точка с запятой ';' в конце оператора"));
            }
        }

        private void Output()
        {
            if (Current == "cout")
            {
                Match("cout");
                Operator();
            }
            else
            {
                Errors.Add(new SyntaxError(position, $"Ожидалось 'cout', найдено '{Current ?? "конец"}'"));
                Synchronize(new[] { ";", "cout" });
            }

        }

        private void Operator()
        {
            if (Current == "<<")
            {
                Match("<<");
                Value();
            }
            else
            {
                Errors.Add(new SyntaxError(position, $"Ожидалось '<<', найдено '{Current ?? "конец"}'"));
            }
        }

        private void Value()
        {
            if (Current != null && IsValidIdentifier(Current))
            {
                position++;
                MoreOutput();
            }
            else
            {
                Errors.Add(new SyntaxError(position, $"Ожидался идентификатор, найдено '{Current ?? "конец"}'"));
            }
        }

        private void MoreOutput()
        {
            if (Current == "<<")
            {
                Operator();
            }
            else if (Current == ";")
            {
                Match(";");
            }
            else if (Current == null)
            {
                Errors.Add(new SyntaxError(position, "Пропущена точка с запятой ';' в конце оператора"));
            }
            else
            {
                Errors.Add(new SyntaxError(position, $"Ожидалось '<<' или ';', найдено '{Current}'"));
                Synchronize(new[] { ";" });
            }
        }

        private bool IsValidIdentifier(string token)
        {
            if (string.IsNullOrEmpty(token)) return false;
            if (!char.IsLetter(token[0]) && token[0] != '_') return false;

            foreach (char c in token)
            {
                if (!char.IsLetterOrDigit(c) && c != '_')
                    return false;
            }
            return true;
        }

        private void Synchronize(string[] followTokens)
        {
            while (Current != null && !followTokens.Contains(Current))
            {
                position++;
            }
        }
    }
}