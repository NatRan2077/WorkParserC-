using System.Windows.Forms;
using TFLaComp_1.DTO;
using TFLaComp_1.Functional;
using TFLaComp_1.ParserHelp;
using TFLaComp_1.RegExParser;
using TFLaComp_1.ResultLog;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace TFLaComp_1
{
    public partial class ParserForm : System.Windows.Forms.Form
    {
        private IEdit _edit;

        private IFileLogic _logic;

        private IParserHelpProvider _helpProvider;

        private ISaveResult _saveResult;

        private bool isTextChanged = false;

        private bool isHighlighted = false;

        public ParserForm()
        {
            InitializeComponent();


            this.HelpButton = true;
            _saveResult = new SaveResult();
            _edit = new Edit(richTextBoxInput);
            _logic = new FileLogic();
            //_helpProvider = new ParserHelpProvider($"\\ParserHelp\\res\\parserHelpProvider.chm");
            //helpProvider1 = _helpProvider.HelpProvider;
            //helpProvider1.HelpNamespace = $"ParserHelp\\res\\parserHelpProvider.chm";


            _helpProvider = new ParserHelpProvider();
            _helpProvider.SetHelp(richTextBoxInput, HelpHtmDict.TopicDict["Правка"], HelpNavigator.Topic);
            _helpProvider.SetHelp(file, "Создать", HelpNavigator.KeywordIndex);
            _helpProvider.SetHelp(open, "Открыть", HelpNavigator.KeywordIndex);
            _helpProvider.SetHelp(save, "Сохранить", HelpNavigator.KeywordIndex);
            _helpProvider.SetHelp(start, "Пуск", HelpNavigator.Topic);

            _helpProvider.SetHelp(undo, "Отменить", HelpNavigator.KeywordIndex);
            _helpProvider.SetHelp(redo, "Повторить", HelpNavigator.KeywordIndex);
            _helpProvider.SetHelp(copy, "Копировать", HelpNavigator.KeywordIndex);
            _helpProvider.SetHelp(cut, "Вырезать", HelpNavigator.KeywordIndex);
            _helpProvider.SetHelp(paste, "Вставить", HelpNavigator.KeywordIndex);
            //_helpProvider.SetHelp(, "Удалить", HelpNavigator.KeywordIndex);
            //_helpProvider.SetHelp(, "Выделить все", HelpNavigator.KeywordIndex);

            _helpProvider.SetHelp(this, "О программе", HelpNavigator.KeywordIndex);

            // добавить какой-то Binding?
            helpProvider1 = _helpProvider.HelpProvider;

            richTextBoxInput.TextChanged += richTextBoxInput_TextChanged;
        }

        private void makeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // добавить Binding
            string text = richTextBoxInput.Text;
            _logic.Create(ref text);
            //richTextBoxInput.Text = "";
            richTextBoxInput.Text = text;
            //richTextBoxOutput.Text = "";
            ClearOutput();
        }

        private void file_Click(object sender, EventArgs e)
        {
            if (ConfirmSaveChanges())
            {
                // добавить Binding
                string text = richTextBoxInput.Text;
                _logic.Create(ref text);
                //richTextBoxInput.Text = "";
                richTextBoxInput.Text = text;
                //richTextBoxOutput.Text = "";
                ClearOutput();
            }
        }

        private void open_Click(object sender, EventArgs e)
        {
            if (ConfirmSaveChanges())
            {
                LoadFile();
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ConfirmSaveChanges())
            {
                LoadFile();
            }
        }

        private bool ConfirmSaveChanges()
        {
            if (!isTextChanged || richTextBoxInput.Text == "") return true; // Если изменений нет, просто продолжаем.

            DialogResult result = MessageBox.Show(
                "Сохранить изменения перед открытием нового файла?",
                "Подтверждение",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                _logic.Save(richTextBoxInput.Text);
                isTextChanged = false;
                return true;
            }
            else if (result == DialogResult.No)
            {
                return true;
            }

            return false; // Отмена операции
        }

        private void LoadFile()
        {
            try
            {
                string? text = _logic.Open();
                if (text == null)
                    throw new FileLoadException("Ошибка открытия файла!");

                richTextBoxInput.Text = text;
                isTextChanged = false; // Сбрасываем флаг изменений
                _edit = new Edit(richTextBoxInput);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void save_Click(object sender, EventArgs e)
        {
            _logic.Save(richTextBoxInput.Text);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _logic.Save(richTextBoxInput.Text);
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _logic.SaveAs(richTextBoxInput.Text);
        }

        private void HighlightResults(List<CardDTO> cards)
        {
            //isHighlighted = true;
            richTextBoxInput.SelectAll();
            richTextBoxInput.SelectionColor = richTextBoxInput.ForeColor;
            richTextBoxInput.SelectionFont = richTextBoxInput.Font;


            foreach (var card in cards)
            {
                richTextBoxInput.Select(card.IndexStart, card.IndexEnd - card.IndexStart + 1);

                richTextBoxInput.SelectionColor = Color.Green;
                richTextBoxInput.SelectionFont = new Font(richTextBoxInput.Font, FontStyle.Bold);
            }
            isHighlighted = true;
        }

        private void ProcessInput()
        {
            var parser = new CardParser();
            var results = parser.Parse(richTextBoxInput.Text);
            HighlightResults(results);
            _saveResult.WriteToLog(results);

            AnalyzerCard analyzerCard = new AnalyzerCard(results);
            PrintOutput(analyzerCard.Analyze());
        }

        private void PrintOutput(List<FullCardDTO> cards)
        {
            ClearOutput();

            if (cards.Count <= 0) return;

            dataGridViewOutput.Columns.Add("CardNumber", "Номер карты");
            dataGridViewOutput.Columns.Add("Bank", "Банк");
            dataGridViewOutput.Columns.Add("PaymentSystem", "Платежная система");
            dataGridViewOutput.Columns.Add("Indexes", "Индексы");

            if (cards.Count > 1)
            {
                dataGridViewOutput.Rows.Add(cards.Count - 1);
            }


            for (int i = 0; i < cards.Count; i++)
            {
                dataGridViewOutput.Rows[i].Cells[0].Value = cards[i].NumberCard;
                dataGridViewOutput.Rows[i].Cells[1].Value = cards[i].Bank;
                dataGridViewOutput.Rows[i].Cells[2].Value = cards[i].PaymentSystem;
                dataGridViewOutput.Rows[i].Cells[3].Value = $"{cards[i].IndexStart} - {cards[i].IndexEnd}";
            }
        }

        private void ClearOutput()
        {
            dataGridViewOutput.Rows.Clear();
            dataGridViewOutput.Columns.Clear();
        }

        private void start_Click(object sender, EventArgs e)
        {
            ProcessInput();
        }

        private void StartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProcessInput();
        }

        private void undo_Click(object sender, EventArgs e)
        {
            _edit.Undo();
        }

        private void redo_Click(object sender, EventArgs e)
        {
            _edit.Redo();
        }

        private void cut_Click(object sender, EventArgs e)
        {
            _edit.Cut();
        }

        private void paste_Click(object sender, EventArgs e)
        {
            _edit.Paste();
        }

        private void copy_Click(object sender, EventArgs e)
        {
            _edit.Copy();
        }

        private void callHelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, helpProvider1.HelpNamespace);
        }

        private void aboutCodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, helpProvider1.HelpNamespace, HelpNavigator.KeywordIndex, "О программе");
        }

        private void expToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // потом должен открываться файл курсовой
            Help.ShowHelp(this, helpProvider1.HelpNamespace,
                HelpNavigator.Topic, HelpHtmDict.TopicDict["Постановка задачи"]);
        }

        private void grammarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // потом должен открываться файл курсовой
            Help.ShowHelp(this, helpProvider1.HelpNamespace,
                HelpNavigator.Topic, HelpHtmDict.TopicDict["Грамматика"]);

        }

        private void classificationgrammarClassToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // потом должен открываться файл курсовой
            Help.ShowHelp(this, helpProvider1.HelpNamespace,
                HelpNavigator.Topic, HelpHtmDict.TopicDict["Классификация"]);

        }

        private void analysismethodToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // потом должен открываться файл курсовой
            Help.ShowHelp(this, helpProvider1.HelpNamespace,
                HelpNavigator.Topic, HelpHtmDict.TopicDict["Метод анализа"]);

        }

        private void diagnosticsNeutralizationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // потом должен открываться файл курсовой
            Help.ShowHelp(this, helpProvider1.HelpNamespace,
                HelpNavigator.Topic, HelpHtmDict.TopicDict["Диагностика"]);

        }

        private void explToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // потом должен открываться файл курсовой
            Help.ShowHelp(this, helpProvider1.HelpNamespace,
                HelpNavigator.Topic, HelpHtmDict.TopicDict["Тестовый пример"]);

        }

        private void bibliographyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // потом должен открываться файл курсовой
            Help.ShowHelp(this, helpProvider1.HelpNamespace,
                HelpNavigator.Topic, HelpHtmDict.TopicDict["Список литературы"]);

        }

        private void sourceCodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // потом должен открываться файл курсовой
            Help.ShowHelp(this, helpProvider1.HelpNamespace,
                HelpNavigator.Topic, HelpHtmDict.TopicDict["Исходный код"]);

        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _edit.Undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _edit.Redo();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _edit.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _edit.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _edit.Paste();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _edit.Delete();
        }

        private void pasteAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _edit.SelectAll();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Вы хотите сохранить перед выходом?",
                "Подтверждение",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                _logic.Save(richTextBoxInput.Text);
            }
            else if (result == DialogResult.No)
            {
                //_logic.Close();
                Application.Exit();
            }
        }

        private void richTextBoxInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Z)
            {
                _edit.Undo();
                e.SuppressKeyPress = true;
            }
            else if (e.Control && e.KeyCode == Keys.Y)
            {
                _edit.Redo();
                e.SuppressKeyPress = true;
            }
            else if (e.Control && e.KeyCode == Keys.A)
            {
                _edit.SelectAll();
                e.SuppressKeyPress = true;
            }
            else if (e.Control && e.KeyCode == Keys.X)
            {
                _edit.Cut();
                e.SuppressKeyPress = true;
            }
            else if (e.Control && e.KeyCode == Keys.C)
            {
                _edit.Copy();
                e.SuppressKeyPress = true;
            }
            else if (e.Control && e.KeyCode == Keys.V)
            {
                _edit.Paste();
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back)
            {
                _edit.SaveStateForUndo();
            }
            else if (e.Control && e.KeyCode == Keys.S)
            {
                _logic.Save(richTextBoxInput.Text);
                e.SuppressKeyPress = true;
            }
            else if (e.Control && e.KeyCode == Keys.O)
            {
                _logic.Open();
                e.SuppressKeyPress = true;
            }
            else
            {
                _edit.DetectTextChange();
            }
        }

        private void richTextBoxInput_TextChanged(object sender, EventArgs e)
        {
            isTextChanged = true;
            if (isHighlighted)
            {
                int start = richTextBoxInput.SelectionStart;

                // вызывает этот метод заново, из-за чего все ломается
                //richTextBoxInput.SelectAll();

                richTextBoxInput.SelectionColor = richTextBoxInput.ForeColor;
                richTextBoxInput.SelectionFont = richTextBoxInput.Font;
                richTextBoxInput.SelectionStart = start;
                //richTextBoxInput.SelectionColor = richTextBoxInput.ForeColor;
                isHighlighted = false;
            }
            _edit.SetContent();
            //isHighlighted = false;
        }

        private void richTextBoxInput_Enter(object sender, EventArgs e)
        {
            //richTextBoxInput.SelectAll();
            //richTextBoxInput.SelectionColor = richTextBoxInput.ForeColor;
            //richTextBoxInput.SelectionFont = richTextBoxInput.Font;

        }
    }
}
