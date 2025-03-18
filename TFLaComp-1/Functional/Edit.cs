using System.Reflection.Metadata;

namespace TFLaComp_1.Functional
{
    public class Edit : IEdit
    {
        private RichTextBox _richTextBox;

        private Stack<string> _undoText;

        private Stack<string> _redoText;

        private string _copiedText;

        private string _logFilePath = "log.txt";

        public Edit(RichTextBox richTextBox)
        {
            _richTextBox = richTextBox;

            _undoText = new Stack<string>();
            _redoText = new Stack<string>();

            _copiedText = string.Empty;

            SaveUndo();
        }

        public void Undo()
        {
            if (_undoText.Count <= 0) return;

            _redoText.Push(_richTextBox.Text);
            _richTextBox.Text = _undoText.Pop();
        }

        public void Redo()
        {
            if (_redoText.Count <= 0) return;

            string text = _redoText.Pop();

            SaveUndo();

            _richTextBox.Text = text;
        }

        public void Cut()
        {
            string selectedText = _richTextBox.SelectedText;

            if (string.IsNullOrEmpty(selectedText)) return;

            int selectionStart = _richTextBox.SelectionStart;

            Clipboard.SetText(selectedText, TextDataFormat.Text);

            _copiedText = selectedText;
            
            string text = _richTextBox.Text.Remove(_richTextBox.SelectionStart, _copiedText.Length);

            SaveUndo();

            _richTextBox.Text = text;

            _richTextBox.SelectionStart = selectionStart;
        }

        public void Copy()
        {
            string selectedText = _richTextBox.SelectedText;
            if (string.IsNullOrEmpty(selectedText)) return;

            Clipboard.SetText(selectedText, TextDataFormat.Text);

            _copiedText = selectedText;
        }

        public void Paste()
        {
            _copiedText = Clipboard.GetText(TextDataFormat.Text);

            if (string.IsNullOrEmpty(_copiedText)) return;

            int selectionStart = _richTextBox.SelectionStart + _copiedText.Length;

            string text = _richTextBox.Text.Insert(_richTextBox.SelectionStart, _copiedText);

            SaveUndo();

            _richTextBox.Text = text;

            _richTextBox.SelectionStart = selectionStart;
        }

        public void Delete()
        {
            string selectedText = _richTextBox.SelectedText;

            if (string.IsNullOrEmpty(selectedText)) return;

            string text = _richTextBox.Text.Remove(_richTextBox.SelectionStart, selectedText.Length);

            SaveUndo();

            _richTextBox.Text = text;
        }

        public void SelectAll()
        {
            _richTextBox.SelectAll();
        }

        public void SaveUndo()
        {
            string? peek;

            if (_undoText.TryPeek(out peek))
            {
                if (_richTextBox.Text == peek) return;
            }

            _undoText.Push(_richTextBox.Text);
        }



        public void LogCurrentText(string filename)
        {
            try
            {
                string logEntry = $"{DateTime.Now}: {_richTextBox.Text}{Environment.NewLine}";
                File.AppendAllText(filename, logEntry);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при записи в лог-файл: {ex.Message}");
            }
        }
    }
}
