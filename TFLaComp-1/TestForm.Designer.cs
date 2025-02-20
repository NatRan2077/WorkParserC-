namespace TFLaComp_1
{
    partial class TestForm
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
            richTextBoxInput.Location = new Point(102, 82);
            richTextBoxInput.Name = "richTextBoxInput";
            richTextBoxInput.Size = new Size(694, 312);
            richTextBoxInput.TabIndex = 1;
            richTextBoxInput.Text = "";
            // 
            // buttonUndo
            // 
            buttonUndo.Location = new Point(102, 37);
            buttonUndo.Name = "buttonUndo";
            buttonUndo.Size = new Size(94, 29);
            buttonUndo.TabIndex = 2;
            buttonUndo.Text = "Undo";
            buttonUndo.UseVisualStyleBackColor = true;
            buttonUndo.Click += buttonUndo_Click;
            // 
            // buttonRedo
            // 
            buttonRedo.Location = new Point(202, 37);
            buttonRedo.Name = "buttonRedo";
            buttonRedo.Size = new Size(94, 29);
            buttonRedo.TabIndex = 3;
            buttonRedo.Text = "Redo";
            buttonRedo.UseVisualStyleBackColor = true;
            buttonRedo.Click += buttonRedo_Click;
            // 
            // buttonCopy
            // 
            buttonCopy.Location = new Point(402, 37);
            buttonCopy.Name = "buttonCopy";
            buttonCopy.Size = new Size(94, 29);
            buttonCopy.TabIndex = 4;
            buttonCopy.Text = "Copy";
            buttonCopy.UseVisualStyleBackColor = true;
            buttonCopy.Click += buttonCopy_Click;
            // 
            // buttonPaste
            // 
            buttonPaste.Location = new Point(502, 37);
            buttonPaste.Name = "buttonPaste";
            buttonPaste.Size = new Size(94, 29);
            buttonPaste.TabIndex = 5;
            buttonPaste.Text = "Paste";
            buttonPaste.UseVisualStyleBackColor = true;
            buttonPaste.Click += buttonPaste_Click;
            // 
            // buttonCut
            // 
            buttonCut.Location = new Point(302, 37);
            buttonCut.Name = "buttonCut";
            buttonCut.Size = new Size(94, 29);
            buttonCut.TabIndex = 6;
            buttonCut.Text = "Cut";
            buttonCut.UseVisualStyleBackColor = true;
            buttonCut.Click += buttonCut_Click;
            // 
            // buttonDelete
            // 
            buttonDelete.Location = new Point(602, 37);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(94, 29);
            buttonDelete.TabIndex = 7;
            buttonDelete.Text = "Delete";
            buttonDelete.UseVisualStyleBackColor = true;
            buttonDelete.Click += buttonDelete_Click;
            // 
            // buttonSelectAll
            // 
            buttonSelectAll.Location = new Point(702, 37);
            buttonSelectAll.Name = "buttonSelectAll";
            buttonSelectAll.Size = new Size(94, 29);
            buttonSelectAll.TabIndex = 8;
            buttonSelectAll.Text = "SelectAll";
            buttonSelectAll.UseVisualStyleBackColor = true;
            buttonSelectAll.Click += buttonSelectAll_Click;
            // 
            // TestForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(890, 450);
            Controls.Add(buttonSelectAll);
            Controls.Add(buttonDelete);
            Controls.Add(buttonCut);
            Controls.Add(buttonPaste);
            Controls.Add(buttonCopy);
            Controls.Add(buttonRedo);
            Controls.Add(buttonUndo);
            Controls.Add(richTextBoxInput);
            Name = "TestForm";
            Text = "TestForm";
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
    }
}