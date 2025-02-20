namespace TFLaComp_1
{
    partial class Form
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form));
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            editingToolStripMenuItem = new ToolStripMenuItem();
            textToolStripMenuItem = new ToolStripMenuItem();
            StartToolStripMenuItem = new ToolStripMenuItem();
            refToolStripMenuItem = new ToolStripMenuItem();
            file = new Button();
            open = new Button();
            save = new Button();
            start = new Button();
            undo = new Button();
            redo = new Button();
            cut = new Button();
            paste = new Button();
            richTextBoxInput = new RichTextBox();
            richTextBoxOutput = new RichTextBox();
            copy = new Button();
            makeToolStripMenuItem = new ToolStripMenuItem();
            openToolStripMenuItem = new ToolStripMenuItem();
            saveToolStripMenuItem = new ToolStripMenuItem();
            saveAssToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            undoToolStripMenuItem = new ToolStripMenuItem();
            redoToolStripMenuItem = new ToolStripMenuItem();
            cutToolStripMenuItem = new ToolStripMenuItem();
            copyToolStripMenuItem = new ToolStripMenuItem();
            pasteToolStripMenuItem = new ToolStripMenuItem();
            deleteToolStripMenuItem = new ToolStripMenuItem();
            pasteAllToolStripMenuItem = new ToolStripMenuItem();
            expToolStripMenuItem = new ToolStripMenuItem();
            grammarToolStripMenuItem = new ToolStripMenuItem();
            classificationgrammarClassToolStripMenuItem = new ToolStripMenuItem();
            analysismethodToolStripMenuItem = new ToolStripMenuItem();
            diagnosticsNeutralizationToolStripMenuItem = new ToolStripMenuItem();
            explToolStripMenuItem = new ToolStripMenuItem();
            bibliographyToolStripMenuItem = new ToolStripMenuItem();
            sourceCodeToolStripMenuItem = new ToolStripMenuItem();
            callHelpToolStripMenuItem = new ToolStripMenuItem();
            aboutCodeToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, editingToolStripMenuItem, textToolStripMenuItem, StartToolStripMenuItem, refToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(801, 28);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            menuStrip1.ItemClicked += menuStrip1_ItemClicked;
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { makeToolStripMenuItem, openToolStripMenuItem, saveToolStripMenuItem, saveAssToolStripMenuItem, exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(59, 24);
            fileToolStripMenuItem.Text = "Фаил";
            // 
            // editingToolStripMenuItem
            // 
            editingToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { undoToolStripMenuItem, redoToolStripMenuItem, cutToolStripMenuItem, copyToolStripMenuItem, pasteToolStripMenuItem, deleteToolStripMenuItem, pasteAllToolStripMenuItem });
            editingToolStripMenuItem.Name = "editingToolStripMenuItem";
            editingToolStripMenuItem.Size = new Size(74, 24);
            editingToolStripMenuItem.Text = "Правка";
            // 
            // textToolStripMenuItem
            // 
            textToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { expToolStripMenuItem, grammarToolStripMenuItem, classificationgrammarClassToolStripMenuItem, analysismethodToolStripMenuItem, diagnosticsNeutralizationToolStripMenuItem, explToolStripMenuItem, bibliographyToolStripMenuItem, sourceCodeToolStripMenuItem });
            textToolStripMenuItem.Name = "textToolStripMenuItem";
            textToolStripMenuItem.Size = new Size(59, 24);
            textToolStripMenuItem.Text = "Текст";
            // 
            // StartToolStripMenuItem
            // 
            StartToolStripMenuItem.Name = "StartToolStripMenuItem";
            StartToolStripMenuItem.Size = new Size(55, 24);
            StartToolStripMenuItem.Text = "Пуск";
            // 
            // refToolStripMenuItem
            // 
            refToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { callHelpToolStripMenuItem, aboutCodeToolStripMenuItem });
            refToolStripMenuItem.Name = "refToolStripMenuItem";
            refToolStripMenuItem.Size = new Size(81, 24);
            refToolStripMenuItem.Text = "Справка";
            // 
            // file
            // 
            file.BackgroundImage = (Image)resources.GetObject("file.BackgroundImage");
            file.BackgroundImageLayout = ImageLayout.Zoom;
            file.Location = new Point(12, 31);
            file.Name = "file";
            file.Size = new Size(77, 70);
            file.TabIndex = 1;
            file.UseVisualStyleBackColor = true;
            file.Click += file_Click;
            // 
            // open
            // 
            open.BackgroundImage = (Image)resources.GetObject("open.BackgroundImage");
            open.BackgroundImageLayout = ImageLayout.Zoom;
            open.Location = new Point(95, 31);
            open.Name = "open";
            open.Size = new Size(77, 70);
            open.TabIndex = 2;
            open.UseVisualStyleBackColor = true;
            // 
            // save
            // 
            save.BackgroundImage = (Image)resources.GetObject("save.BackgroundImage");
            save.BackgroundImageLayout = ImageLayout.Zoom;
            save.Location = new Point(178, 31);
            save.Name = "save";
            save.Size = new Size(77, 70);
            save.TabIndex = 3;
            save.UseVisualStyleBackColor = true;
            // 
            // start
            // 
            start.BackgroundImage = (Image)resources.GetObject("start.BackgroundImage");
            start.BackgroundImageLayout = ImageLayout.Zoom;
            start.Location = new Point(261, 31);
            start.Name = "start";
            start.Size = new Size(77, 70);
            start.TabIndex = 4;
            start.Text = "start";
            start.UseVisualStyleBackColor = true;
            // 
            // undo
            // 
            undo.BackgroundImage = (Image)resources.GetObject("undo.BackgroundImage");
            undo.BackgroundImageLayout = ImageLayout.Zoom;
            undo.Location = new Point(344, 31);
            undo.Name = "undo";
            undo.Size = new Size(77, 70);
            undo.TabIndex = 5;
            undo.UseVisualStyleBackColor = true;
            // 
            // redo
            // 
            redo.BackgroundImage = (Image)resources.GetObject("redo.BackgroundImage");
            redo.BackgroundImageLayout = ImageLayout.Zoom;
            redo.Location = new Point(427, 31);
            redo.Name = "redo";
            redo.Size = new Size(77, 70);
            redo.TabIndex = 6;
            redo.UseVisualStyleBackColor = true;
            // 
            // cut
            // 
            cut.BackgroundImage = (Image)resources.GetObject("cut.BackgroundImage");
            cut.BackgroundImageLayout = ImageLayout.Zoom;
            cut.Location = new Point(510, 31);
            cut.Name = "cut";
            cut.Size = new Size(77, 70);
            cut.TabIndex = 7;
            cut.UseVisualStyleBackColor = true;
            // 
            // paste
            // 
            paste.BackgroundImage = (Image)resources.GetObject("paste.BackgroundImage");
            paste.BackgroundImageLayout = ImageLayout.Zoom;
            paste.Location = new Point(593, 31);
            paste.Name = "paste";
            paste.Size = new Size(77, 70);
            paste.TabIndex = 8;
            paste.UseVisualStyleBackColor = true;
            // 
            // richTextBoxInput
            // 
            richTextBoxInput.Location = new Point(12, 107);
            richTextBoxInput.Name = "richTextBoxInput";
            richTextBoxInput.Size = new Size(778, 287);
            richTextBoxInput.TabIndex = 9;
            richTextBoxInput.Text = "";
            // 
            // richTextBoxOutput
            // 
            richTextBoxOutput.Location = new Point(12, 436);
            richTextBoxOutput.Name = "richTextBoxOutput";
            richTextBoxOutput.Size = new Size(778, 287);
            richTextBoxOutput.TabIndex = 10;
            richTextBoxOutput.Text = "";
            // 
            // copy
            // 
            copy.BackgroundImage = (Image)resources.GetObject("copy.BackgroundImage");
            copy.BackgroundImageLayout = ImageLayout.Zoom;
            copy.Location = new Point(676, 31);
            copy.Name = "copy";
            copy.Size = new Size(77, 70);
            copy.TabIndex = 11;
            copy.UseVisualStyleBackColor = true;
            // 
            // makeToolStripMenuItem
            // 
            makeToolStripMenuItem.Name = "makeToolStripMenuItem";
            makeToolStripMenuItem.Size = new Size(224, 26);
            makeToolStripMenuItem.Text = "Создать";
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.Size = new Size(224, 26);
            openToolStripMenuItem.Text = "Открыть";
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.Size = new Size(224, 26);
            saveToolStripMenuItem.Text = "Сохранить";
            // 
            // saveAssToolStripMenuItem
            // 
            saveAssToolStripMenuItem.Name = "saveAssToolStripMenuItem";
            saveAssToolStripMenuItem.Size = new Size(224, 26);
            saveAssToolStripMenuItem.Text = "Сохранить как";
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(224, 26);
            exitToolStripMenuItem.Text = "Выход";
            // 
            // undoToolStripMenuItem
            // 
            undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            undoToolStripMenuItem.Size = new Size(224, 26);
            undoToolStripMenuItem.Text = "Отменить";
            // 
            // redoToolStripMenuItem
            // 
            redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            redoToolStripMenuItem.Size = new Size(224, 26);
            redoToolStripMenuItem.Text = "Повторить";
            // 
            // cutToolStripMenuItem
            // 
            cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            cutToolStripMenuItem.Size = new Size(224, 26);
            cutToolStripMenuItem.Text = "Вырезать";
            // 
            // copyToolStripMenuItem
            // 
            copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            copyToolStripMenuItem.Size = new Size(224, 26);
            copyToolStripMenuItem.Text = "Копировать";
            // 
            // pasteToolStripMenuItem
            // 
            pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            pasteToolStripMenuItem.Size = new Size(224, 26);
            pasteToolStripMenuItem.Text = "Вставить";
            // 
            // deleteToolStripMenuItem
            // 
            deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            deleteToolStripMenuItem.Size = new Size(224, 26);
            deleteToolStripMenuItem.Text = "Удалить";
            // 
            // pasteAllToolStripMenuItem
            // 
            pasteAllToolStripMenuItem.Name = "pasteAllToolStripMenuItem";
            pasteAllToolStripMenuItem.Size = new Size(224, 26);
            pasteAllToolStripMenuItem.Text = "Выделить все";
            // 
            // expToolStripMenuItem
            // 
            expToolStripMenuItem.Name = "expToolStripMenuItem";
            expToolStripMenuItem.Size = new Size(363, 26);
            expToolStripMenuItem.Text = "Постановка задачи";
            // 
            // grammarToolStripMenuItem
            // 
            grammarToolStripMenuItem.Name = "grammarToolStripMenuItem";
            grammarToolStripMenuItem.Size = new Size(363, 26);
            grammarToolStripMenuItem.Text = "Грамматика";
            // 
            // classificationgrammarClassToolStripMenuItem
            // 
            classificationgrammarClassToolStripMenuItem.Name = "classificationgrammarClassToolStripMenuItem";
            classificationgrammarClassToolStripMenuItem.Size = new Size(363, 26);
            classificationgrammarClassToolStripMenuItem.Text = "Классификация грамматики";
            // 
            // analysismethodToolStripMenuItem
            // 
            analysismethodToolStripMenuItem.Name = "analysismethodToolStripMenuItem";
            analysismethodToolStripMenuItem.Size = new Size(363, 26);
            analysismethodToolStripMenuItem.Text = "Метод анализа";
            // 
            // diagnosticsNeutralizationToolStripMenuItem
            // 
            diagnosticsNeutralizationToolStripMenuItem.Name = "diagnosticsNeutralizationToolStripMenuItem";
            diagnosticsNeutralizationToolStripMenuItem.Size = new Size(363, 26);
            diagnosticsNeutralizationToolStripMenuItem.Text = "Диагностика и нейтрализация ошибок";
            // 
            // explToolStripMenuItem
            // 
            explToolStripMenuItem.Name = "explToolStripMenuItem";
            explToolStripMenuItem.Size = new Size(363, 26);
            explToolStripMenuItem.Text = "Тестовый пример";
            // 
            // bibliographyToolStripMenuItem
            // 
            bibliographyToolStripMenuItem.Name = "bibliographyToolStripMenuItem";
            bibliographyToolStripMenuItem.Size = new Size(363, 26);
            bibliographyToolStripMenuItem.Text = "Список литературы";
            // 
            // sourceCodeToolStripMenuItem
            // 
            sourceCodeToolStripMenuItem.Name = "sourceCodeToolStripMenuItem";
            sourceCodeToolStripMenuItem.Size = new Size(363, 26);
            sourceCodeToolStripMenuItem.Text = "Исходный код программы";
            // 
            // callHelpToolStripMenuItem
            // 
            callHelpToolStripMenuItem.Name = "callHelpToolStripMenuItem";
            callHelpToolStripMenuItem.Size = new Size(224, 26);
            callHelpToolStripMenuItem.Text = "Вызов справки";
            // 
            // aboutCodeToolStripMenuItem
            // 
            aboutCodeToolStripMenuItem.Name = "aboutCodeToolStripMenuItem";
            aboutCodeToolStripMenuItem.Size = new Size(224, 26);
            aboutCodeToolStripMenuItem.Text = "О программе";
            // 
            // Form
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(801, 797);
            Controls.Add(copy);
            Controls.Add(richTextBoxOutput);
            Controls.Add(richTextBoxInput);
            Controls.Add(paste);
            Controls.Add(cut);
            Controls.Add(redo);
            Controls.Add(undo);
            Controls.Add(start);
            Controls.Add(save);
            Controls.Add(open);
            Controls.Add(file);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form";
            Text = "Парсер";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem editingToolStripMenuItem;
        private ToolStripMenuItem textToolStripMenuItem;
        private ToolStripMenuItem StartToolStripMenuItem;
        private ToolStripMenuItem refToolStripMenuItem;
        private Button file;
        private Button open;
        private Button save;
        private Button start;
        private Button undo;
        private Button redo;
        private Button cut;
        private Button paste;
        private RichTextBox richTextBoxInput;
        private RichTextBox richTextBoxOutput;
        private Button copy;
        private ToolStripMenuItem makeToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem saveAssToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem undoToolStripMenuItem;
        private ToolStripMenuItem redoToolStripMenuItem;
        private ToolStripMenuItem cutToolStripMenuItem;
        private ToolStripMenuItem copyToolStripMenuItem;
        private ToolStripMenuItem pasteToolStripMenuItem;
        private ToolStripMenuItem deleteToolStripMenuItem;
        private ToolStripMenuItem pasteAllToolStripMenuItem;
        private ToolStripMenuItem expToolStripMenuItem;
        private ToolStripMenuItem grammarToolStripMenuItem;
        private ToolStripMenuItem classificationgrammarClassToolStripMenuItem;
        private ToolStripMenuItem analysismethodToolStripMenuItem;
        private ToolStripMenuItem diagnosticsNeutralizationToolStripMenuItem;
        private ToolStripMenuItem explToolStripMenuItem;
        private ToolStripMenuItem bibliographyToolStripMenuItem;
        private ToolStripMenuItem sourceCodeToolStripMenuItem;
        private ToolStripMenuItem callHelpToolStripMenuItem;
        private ToolStripMenuItem aboutCodeToolStripMenuItem;
    }
}
