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
            _helpProvider.SetHelp(richTextBoxInput, HelpHtmDict.TopicDict["Ïðàâêà"], HelpNavigator.Topic);
            _helpProvider.SetHelp(file, "Ñîçäàòü", HelpNavigator.KeywordIndex);
            _helpProvider.SetHelp(open, "Îòêðûòü", HelpNavigator.KeywordIndex);
            _helpProvider.SetHelp(save, "Ñîõðàíèòü", HelpNavigator.KeywordIndex);
            _helpProvider.SetHelp(start, "Ïóñê", HelpNavigator.Topic);

            _helpProvider.SetHelp(undo, "Îòìåíèòü", HelpNavigator.KeywordIndex);
            _helpProvider.SetHelp(redo, "Ïîâòîðèòü", HelpNavigator.KeywordIndex);
            _helpProvider.SetHelp(copy, "Êîïèðîâàòü", HelpNavigator.KeywordIndex);
            _helpProvider.SetHelp(cut, "Âûðåçàòü", HelpNavigator.KeywordIndex);
            _helpProvider.SetHelp(paste, "Âñòàâèòü", HelpNavigator.KeywordIndex);
            //_helpProvider.SetHelp(, "Óäàëèòü", HelpNavigator.KeywordIndex);
            //_helpProvider.SetHelp(, "Âûäåëèòü âñå", HelpNavigator.KeywordIndex);

            _helpProvider.SetHelp(this, "Î ïðîãðàììå", HelpNavigator.KeywordIndex);

            // äîáàâèòü êàêîé-òî Binding?
            helpProvider1 = _helpProvider.HelpProvider;

            richTextBoxInput.TextChanged += richTextBoxInput_TextChanged;
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void makeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // äîáàâèòü Binding
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
                // äîáàâèòü Binding
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
            if (!isTextChanged) return true; // Åñëè èçìåíåíèé íåò, ïðîñòî ïðîäîëæàåì.

            DialogResult result = MessageBox.Show(
                "Ñîõðàíèòü èçìåíåíèÿ ïåðåä îòêðûòèåì íîâîãî ôàéëà?",
                "Ïîäòâåðæäåíèå",
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

            return false; // Îòìåíà îïåðàöèè
        }

        private void LoadFile()
        {
            try
            {
                string? text = _logic.Open();
                if (text == null)
                    throw new FileLoadException("Îøèáêà îòêðûòèÿ ôàéëà!");

                richTextBoxInput.Text = text;
                isTextChanged = false; // Ñáðàñûâàåì ôëàã èçìåíåíèé
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Îøèáêà", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            // Ñáðîñ ïðåäûäóùåãî âûäåëåíèÿ.
            richTextBoxInput.SelectAll();
            richTextBoxInput.SelectionColor = richTextBoxInput.ForeColor; // Âîññòàíàâëèâàåì öâåò òåêñòà.
            richTextBoxInput.SelectionFont = richTextBoxInput.Font; // Âîññòàíàâëèâàåì øðèôò.


            foreach (var card in cards)
            {
                richTextBoxInput.Select(card.IndexStart, card.IndexEnd - card.IndexStart + 1);
                switch (card.NumberCard[0])
                {
                    case '2':  // Ìèð
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
            // CardParser ìîæíî ñäåëàòü static
            var parser = new CardParser();
            var results = parser.Parse(richTextBoxInput.Text);
            HighlightResults(results);
            // âñòàâèòü âûâîä â íèæíåå ïîëå
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
            Help.ShowHelp(this, helpProvider1.HelpNamespace, HelpNavigator.KeywordIndex, "Î ïðîãðàììå");
        }

        private void expToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // ïîòîì äîëæåí îòêðûâàòüñÿ ôàéë êóðñîâîé
            Help.ShowHelp(this, helpProvider1.HelpNamespace,
                HelpNavigator.Topic, HelpHtmDict.TopicDict["Ïîñòàíîâêà çàäà÷è"]);
        }

        private void grammarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // ïîòîì äîëæåí îòêðûâàòüñÿ ôàéë êóðñîâîé
            Help.ShowHelp(this, helpProvider1.HelpNamespace,
                HelpNavigator.Topic, HelpHtmDict.TopicDict["Ãðàììàòèêà"]);

        }

        private void classificationgrammarClassToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // ïîòîì äîëæåí îòêðûâàòüñÿ ôàéë êóðñîâîé
            Help.ShowHelp(this, helpProvider1.HelpNamespace,
                HelpNavigator.Topic, HelpHtmDict.TopicDict["Êëàññèôèêàöèÿ"]);

        }

        private void analysismethodToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // ïîòîì äîëæåí îòêðûâàòüñÿ ôàéë êóðñîâîé
            Help.ShowHelp(this, helpProvider1.HelpNamespace,
                HelpNavigator.Topic, HelpHtmDict.TopicDict["Ìåòîä àíàëèçà"]);

        }

        private void diagnosticsNeutralizationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // ïîòîì äîëæåí îòêðûâàòüñÿ ôàéë êóðñîâîé
            Help.ShowHelp(this, helpProvider1.HelpNamespace,
                HelpNavigator.Topic, HelpHtmDict.TopicDict["Äèàãíîñòèêà"]);

        }

        private void explToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // ïîòîì äîëæåí îòêðûâàòüñÿ ôàéë êóðñîâîé
            Help.ShowHelp(this, helpProvider1.HelpNamespace,
                HelpNavigator.Topic, HelpHtmDict.TopicDict["Òåñòîâûé ïðèìåð"]);

        }

        private void bibliographyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // ïîòîì äîëæåí îòêðûâàòüñÿ ôàéë êóðñîâîé
            Help.ShowHelp(this, helpProvider1.HelpNamespace,
                HelpNavigator.Topic, HelpHtmDict.TopicDict["Ñïèñîê ëèòåðàòóðû"]);

        }

        private void sourceCodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // ïîòîì äîëæåí îòêðûâàòüñÿ ôàéë êóðñîâîé
            Help.ShowHelp(this, helpProvider1.HelpNamespace,
                HelpNavigator.Topic, HelpHtmDict.TopicDict["Èñõîäíûé êîä"]);

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
            /*            DialogResult dr = MessageBox.Show("Ñîõðàíèòü âíåñåííûå èçìåíåíèÿ ïåðåä âûõîäîì?", "Ñîõðàíåíèå", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                        if (dr.HasFlag(DialogResult.Yes))
                            _logic.SaveAs(richTextBoxInput.Text);
                        else if (dr.HasFlag(DialogResult.No))
                            _logic.Close();*/

            DialogResult result = MessageBox.Show(
                "Âû õîòèòå ñîõðàíèòü ïåðåä âûõîäîì?",
                "Ïîäòâåðæäåíèå",
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

        private void richTextBoxOutput_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBoxInput_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
