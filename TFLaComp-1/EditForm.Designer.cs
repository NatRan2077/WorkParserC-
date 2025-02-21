namespace TFLaComp_1
{
    partial class EditForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            contextMenuStrip1 = new ContextMenuStrip(components);
            richTextBoxInput = new RichTextBox();
            buttonUndo = new Button();
            buttonRedo = new Button();
            buttonCopy = new Button();
            buttonPaste = new Button();
            buttonCut = new Button();
            buttonDelete = new Button();
            buttonSelectAll = new Button();
            helpProvider1 = new HelpProvider();
            SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // richTextBoxInput
            // 
            helpProvider1.SetHelpKeyword(richTextBoxInput, "file.htm");
            helpProvider1.SetHelpNavigator(richTextBoxInput, HelpNavigator.Topic);
            richTextBoxInput.Location = new Point(127, 103);
            richTextBoxInput.Margin = new Padding(4, 3, 4, 3);
            richTextBoxInput.Name = "richTextBoxInput";
            helpProvider1.SetShowHelp(richTextBoxInput, true);
            richTextBoxInput.Size = new Size(867, 389);
            richTextBoxInput.TabIndex = 1;
            richTextBoxInput.Text = "";
            richTextBoxInput.KeyDown += richTextBoxInput_KeyDown;
            // 
            // buttonUndo
            // 
            buttonUndo.Location = new Point(127, 47);
            buttonUndo.Margin = new Padding(4, 3, 4, 3);
            buttonUndo.Name = "buttonUndo";
            buttonUndo.Size = new Size(117, 37);
            buttonUndo.TabIndex = 2;
            buttonUndo.Text = "Undo";
            buttonUndo.UseVisualStyleBackColor = true;
            buttonUndo.Click += buttonUndo_Click;
            // 
            // buttonRedo
            // 
            buttonRedo.Location = new Point(253, 47);
            buttonRedo.Margin = new Padding(4, 3, 4, 3);
            buttonRedo.Name = "buttonRedo";
            buttonRedo.Size = new Size(117, 37);
            buttonRedo.TabIndex = 3;
            buttonRedo.Text = "Redo";
            buttonRedo.UseVisualStyleBackColor = true;
            buttonRedo.Click += buttonRedo_Click;
            // 
            // buttonCopy
            // 
            buttonCopy.Location = new Point(503, 47);
            buttonCopy.Margin = new Padding(4, 3, 4, 3);
            buttonCopy.Name = "buttonCopy";
            buttonCopy.Size = new Size(117, 37);
            buttonCopy.TabIndex = 4;
            buttonCopy.Text = "Copy";
            buttonCopy.UseVisualStyleBackColor = true;
            buttonCopy.Click += buttonCopy_Click;
            // 
            // buttonPaste
            // 
            buttonPaste.Location = new Point(627, 47);
            buttonPaste.Margin = new Padding(4, 3, 4, 3);
            buttonPaste.Name = "buttonPaste";
            buttonPaste.Size = new Size(117, 37);
            buttonPaste.TabIndex = 5;
            buttonPaste.Text = "Paste";
            buttonPaste.UseVisualStyleBackColor = true;
            buttonPaste.Click += buttonPaste_Click;
            // 
            // buttonCut
            // 
            buttonCut.Location = new Point(377, 47);
            buttonCut.Margin = new Padding(4, 3, 4, 3);
            buttonCut.Name = "buttonCut";
            buttonCut.Size = new Size(117, 37);
            buttonCut.TabIndex = 6;
            buttonCut.Text = "Cut";
            buttonCut.UseVisualStyleBackColor = true;
            buttonCut.Click += buttonCut_Click;
            // 
            // buttonDelete
            // 
            buttonDelete.Location = new Point(753, 47);
            buttonDelete.Margin = new Padding(4, 3, 4, 3);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(117, 37);
            buttonDelete.TabIndex = 7;
            buttonDelete.Text = "Delete";
            buttonDelete.UseVisualStyleBackColor = true;
            buttonDelete.Click += buttonDelete_Click;
            // 
            // buttonSelectAll
            // 
            buttonSelectAll.Location = new Point(877, 47);
            buttonSelectAll.Margin = new Padding(4, 3, 4, 3);
            buttonSelectAll.Name = "buttonSelectAll";
            buttonSelectAll.Size = new Size(117, 37);
            buttonSelectAll.TabIndex = 8;
            buttonSelectAll.Text = "SelectAll";
            buttonSelectAll.UseVisualStyleBackColor = true;
            buttonSelectAll.Click += buttonSelectAll_Click;
            // 
            // EditForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1113, 563);
            Controls.Add(buttonSelectAll);
            Controls.Add(buttonDelete);
            Controls.Add(buttonCut);
            Controls.Add(buttonPaste);
            Controls.Add(buttonCopy);
            Controls.Add(buttonRedo);
            Controls.Add(buttonUndo);
            Controls.Add(richTextBoxInput);
            helpProvider1.SetHelpNavigator(this, HelpNavigator.TableOfContents);
            Margin = new Padding(4, 3, 4, 3);
            Name = "EditForm";
            helpProvider1.SetShowHelp(this, true);
            Text = "EditForm";
            ResumeLayout(false);
        }

        #endregion
        private ContextMenuStrip contextMenuStrip1;
        private RichTextBox richTextBoxInput;
        private Button buttonUndo;
        private Button buttonRedo;
        private Button buttonCopy;
        private Button buttonPaste;
        private Button buttonCut;
        private Button buttonDelete;
        private Button buttonSelectAll;
        private HelpProvider helpProvider1;
    }
}