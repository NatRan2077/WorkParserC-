using System.Text;

namespace TFLaComp_1.Functional
{
    public class Edit : IEdit
    {
        private RichTextBox _richTextBox;

        private StringBuilder _content;
        private Stack<string> _undoStack;
        private Stack<string> _redoStack;
        private string _clipboard = "";
        private int _selectionStart = 0;
        private int _selectionLength = 0;

        public Edit(RichTextBox richTextBox)
        {
            _richTextBox = richTextBox;

            _undoStack = new Stack<string>();
            _redoStack = new Stack<string>();

            _content = new StringBuilder(_richTextBox.Text);

            _undoStack.Push(_content.ToString());
        }

        public void Insert(string text)
        {
            SaveStateForUndo();
            _content.Insert(_selectionStart, text);
            ContinuePosition();
        }

        public void Delete()
        {
            if (_selectionLength > 0)
            {
                SaveStateForUndo();
                _content.Remove(_selectionStart, _selectionLength);
                _richTextBox.Text = _content.ToString();
                ContinuePosition();
            }
        }

        public void Cut()
        {
            if (_selectionLength == 0)
            {
                SetSelection(_richTextBox.SelectionStart, _richTextBox.SelectedText.Length);
            }

            if (_selectionLength > 0)
            {
                SaveStateForUndo();
                _clipboard = _content.ToString(_selectionStart, _selectionLength);
                _content.Remove(_selectionStart, _selectionLength);
                _richTextBox.Text = _content.ToString();
                ContinuePosition();
            }
        }

        public void Copy()
        {
            if (_selectionLength == 0)
            {
                SetSelection(_richTextBox.SelectionStart, _richTextBox.SelectedText.Length);
            }

            if (_selectionLength > 0)
            {
                _clipboard = _content.ToString(_selectionStart, _selectionLength);
            }
        }

        public void Paste()
        {
            SetSelection(_richTextBox.SelectionStart, _richTextBox.SelectedText.Length);

            if (!string.IsNullOrEmpty(_clipboard))
            {
                SaveStateForUndo();
                _content.Insert(_selectionStart, _clipboard);
                _richTextBox.Text = _content.ToString();
                ContinuePosition();
            }
        }

        public void Undo()
        {
            if (_undoStack.Count > 0)
            {
                _redoStack.Push(_content.ToString());
                _content = new StringBuilder(_undoStack.Pop());
                _richTextBox.Text = _content.ToString();
            }
        }

        public void Redo()
        {
            if (_redoStack.Count > 0)
            {
                SaveStateForUndo();
                _content = new StringBuilder(_redoStack.Pop());
                _richTextBox.Text = _content.ToString();
                SaveStateForUndo();
            }
        }

        public void SelectAll()
        {
            _selectionStart = 0;
            _selectionLength = _content.Length;
        }

        public void SetSelection(int start, int length)
        {
            _selectionStart = start;
            _selectionLength = length;
        }

        public void SaveStateForUndo()
        {
            if (_undoStack.TryPeek(out string? peek))
            {
                if (_richTextBox.Text == peek) return;
            }

            _undoStack.Push(_content.ToString());
        }

        private void ContinuePosition()
        {
            _richTextBox.SelectionStart = _selectionStart + _selectionLength;
        }

        public void SetContent()
        {
            _content = new StringBuilder(_richTextBox.Text);
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
