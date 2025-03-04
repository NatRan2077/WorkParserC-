using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TFLaComp_1.Functional;
using TFLaComp_1.ParserHelp;

namespace TFLaComp_1
{
    public partial class EditForm : Form
    {
        private IEdit _edit;

        private IParserHelpProvider _helpProvider;

        public EditForm()
        {
            InitializeComponent();

            this.HelpButton = true;

            _edit = new Edit(richTextBoxInput);
            //_helpProvider = new ParserHelpProvider($"\\ParserHelp\\res\\parserHelpProvider.chm");
            //helpProvider1 = _helpProvider.HelpProvider;
            //helpProvider1.HelpNamespace = $"ParserHelp\\res\\parserHelpProvider.chm";


            _helpProvider = new ParserHelpProvider();
            _helpProvider.SetHelp(richTextBoxInput, HelpHtmDict.TopicDict["Правка"], HelpNavigator.Topic);
            _helpProvider.SetHelp(buttonUndo, "Отменить", HelpNavigator.KeywordIndex);
            _helpProvider.SetHelp(buttonRedo, "Повторить", HelpNavigator.KeywordIndex);
            _helpProvider.SetHelp(buttonCopy, "Копировать", HelpNavigator.KeywordIndex);
            _helpProvider.SetHelp(buttonCut, "Вырезать", HelpNavigator.KeywordIndex);
            _helpProvider.SetHelp(buttonPaste, "Вставить", HelpNavigator.KeywordIndex);
            _helpProvider.SetHelp(buttonDelete, "Удалить", HelpNavigator.KeywordIndex);
            _helpProvider.SetHelp(buttonSelectAll, "Выделить все", HelpNavigator.KeywordIndex);

            // добавить какой-то Binding?
            helpProvider1 = _helpProvider.HelpProvider;
        }

        private void buttonUndo_Click(object sender, EventArgs e)
        {
            _edit.Undo();
        }

        private void buttonRedo_Click(object sender, EventArgs e)
        {
            _edit.Redo();
        }

        private void buttonCopy_Click(object sender, EventArgs e)
        {
            _edit.Copy();
        }

        private void buttonCut_Click(object sender, EventArgs e)
        {
            _edit.Cut();
        }

        private void buttonPaste_Click(object sender, EventArgs e)
        {
            _edit.Paste();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            _edit.Delete();
        }

        private void buttonSelectAll_Click(object sender, EventArgs e)
        {
            _edit.SelectAll();
        }

        private void richTextBoxInput_KeyDown(object sender, KeyEventArgs e)
        {
            _edit.SaveAction();
        }
    }
}
