using System.DirectoryServices;
using System.Windows.Forms;
using TFLaComp_1.Functional;
using TFLaComp_1.ParserHelp;
using TFLaComp_1.RegExParser;

namespace TFLaComp_1
{
    public partial class ParserForm : System.Windows.Forms.Form
    {
        private IEdit _edit;
        private IFileLogic _logic;
        private IParserHelpProvider _helpProvider;
        private bool isTextChanged = false;

        public ParserForm()
        {
            InitializeComponent();
            this.HelpButton = true;

            _edit = new Edit(richTextBoxInput);
            _logic = new FileLogic();
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
            _helpProvider.SetHelp(this, "О программе", HelpNavigator.KeywordIndex);

            helpProvider1 = _helpProvider.HelpProvider;
            richTextBoxInput.TextChanged += richTextBoxInput_TextChanged;
        }

        private bool ConfirmSaveChanges()
        {
            if (!isTextChanged) return true;

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
            return result == DialogResult.No;
        }

        private void LoadFile()
        {
            try
            {
                string? text = _logic.Open();
                if (text == null)
                    throw new FileLoadException("Ошибка открытия файла!");

                richTextBoxInput.Text = text;
                isTextChanged = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HighlightResults(List<CardDTO> cards)
        {
            richTextBoxInput.SelectAll();
            richTextBoxInput.SelectionColor = richTextBoxInput.ForeColor;
            richTextBoxInput.SelectionFont = richTextBoxInput.Font;

            foreach (var card in cards)
            {
                richTextBoxInput.Select(card.IndexStart, card.IndexEnd - card.IndexStart + 1);
                richTextBoxInput.SelectionColor = card.NumberCard[0] switch
                {
                    '2' => Color.Green,
                    '4' => Color.Blue,
                    '5' => Color.OrangeRed,
                    _ => Color.Purple
                };
                richTextBoxInput.SelectionFont = new Font(richTextBoxInput.Font, FontStyle.Bold);
            }
        }

        private void ProcessInput()
        {
            var parser = new CardParser();
            var results = parser.Parse(richTextBoxInput.Text);
            HighlightResults(results);
        }

        private void start_Click(object sender, EventArgs e) => ProcessInput();
        private void StartToolStripMenuItem_Click(object sender, EventArgs e) => ProcessInput();
        private void undo_Click(object sender, EventArgs e) => _edit.Undo();
        private void redo_Click(object sender, EventArgs e) => _edit.Redo();
        private void cut_Click(object sender, EventArgs e) => _edit.Cut();
        private void paste_Click(object sender, EventArgs e) => _edit.Paste();
        private void copy_Click(object sender, EventArgs e) => _edit.Copy();
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
                Application.Exit();
            }
        }

        private void richTextBoxInput_TextChanged(object sender, EventArgs e) => isTextChanged = true;
    }
}
