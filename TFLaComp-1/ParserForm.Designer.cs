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
            helpProvider1 = new HelpProvider();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, editingToolStripMenuItem, textToolStripMenuItem, StartToolStripMenuItem, refToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(7, 3, 0, 3);
            menuStrip1.Size = new Size(1001, 35);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            menuStrip1.ItemClicked += menuStrip1_ItemClicked;
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { makeToolStripMenuItem, openToolStripMenuItem, saveToolStripMenuItem, saveAssToolStripMenuItem, exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(69, 29);
            fileToolStripMenuItem.Text = "Файл";
            // 
            // makeToolStripMenuItem
            // 
            makeToolStripMenuItem.Name = "makeToolStripMenuItem";
            makeToolStripMenuItem.Size = new Size(270, 34);
            makeToolStripMenuItem.Text = "Создать";
            makeToolStripMenuItem.Click += makeToolStripMenuItem_Click;
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.Size = new Size(270, 34);
            openToolStripMenuItem.Text = "Открыть";
            openToolStripMenuItem.Click += openToolStripMenuItem_Click;
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.Size = new Size(270, 34);
            saveToolStripMenuItem.Text = "Сохранить";
            saveToolStripMenuItem.Click += saveToolStripMenuItem_Click;
            // 
            // saveAssToolStripMenuItem
            // 
            saveAssToolStripMenuItem.Name = "saveAssToolStripMenuItem";
            saveAssToolStripMenuItem.Size = new Size(270, 34);
            saveAssToolStripMenuItem.Text = "Сохранить как";
            saveAssToolStripMenuItem.Click += saveAssToolStripMenuItem_Click;
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(270, 34);
            exitToolStripMenuItem.Text = "Выход";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // editingToolStripMenuItem
            // 
            editingToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { undoToolStripMenuItem, redoToolStripMenuItem, cutToolStripMenuItem, copyToolStripMenuItem, pasteToolStripMenuItem, deleteToolStripMenuItem, pasteAllToolStripMenuItem });
            editingToolStripMenuItem.Name = "editingToolStripMenuItem";
            editingToolStripMenuItem.Size = new Size(89, 29);
            editingToolStripMenuItem.Text = "Правка";
            // 
            // undoToolStripMenuItem
            // 
            undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            undoToolStripMenuItem.Size = new Size(223, 34);
            undoToolStripMenuItem.Text = "Отменить";
            undoToolStripMenuItem.Click += undoToolStripMenuItem_Click;
            // 
            // redoToolStripMenuItem
            // 
            redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            redoToolStripMenuItem.Size = new Size(223, 34);
            redoToolStripMenuItem.Text = "Повторить";
            redoToolStripMenuItem.Click += redoToolStripMenuItem_Click;
            // 
            // cutToolStripMenuItem
            // 
            cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            cutToolStripMenuItem.Size = new Size(223, 34);
            cutToolStripMenuItem.Text = "Вырезать";
            cutToolStripMenuItem.Click += cutToolStripMenuItem_Click;
            // 
            // copyToolStripMenuItem
            // 
            copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            copyToolStripMenuItem.Size = new Size(223, 34);
            copyToolStripMenuItem.Text = "Копировать";
            copyToolStripMenuItem.Click += copyToolStripMenuItem_Click;
            // 
            // pasteToolStripMenuItem
            // 
            pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            pasteToolStripMenuItem.Size = new Size(223, 34);
            pasteToolStripMenuItem.Text = "Вставить";
            pasteToolStripMenuItem.Click += pasteToolStripMenuItem_Click;
            // 
            // deleteToolStripMenuItem
            // 
            deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            deleteToolStripMenuItem.Size = new Size(223, 34);
            deleteToolStripMenuItem.Text = "Удалить";
            deleteToolStripMenuItem.Click += deleteToolStripMenuItem_Click;
            // 
            // pasteAllToolStripMenuItem
            // 
            pasteAllToolStripMenuItem.Name = "pasteAllToolStripMenuItem";
            pasteAllToolStripMenuItem.Size = new Size(223, 34);
            pasteAllToolStripMenuItem.Text = "Выделить все";
            pasteAllToolStripMenuItem.Click += pasteAllToolStripMenuItem_Click;
            // 
            // textToolStripMenuItem
            // 
            textToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { expToolStripMenuItem, grammarToolStripMenuItem, classificationgrammarClassToolStripMenuItem, analysismethodToolStripMenuItem, diagnosticsNeutralizationToolStripMenuItem, explToolStripMenuItem, bibliographyToolStripMenuItem, sourceCodeToolStripMenuItem });
            textToolStripMenuItem.Name = "textToolStripMenuItem";
            textToolStripMenuItem.Size = new Size(70, 29);
            textToolStripMenuItem.Text = "Текст";
            // 
            // expToolStripMenuItem
            // 
            expToolStripMenuItem.Name = "expToolStripMenuItem";
            expToolStripMenuItem.Size = new Size(428, 34);
            expToolStripMenuItem.Text = "Постановка задачи";
            expToolStripMenuItem.Click += expToolStripMenuItem_Click;
            // 
            // grammarToolStripMenuItem
            // 
            grammarToolStripMenuItem.Name = "grammarToolStripMenuItem";
            grammarToolStripMenuItem.Size = new Size(428, 34);
            grammarToolStripMenuItem.Text = "Грамматика";
            grammarToolStripMenuItem.Click += grammarToolStripMenuItem_Click;
            // 
            // classificationgrammarClassToolStripMenuItem
            // 
            classificationgrammarClassToolStripMenuItem.Name = "classificationgrammarClassToolStripMenuItem";
            classificationgrammarClassToolStripMenuItem.Size = new Size(428, 34);
            classificationgrammarClassToolStripMenuItem.Text = "Классификация грамматики";
            classificationgrammarClassToolStripMenuItem.Click += classificationgrammarClassToolStripMenuItem_Click;
            // 
            // analysismethodToolStripMenuItem
            // 
            analysismethodToolStripMenuItem.Name = "analysismethodToolStripMenuItem";
            analysismethodToolStripMenuItem.Size = new Size(428, 34);
            analysismethodToolStripMenuItem.Text = "Метод анализа";
            analysismethodToolStripMenuItem.Click += analysismethodToolStripMenuItem_Click;
            // 
            // diagnosticsNeutralizationToolStripMenuItem
            // 
            diagnosticsNeutralizationToolStripMenuItem.Name = "diagnosticsNeutralizationToolStripMenuItem";
            diagnosticsNeutralizationToolStripMenuItem.Size = new Size(428, 34);
            diagnosticsNeutralizationToolStripMenuItem.Text = "Диагностика и нейтрализация ошибок";
            diagnosticsNeutralizationToolStripMenuItem.Click += diagnosticsNeutralizationToolStripMenuItem_Click;
            // 
            // explToolStripMenuItem
            // 
            explToolStripMenuItem.Name = "explToolStripMenuItem";
            explToolStripMenuItem.Size = new Size(428, 34);
            explToolStripMenuItem.Text = "Тестовый пример";
            explToolStripMenuItem.Click += explToolStripMenuItem_Click;
            // 
            // bibliographyToolStripMenuItem
            // 
            bibliographyToolStripMenuItem.Name = "bibliographyToolStripMenuItem";
            bibliographyToolStripMenuItem.Size = new Size(428, 34);
            bibliographyToolStripMenuItem.Text = "Список литературы";
            bibliographyToolStripMenuItem.Click += bibliographyToolStripMenuItem_Click;
            // 
            // sourceCodeToolStripMenuItem
            // 
            sourceCodeToolStripMenuItem.Name = "sourceCodeToolStripMenuItem";
            sourceCodeToolStripMenuItem.Size = new Size(428, 34);
            sourceCodeToolStripMenuItem.Text = "Исходный код программы";
            sourceCodeToolStripMenuItem.Click += sourceCodeToolStripMenuItem_Click;
            // 
            // StartToolStripMenuItem
            // 
            StartToolStripMenuItem.Name = "StartToolStripMenuItem";
            StartToolStripMenuItem.Size = new Size(67, 29);
            StartToolStripMenuItem.Text = "Пуск";
            StartToolStripMenuItem.Click += StartToolStripMenuItem_Click;
            // 
            // refToolStripMenuItem
            // 
            refToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { callHelpToolStripMenuItem, aboutCodeToolStripMenuItem });
            refToolStripMenuItem.Name = "refToolStripMenuItem";
            refToolStripMenuItem.Size = new Size(97, 29);
            refToolStripMenuItem.Text = "Справка";
            // 
            // callHelpToolStripMenuItem
            // 
            callHelpToolStripMenuItem.Name = "callHelpToolStripMenuItem";
            callHelpToolStripMenuItem.Size = new Size(238, 34);
            callHelpToolStripMenuItem.Text = "Вызов справки";
            callHelpToolStripMenuItem.Click += callHelpToolStripMenuItem_Click;
            // 
            // aboutCodeToolStripMenuItem
            // 
            aboutCodeToolStripMenuItem.Name = "aboutCodeToolStripMenuItem";
            aboutCodeToolStripMenuItem.Size = new Size(238, 34);
            aboutCodeToolStripMenuItem.Text = "О программе";
            aboutCodeToolStripMenuItem.Click += aboutCodeToolStripMenuItem_Click;
            // 
            // file
            // 
            file.BackgroundImage = (Image)resources.GetObject("file.BackgroundImage");
            file.BackgroundImageLayout = ImageLayout.Zoom;
            file.Location = new Point(14, 38);
            file.Margin = new Padding(4, 3, 4, 3);
            file.Name = "file";
            file.Size = new Size(96, 87);
            file.TabIndex = 1;
            file.UseVisualStyleBackColor = true;
            file.Click += file_Click;
            // 
            // open
            // 
            open.BackgroundImage = (Image)resources.GetObject("open.BackgroundImage");
            open.BackgroundImageLayout = ImageLayout.Zoom;
            open.Location = new Point(119, 38);
            open.Margin = new Padding(4, 3, 4, 3);
            open.Name = "open";
            open.Size = new Size(96, 87);
            open.TabIndex = 2;
            open.UseVisualStyleBackColor = true;
            open.Click += open_Click;
            // 
            // save
            // 
            save.BackgroundImage = (Image)resources.GetObject("save.BackgroundImage");
            save.BackgroundImageLayout = ImageLayout.Zoom;
            save.Location = new Point(223, 38);
            save.Margin = new Padding(4, 3, 4, 3);
            save.Name = "save";
            save.Size = new Size(96, 87);
            save.TabIndex = 3;
            save.UseVisualStyleBackColor = true;
            save.Click += save_Click;
            // 
            // start
            // 
            start.BackgroundImage = (Image)resources.GetObject("start.BackgroundImage");
            start.BackgroundImageLayout = ImageLayout.Zoom;
            start.Location = new Point(326, 38);
            start.Margin = new Padding(4, 3, 4, 3);
            start.Name = "start";
            start.Size = new Size(96, 87);
            start.TabIndex = 4;
            start.Text = "start";
            start.UseVisualStyleBackColor = true;
            start.Click += start_Click;
            // 
            // undo
            // 
            undo.BackgroundImage = (Image)resources.GetObject("undo.BackgroundImage");
            undo.BackgroundImageLayout = ImageLayout.Zoom;
            undo.Location = new Point(430, 38);
            undo.Margin = new Padding(4, 3, 4, 3);
            undo.Name = "undo";
            undo.Size = new Size(96, 87);
            undo.TabIndex = 5;
            undo.UseVisualStyleBackColor = true;
            undo.Click += undo_Click;
            // 
            // redo
            // 
            redo.BackgroundImage = (Image)resources.GetObject("redo.BackgroundImage");
            redo.BackgroundImageLayout = ImageLayout.Zoom;
            redo.Location = new Point(534, 38);
            redo.Margin = new Padding(4, 3, 4, 3);
            redo.Name = "redo";
            redo.Size = new Size(96, 87);
            redo.TabIndex = 6;
            redo.UseVisualStyleBackColor = true;
            redo.Click += redo_Click;
            // 
            // cut
            // 
            cut.BackgroundImage = (Image)resources.GetObject("cut.BackgroundImage");
            cut.BackgroundImageLayout = ImageLayout.Zoom;
            cut.Location = new Point(637, 38);
            cut.Margin = new Padding(4, 3, 4, 3);
            cut.Name = "cut";
            cut.Size = new Size(96, 87);
            cut.TabIndex = 7;
            cut.UseVisualStyleBackColor = true;
            cut.Click += cut_Click;
            // 
            // paste
            // 
            paste.BackgroundImage = (Image)resources.GetObject("paste.BackgroundImage");
            paste.BackgroundImageLayout = ImageLayout.Zoom;
            paste.Location = new Point(741, 38);
            paste.Margin = new Padding(4, 3, 4, 3);
            paste.Name = "paste";
            paste.Size = new Size(96, 87);
            paste.TabIndex = 8;
            paste.UseVisualStyleBackColor = true;
            paste.Click += paste_Click;
            // 
            // richTextBoxInput
            // 
            richTextBoxInput.Location = new Point(14, 133);
            richTextBoxInput.Margin = new Padding(4, 3, 4, 3);
            richTextBoxInput.Name = "richTextBoxInput";
            richTextBoxInput.Size = new Size(971, 357);
            richTextBoxInput.TabIndex = 9;
            richTextBoxInput.Text = "";
            // 
            // richTextBoxOutput
            // 
            richTextBoxOutput.Location = new Point(14, 545);
            richTextBoxOutput.Margin = new Padding(4, 3, 4, 3);
            richTextBoxOutput.Name = "richTextBoxOutput";
            richTextBoxOutput.ReadOnly = true;
            richTextBoxOutput.Size = new Size(971, 357);
            richTextBoxOutput.TabIndex = 10;
            richTextBoxOutput.Text = "";
            // 
            // copy
            // 
            copy.BackgroundImage = (Image)resources.GetObject("copy.BackgroundImage");
            copy.BackgroundImageLayout = ImageLayout.Zoom;
            copy.Location = new Point(846, 38);
            copy.Margin = new Padding(4, 3, 4, 3);
            copy.Name = "copy";
            copy.Size = new Size(96, 87);
            copy.TabIndex = 11;
            copy.UseVisualStyleBackColor = true;
            copy.Click += copy_Click;
            // 
            // ParserForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1001, 997);
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
            Margin = new Padding(4, 3, 4, 3);
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
        private HelpProvider helpProvider1;
    }
}
