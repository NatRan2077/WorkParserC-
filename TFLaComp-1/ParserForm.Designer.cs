namespace TFLaComp_1
{
    partial class ParserForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ParserForm));
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            makeToolStripMenuItem = new ToolStripMenuItem();
            openToolStripMenuItem = new ToolStripMenuItem();
            saveToolStripMenuItem = new ToolStripMenuItem();
            saveAssToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            editingToolStripMenuItem = new ToolStripMenuItem();
            undoToolStripMenuItem = new ToolStripMenuItem();
            redoToolStripMenuItem = new ToolStripMenuItem();
            cutToolStripMenuItem = new ToolStripMenuItem();
            copyToolStripMenuItem = new ToolStripMenuItem();
            pasteToolStripMenuItem = new ToolStripMenuItem();
            deleteToolStripMenuItem = new ToolStripMenuItem();
            pasteAllToolStripMenuItem = new ToolStripMenuItem();
            textToolStripMenuItem = new ToolStripMenuItem();
            expToolStripMenuItem = new ToolStripMenuItem();
            grammarToolStripMenuItem = new ToolStripMenuItem();
            classificationgrammarClassToolStripMenuItem = new ToolStripMenuItem();
            analysismethodToolStripMenuItem = new ToolStripMenuItem();
            diagnosticsNeutralizationToolStripMenuItem = new ToolStripMenuItem();
            explToolStripMenuItem = new ToolStripMenuItem();
            bibliographyToolStripMenuItem = new ToolStripMenuItem();
            sourceCodeToolStripMenuItem = new ToolStripMenuItem();
            StartToolStripMenuItem = new ToolStripMenuItem();
            refToolStripMenuItem = new ToolStripMenuItem();
            callHelpToolStripMenuItem = new ToolStripMenuItem();
            aboutCodeToolStripMenuItem = new ToolStripMenuItem();
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
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, editingToolStripMenuItem, textToolStripMenuItem, StartToolStripMenuItem, refToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(5, 2, 0, 2);
            menuStrip1.Size = new Size(701, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            menuStrip1.ItemClicked += menuStrip1_ItemClicked;
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { makeToolStripMenuItem, openToolStripMenuItem, saveToolStripMenuItem, saveAssToolStripMenuItem, exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(48, 20);
            fileToolStripMenuItem.Text = "Фаил";
            // 
            // makeToolStripMenuItem
            // 
            makeToolStripMenuItem.Name = "makeToolStripMenuItem";
            makeToolStripMenuItem.Size = new Size(153, 22);
            makeToolStripMenuItem.Text = "Создать";
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.Size = new Size(153, 22);
            openToolStripMenuItem.Text = "Открыть";
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.Size = new Size(153, 22);
            saveToolStripMenuItem.Text = "Сохранить";
            // 
            // saveAssToolStripMenuItem
            // 
            saveAssToolStripMenuItem.Name = "saveAssToolStripMenuItem";
            saveAssToolStripMenuItem.Size = new Size(153, 22);
            saveAssToolStripMenuItem.Text = "Сохранить как";
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(153, 22);
            exitToolStripMenuItem.Text = "Выход";
            // 
            // editingToolStripMenuItem
            // 
            editingToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { undoToolStripMenuItem, redoToolStripMenuItem, cutToolStripMenuItem, copyToolStripMenuItem, pasteToolStripMenuItem, deleteToolStripMenuItem, pasteAllToolStripMenuItem });
            editingToolStripMenuItem.Name = "editingToolStripMenuItem";
            editingToolStripMenuItem.Size = new Size(59, 20);
            editingToolStripMenuItem.Text = "Правка";
            // 
            // undoToolStripMenuItem
            // 
            undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            undoToolStripMenuItem.Size = new Size(148, 22);
            undoToolStripMenuItem.Text = "Отменить";
            // 
            // redoToolStripMenuItem
            // 
            redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            redoToolStripMenuItem.Size = new Size(148, 22);
            redoToolStripMenuItem.Text = "Повторить";
            // 
            // cutToolStripMenuItem
            // 
            cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            cutToolStripMenuItem.Size = new Size(148, 22);
            cutToolStripMenuItem.Text = "Вырезать";
            // 
            // copyToolStripMenuItem
            // 
            copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            copyToolStripMenuItem.Size = new Size(148, 22);
            copyToolStripMenuItem.Text = "Копировать";
            // 
            // pasteToolStripMenuItem
            // 
            pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            pasteToolStripMenuItem.Size = new Size(148, 22);
            pasteToolStripMenuItem.Text = "Вставить";
            // 
            // deleteToolStripMenuItem
            // 
            deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            deleteToolStripMenuItem.Size = new Size(148, 22);
            deleteToolStripMenuItem.Text = "Удалить";
            // 
            // pasteAllToolStripMenuItem
            // 
            pasteAllToolStripMenuItem.Name = "pasteAllToolStripMenuItem";
            pasteAllToolStripMenuItem.Size = new Size(148, 22);
            pasteAllToolStripMenuItem.Text = "Выделить все";
            // 
            // textToolStripMenuItem
            // 
            textToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { expToolStripMenuItem, grammarToolStripMenuItem, classificationgrammarClassToolStripMenuItem, analysismethodToolStripMenuItem, diagnosticsNeutralizationToolStripMenuItem, explToolStripMenuItem, bibliographyToolStripMenuItem, sourceCodeToolStripMenuItem });
            textToolStripMenuItem.Name = "textToolStripMenuItem";
            textToolStripMenuItem.Size = new Size(49, 20);
            textToolStripMenuItem.Text = "Текст";
            // 
            // expToolStripMenuItem
            // 
            expToolStripMenuItem.Name = "expToolStripMenuItem";
            expToolStripMenuItem.Size = new Size(288, 22);
            expToolStripMenuItem.Text = "Постановка задачи";
            // 
            // grammarToolStripMenuItem
            // 
            grammarToolStripMenuItem.Name = "grammarToolStripMenuItem";
            grammarToolStripMenuItem.Size = new Size(288, 22);
            grammarToolStripMenuItem.Text = "Грамматика";
            // 
            // classificationgrammarClassToolStripMenuItem
            // 
            classificationgrammarClassToolStripMenuItem.Name = "classificationgrammarClassToolStripMenuItem";
            classificationgrammarClassToolStripMenuItem.Size = new Size(288, 22);
            classificationgrammarClassToolStripMenuItem.Text = "Классификация грамматики";
            // 
            // analysismethodToolStripMenuItem
            // 
            analysismethodToolStripMenuItem.Name = "analysismethodToolStripMenuItem";
            analysismethodToolStripMenuItem.Size = new Size(288, 22);
            analysismethodToolStripMenuItem.Text = "Метод анализа";
            // 
            // diagnosticsNeutralizationToolStripMenuItem
            // 
            diagnosticsNeutralizationToolStripMenuItem.Name = "diagnosticsNeutralizationToolStripMenuItem";
            diagnosticsNeutralizationToolStripMenuItem.Size = new Size(288, 22);
            diagnosticsNeutralizationToolStripMenuItem.Text = "Диагностика и нейтрализация ошибок";
            // 
            // explToolStripMenuItem
            // 
            explToolStripMenuItem.Name = "explToolStripMenuItem";
            explToolStripMenuItem.Size = new Size(288, 22);
            explToolStripMenuItem.Text = "Тестовый пример";
            // 
            // bibliographyToolStripMenuItem
            // 
            bibliographyToolStripMenuItem.Name = "bibliographyToolStripMenuItem";
            bibliographyToolStripMenuItem.Size = new Size(288, 22);
            bibliographyToolStripMenuItem.Text = "Список литературы";
            // 
            // sourceCodeToolStripMenuItem
            // 
            sourceCodeToolStripMenuItem.Name = "sourceCodeToolStripMenuItem";
            sourceCodeToolStripMenuItem.Size = new Size(288, 22);
            sourceCodeToolStripMenuItem.Text = "Исходный код программы";
            // 
            // StartToolStripMenuItem
            // 
            StartToolStripMenuItem.Name = "StartToolStripMenuItem";
            StartToolStripMenuItem.Size = new Size(46, 20);
            StartToolStripMenuItem.Text = "Пуск";
            // 
            // refToolStripMenuItem
            // 
            refToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { callHelpToolStripMenuItem, aboutCodeToolStripMenuItem });
            refToolStripMenuItem.Name = "refToolStripMenuItem";
            refToolStripMenuItem.Size = new Size(65, 20);
            refToolStripMenuItem.Text = "Справка";
            // 
            // callHelpToolStripMenuItem
            // 
            callHelpToolStripMenuItem.Name = "callHelpToolStripMenuItem";
            callHelpToolStripMenuItem.Size = new Size(156, 22);
            callHelpToolStripMenuItem.Text = "Вызов справки";
            // 
            // aboutCodeToolStripMenuItem
            // 
            aboutCodeToolStripMenuItem.Name = "aboutCodeToolStripMenuItem";
            aboutCodeToolStripMenuItem.Size = new Size(156, 22);
            aboutCodeToolStripMenuItem.Text = "О программе";
            // 
            // file
            // 
            file.BackgroundImage = (Image)resources.GetObject("file.BackgroundImage");
            file.BackgroundImageLayout = ImageLayout.Zoom;
            file.Location = new Point(10, 23);
            file.Margin = new Padding(3, 2, 3, 2);
            file.Name = "file";
            file.Size = new Size(67, 52);
            file.TabIndex = 1;
            file.UseVisualStyleBackColor = true;
            file.Click += file_Click;
            // 
            // open
            // 
            open.BackgroundImage = (Image)resources.GetObject("open.BackgroundImage");
            open.BackgroundImageLayout = ImageLayout.Zoom;
            open.Location = new Point(83, 23);
            open.Margin = new Padding(3, 2, 3, 2);
            open.Name = "open";
            open.Size = new Size(67, 52);
            open.TabIndex = 2;
            open.UseVisualStyleBackColor = true;
            // 
            // save
            // 
            save.BackgroundImage = (Image)resources.GetObject("save.BackgroundImage");
            save.BackgroundImageLayout = ImageLayout.Zoom;
            save.Location = new Point(156, 23);
            save.Margin = new Padding(3, 2, 3, 2);
            save.Name = "save";
            save.Size = new Size(67, 52);
            save.TabIndex = 3;
            save.UseVisualStyleBackColor = true;
            // 
            // start
            // 
            start.BackgroundImage = (Image)resources.GetObject("start.BackgroundImage");
            start.BackgroundImageLayout = ImageLayout.Zoom;
            start.Location = new Point(228, 23);
            start.Margin = new Padding(3, 2, 3, 2);
            start.Name = "start";
            start.Size = new Size(67, 52);
            start.TabIndex = 4;
            start.Text = "start";
            start.UseVisualStyleBackColor = true;
            // 
            // undo
            // 
            undo.BackgroundImage = (Image)resources.GetObject("undo.BackgroundImage");
            undo.BackgroundImageLayout = ImageLayout.Zoom;
            undo.Location = new Point(301, 23);
            undo.Margin = new Padding(3, 2, 3, 2);
            undo.Name = "undo";
            undo.Size = new Size(67, 52);
            undo.TabIndex = 5;
            undo.UseVisualStyleBackColor = true;
            // 
            // redo
            // 
            redo.BackgroundImage = (Image)resources.GetObject("redo.BackgroundImage");
            redo.BackgroundImageLayout = ImageLayout.Zoom;
            redo.Location = new Point(374, 23);
            redo.Margin = new Padding(3, 2, 3, 2);
            redo.Name = "redo";
            redo.Size = new Size(67, 52);
            redo.TabIndex = 6;
            redo.UseVisualStyleBackColor = true;
            // 
            // cut
            // 
            cut.BackgroundImage = (Image)resources.GetObject("cut.BackgroundImage");
            cut.BackgroundImageLayout = ImageLayout.Zoom;
            cut.Location = new Point(446, 23);
            cut.Margin = new Padding(3, 2, 3, 2);
            cut.Name = "cut";
            cut.Size = new Size(67, 52);
            cut.TabIndex = 7;
            cut.UseVisualStyleBackColor = true;
            // 
            // paste
            // 
            paste.BackgroundImage = (Image)resources.GetObject("paste.BackgroundImage");
            paste.BackgroundImageLayout = ImageLayout.Zoom;
            paste.Location = new Point(519, 23);
            paste.Margin = new Padding(3, 2, 3, 2);
            paste.Name = "paste";
            paste.Size = new Size(67, 52);
            paste.TabIndex = 8;
            paste.UseVisualStyleBackColor = true;
            // 
            // richTextBoxInput
            // 
            richTextBoxInput.Location = new Point(10, 80);
            richTextBoxInput.Margin = new Padding(3, 2, 3, 2);
            richTextBoxInput.Name = "richTextBoxInput";
            richTextBoxInput.Size = new Size(681, 216);
            richTextBoxInput.TabIndex = 9;
            richTextBoxInput.Text = "";
            // 
            // richTextBoxOutput
            // 
            richTextBoxOutput.Location = new Point(10, 327);
            richTextBoxOutput.Margin = new Padding(3, 2, 3, 2);
            richTextBoxOutput.Name = "richTextBoxOutput";
            richTextBoxOutput.Size = new Size(681, 216);
            richTextBoxOutput.TabIndex = 10;
            richTextBoxOutput.Text = "";
            // 
            // copy
            // 
            copy.BackgroundImage = (Image)resources.GetObject("copy.BackgroundImage");
            copy.BackgroundImageLayout = ImageLayout.Zoom;
            copy.Location = new Point(592, 23);
            copy.Margin = new Padding(3, 2, 3, 2);
            copy.Name = "copy";
            copy.Size = new Size(67, 52);
            copy.TabIndex = 11;
            copy.UseVisualStyleBackColor = true;
            // 
            // ParserForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(701, 598);
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
            Margin = new Padding(3, 2, 3, 2);
            Name = "ParserForm";
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
