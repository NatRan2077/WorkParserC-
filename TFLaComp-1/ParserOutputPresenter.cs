using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TFLaComp_1.CardParser;

namespace TFLaComp_1
{
    public class ParserOutputPresenter
    {
        private DataGridView grid;

        public ParserOutputPresenter(DataGridView grid)
        {
            this.grid = grid;
        }

        public void ShowTokens(List<string> tokens)
        {
            grid.Columns.Clear();
            grid.Rows.Clear();

            grid.Columns.Add("Index", "№");
            grid.Columns.Add("Token", "Токен");

            for (int i = 0; i < tokens.Count; i++)
            {
                grid.Rows.Add(i + 1, tokens[i]);
            }
        }

        public void ShowErrors(List<SyntaxError> errors)
        {
            grid.Columns.Clear();
            grid.Rows.Clear();

            grid.Columns.Add("Position", "Позиция");
            grid.Columns.Add("Type", "Тип");
            grid.Columns.Add("Message", "Сообщение");

            if (errors.Count == 0)
            {
                grid.Rows.Add("-", "-", "Ошибок не найдено");
            }
            else
            {
                foreach (var error in errors)
                {
                    int rowIndex = grid.Rows.Add(error.Position, error.Type == ErrorType.Lexical ? "Лексическая" : "Синтаксическая", error.Message);

                    // Подсветка строк
                    if (error.Type == ErrorType.Lexical)
                    {
                        grid.Rows[rowIndex].DefaultCellStyle.BackColor = System.Drawing.Color.LightPink;
                    }
                    else
                    {
                        grid.Rows[rowIndex].DefaultCellStyle.BackColor = System.Drawing.Color.LightYellow;
                    }
                }
            }

            grid.AutoResizeColumns();
        }
    }
}