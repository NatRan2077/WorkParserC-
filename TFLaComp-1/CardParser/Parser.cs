using System.Collections.Generic;
using System.Linq;
using TFLaComp_1.CardParser.Interface;

namespace TFLaComp_1.CardParser
{
    public class Parser
    {
        private readonly List<string> _tokens;
        private int _position;
        private bool _semicolonFound;

        public List<SyntaxError> Errors { get; } = new();

        private string Current => _position < _tokens.Count ? _tokens[_position] : null;

        public Parser(List<string> tokens)
        {
            _tokens = tokens;
            _position = 0;
            _semicolonFound = false;
        }

        public void Parse()
        {
            while (_position < _tokens.Count)
            {
                ParseOutput();

                // Если после выражения остались лишние токены — пытаемся перейти к следующему cout
                if (_position < _tokens.Count && Current != "cout")
                {
                    Errors.Add(new SyntaxError(_position, $"Неожиданный токен вне выражения: '{Current}'"));
                    Synchronize(new[] { "cout" });
                }
            }

            if (!_semicolonFound && _tokens.Count > 0 && _tokens.Last() != ";")
            {
                Errors.Add(new SyntaxError(_tokens.Count - 1, "Пропущена точка с запятой ';' в конце оператора"));
            }
        }

        private void ParseOutput()
        {
            _semicolonFound = false;

            if (Current == "cout")
            {
                Match("cout");
                ParseOperator();
            }
            else
            {
                Errors.Add(new SyntaxError(_position, $"Ожидалось 'cout', найдено '{Current ?? "конец"}'"));
                Synchronize(new[] { "cout", ";" }); // Пропускаем до следующего cout или конца выражения
            }
        }

        private void ParseOperator()
        {
            if (Current == "<<")
            {
                Match("<<");
                ParseValue();
            }
            else
            {
                Errors.Add(new SyntaxError(_position, $"Ожидалось '<<', найдено '{Current ?? "конец"}'"));
                Synchronize(new[] { "<<", ";", "cout" }); // Попробуем восстановиться до следующего оператора или конца
            }

            if (Current == "<<")
            {
                _position++;
                ParseValue();
            }
            else if (Current == "cout")
            {
                ParseOutput();
            }
            else if (Current == ";")
            {
                _semicolonFound = true;
                Match(";"); // <<< обязательно съесть ';'
            }

            return;
        }

        private void ParseValue()
        {
            if (IsValidIdentifier(Current))
            {
                _position++;
                ParseMoreOutput();
            }
            else
            {
                Errors.Add(new SyntaxError(_position, $"Ожидался идентификатор, найдено '{Current ?? "конец"}'"));
                Synchronize(new[] { "<<", ";", "cout" });

                if (Current == ";")
                {
                    _semicolonFound = true;
                    Match(";"); // <<< Съедаем ;, чтобы не споткнуться дальше!
                }

                return;
            }
        }

        private void ParseMoreOutput()
        {
            if (Current == "<<")
            {
                ParseOperator();
            }
            else if (Current == ";")
            {
                _semicolonFound = true;
                Match(";");
            }
            else
            {
                Errors.Add(new SyntaxError(_position, $"Ожидалось '<<' или ';', найдено '{Current ?? "конец"}'"));
                Synchronize(new[] { ";", "cout" });
            }
        }

        private void Match(string expected)
        {
            if (Current == expected)
            {
                _position++;
            }
            else
            {
                Errors.Add(new SyntaxError(_position, $"Ожидалось '{expected}', найдено '{Current ?? "конец"}'"));
            }
        }

        private bool IsValidIdentifier(string token)
        {
            return !string.IsNullOrEmpty(token)
                   && (char.IsLetter(token[0]) || token[0] == '_')
                   && token.All(c => char.IsLetterOrDigit(c) || c == '_');
        }

        private void Synchronize(string[] followTokens)
        {
            while (Current != null && !followTokens.Contains(Current))
            {
                _position++;
            }
        }
    }
}
