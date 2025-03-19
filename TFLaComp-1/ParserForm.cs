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
            //_helpProvider = new ParserHelpProvider($"\\ParserHelp\\res\\parserHelpProvider.chm");
            //helpProvider1 = _helpProvider.HelpProvider;
            //helpProvider1.HelpNamespace = $"ParserHelp\\res\\parserHelpProvider.chm";


            _helpProvider = new ParserHelpProvider();
            _helpProvider.SetHelp(richTextBoxInput, HelpHtmDict.TopicDict["������"], HelpNavigator.Topic);
            _helpProvider.SetHelp(file, "�������", HelpNavigator.KeywordIndex);
            _helpProvider.SetHelp(open, "�������", HelpNavigator.KeywordIndex);
            _helpProvider.SetHelp(save, "���������", HelpNavigator.KeywordIndex);
            _helpProvider.SetHelp(start, "����", HelpNavigator.Topic);

            _helpProvider.SetHelp(undo, "��������", HelpNavigator.KeywordIndex);
            _helpProvider.SetHelp(redo, "���������", HelpNavigator.KeywordIndex);
            _helpProvider.SetHelp(copy, "����������", HelpNavigator.KeywordIndex);
            _helpProvider.SetHelp(cut, "��������", HelpNavigator.KeywordIndex);
            _helpProvider.SetHelp(paste, "��������", HelpNavigator.KeywordIndex);
            //_helpProvider.SetHelp(, "�������", HelpNavigator.KeywordIndex);
            //_helpProvider.SetHelp(, "�������� ���", HelpNavigator.KeywordIndex);

            _helpProvider.SetHelp(this, "� ���������", HelpNavigator.KeywordIndex);

            // �������� �����-�� Binding?
            helpProvider1 = _helpProvider.HelpProvider;

            richTextBoxInput.TextChanged += richTextBoxInput_TextChanged;
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void makeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // �������� Binding
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
                // �������� Binding
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
            if (!isTextChanged) return true; // ���� ��������� ���, ������ ����������.

            DialogResult result = MessageBox.Show(
                "��������� ��������� ����� ��������� ������ �����?",
                "�������������",
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

            return false; // ������ ��������
        }

        private void LoadFile()
        {
            try
            {
                string? text = _logic.Open();
                if (text == null)
                    throw new FileLoadException("������ �������� �����!");

                richTextBoxInput.Text = text;
                isTextChanged = false; // ���������� ���� ���������
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            // ����� ����������� ���������.
            richTextBoxInput.SelectAll();
            richTextBoxInput.SelectionColor = richTextBoxInput.ForeColor; // ��������������� ���� ������.
            richTextBoxInput.SelectionFont = richTextBoxInput.Font; // ��������������� �����.


            foreach (var card in cards)
            {
                richTextBoxInput.Select(card.IndexStart, card.IndexEnd - card.IndexStart + 1);
                switch (card.NumberCard[0])
                {
                    case '2':  // ���
                        {
                            richTextBoxInput.SelectionColor = Color.Green;
                        }
                        break;
                    case '4':  // Visa
                        {
                            richTextBoxInput.SelectionColor = Color.Blue;
                        }
                        break;
                    case '5':  // MasterCard
                        {
                            richTextBoxInput.SelectionColor = Color.OrangeRed;
                        }
                        break;
                    default:
                        {
                            richTextBoxInput.SelectionColor = Color.Purple;
                        }
                        break;
                }
                richTextBoxInput.SelectionFont = new Font(richTextBoxInput.Font, FontStyle.Bold);

            }
        }

        private void ProcessInput()
        {
            // CardParser ����� ������� static
            var parser = new CardParser();
            var results = parser.Parse(richTextBoxInput.Text);
            HighlightResults(results);
            // �������� ����� � ������ ����
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
            Help.ShowHelp(this, helpProvider1.HelpNamespace, HelpNavigator.KeywordIndex, "� ���������");
        }

        private void expToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // ����� ������ ����������� ���� ��������
            Help.ShowHelp(this, helpProvider1.HelpNamespace,
                HelpNavigator.Topic, HelpHtmDict.TopicDict["���������� ������"]);
        }

        private void grammarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // ����� ������ ����������� ���� ��������
            Help.ShowHelp(this, helpProvider1.HelpNamespace,
                HelpNavigator.Topic, HelpHtmDict.TopicDict["����������"]);

        }

        private void classificationgrammarClassToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // ����� ������ ����������� ���� ��������
            Help.ShowHelp(this, helpProvider1.HelpNamespace,
                HelpNavigator.Topic, HelpHtmDict.TopicDict["�������������"]);

        }

        private void analysismethodToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // ����� ������ ����������� ���� ��������
            Help.ShowHelp(this, helpProvider1.HelpNamespace,
                HelpNavigator.Topic, HelpHtmDict.TopicDict["����� �������"]);

        }

        private void diagnosticsNeutralizationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // ����� ������ ����������� ���� ��������
            Help.ShowHelp(this, helpProvider1.HelpNamespace,
                HelpNavigator.Topic, HelpHtmDict.TopicDict["�����������"]);

        }

        private void explToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // ����� ������ ����������� ���� ��������
            Help.ShowHelp(this, helpProvider1.HelpNamespace,
                HelpNavigator.Topic, HelpHtmDict.TopicDict["�������� ������"]);

        }

        private void bibliographyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // ����� ������ ����������� ���� ��������
            Help.ShowHelp(this, helpProvider1.HelpNamespace,
                HelpNavigator.Topic, HelpHtmDict.TopicDict["������ ����������"]);

        }

        private void sourceCodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // ����� ������ ����������� ���� ��������
            Help.ShowHelp(this, helpProvider1.HelpNamespace,
                HelpNavigator.Topic, HelpHtmDict.TopicDict["�������� ���"]);

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
            ////////////////////////////////////
            ///
            /*            DialogResult dr = MessageBox.Show("��������� ��������� ��������� ����� �������?", "����������", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                        if (dr.HasFlag(DialogResult.Yes))
                            _logic.SaveAs(richTextBoxInput.Text);
                        else if (dr.HasFlag(DialogResult.No))
                            _logic.Close();*/

            DialogResult result = MessageBox.Show(
                "�� ������ ��������� ����� �������?",
                "�������������",
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
            _edit.SaveUndo();
        }

        private void richTextBoxInput_TextChanged(object sender, EventArgs e)
        {
            isTextChanged = true;

        }

    }
}
