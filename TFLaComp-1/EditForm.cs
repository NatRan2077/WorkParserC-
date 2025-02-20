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

namespace TFLaComp_1
{
    public partial class EditForm : Form
    {
        private IEdit _edit;

        public EditForm()
        {
            InitializeComponent();

            _edit = new Edit(richTextBoxInput);
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
