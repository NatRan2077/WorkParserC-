using System.Windows.Forms;
using TFLaComp_1.Functional;
using TFLaComp_1.ParserHelp;
using TFLaComp_1.RegExParser;
using TFLaComp_1.ResultLog;

namespace TFLaComp_1
{
    public partial class ParserForm : System.Windows.Forms.Form
    {
        private IEdit _edit;

        private IFileLogic _logic;

        private IParserHelpProvider _helpProvider;

        private ISaveResult _saveResult;


        private bool isTextChanged = false;

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
            richTextBoxOutput.Text = "";
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
                richTextBoxOutput.Text = "";
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
            if (!isTextChanged) return true; // Если изменений нет, просто продолжаем.

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

        private void saveAssToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _logic.SaveAs(richTextBoxInput.Text);
        }

        private void HighlightResults(List<CardDTO> cards)
        {
            richTextBoxInput.SelectAll();
            richTextBoxInput.SelectionColor = richTextBoxInput.ForeColor;
            richTextBoxInput.SelectionFont = richTextBoxInput.Font;


            foreach (var card in cards)
            {
                richTextBoxInput.Select(card.IndexStart, card.IndexEnd - card.IndexStart + 1);

                richTextBoxInput.SelectionColor = Color.Green;
                richTextBoxInput.SelectionFont = new Font(richTextBoxInput.Font, FontStyle.Bold);

            }
        }

        private void ProcessInput()
        {
            var parser = new CardParser();
            var results = parser.Parse(richTextBoxInput.Text);
            HighlightResults(results);
            _saveResult.WriteToLog(results);
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
        }

        private void richTextBoxInput_TextChanged(object sender, EventArgs e)
        {
            isTextChanged = true;

            _edit.SetContent();
        }

    }
}
