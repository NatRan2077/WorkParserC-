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

        private string _previousText = "";

        public Edit(RichTextBox richTextBox)
        {
            _richTextBox = richTextBox;

            _undoStack = new Stack<string>();
            _redoStack = new Stack<string>();

            _content = new StringBuilder(_richTextBox.Text);

            SaveStateForUndo();

            _previousText = _content.ToString();
        }

        public void Insert(string text)
        {
            SaveStateForUndo();

            _content.Insert(_selectionStart, text);

            ContinuePosition(_selectionStart, text.Length);
        }

        public void Delete()
        {
            SetSelection(_richTextBox.SelectionStart, _richTextBox.SelectedText.Length);

            if (_selectionLength > 0)
            {
                SaveStateForUndo();

                _content.Remove(_selectionStart, _selectionLength);
                _richTextBox.Text = _content.ToString();

                ContinuePosition(_selectionStart, _selectionLength);
            }
        }

        public void Cut()
        {
            SetSelection(_richTextBox.SelectionStart, _richTextBox.SelectedText.Length);

            if (_selectionLength > 0)
            {
                SaveStateForUndo();

                _clipboard = _content.ToString(_selectionStart, _selectionLength);
                Clipboard.SetText(_clipboard);

                _content.Remove(_selectionStart, _selectionLength);
                _richTextBox.Text = _content.ToString();

                SetSelection(_selectionStart, 0);

                if (_selectionStart > _content.Length)
                {
                    ContinuePosition(_content.Length - 1, 0);
                }
                else
                {
                    ContinuePosition(_selectionStart, 0);
                }
            }
        }

        public void Copy()
        {
            SetSelection(_richTextBox.SelectionStart, _richTextBox.SelectedText.Length);

            if (_selectionLength > 0)
            {
                _clipboard = _content.ToString(_selectionStart, _selectionLength);
                Clipboard.SetText(_clipboard);
            }
        }

        public void Paste()
        {
            SetSelection(_richTextBox.SelectionStart, _richTextBox.SelectedText.Length);

            _clipboard = Clipboard.GetText();

            if (!string.IsNullOrEmpty(_clipboard))
            {
                SaveStateForUndo();

                if (_selectionLength > 0)
                {
                    _content.Remove(_selectionStart, _selectionLength);
                }

                _content.Insert(_selectionStart, _clipboard);
                _richTextBox.Text = _content.ToString();

                ContinuePosition(_selectionStart, _clipboard.Length);
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

            _richTextBox.SelectAll();
        }

        public void SetSelection(int start, int length)
        {
            _selectionStart = start;
            _selectionLength = length;
        }

        public void SaveStateForUndo(string textToSave)
        {
            if (_undoStack.TryPeek(out string? peek))
            {
                if (textToSave == peek) return;
            }

            _undoStack.Push(textToSave);
        }

        public void SaveStateForUndo()
        {
            if (_undoStack.TryPeek(out string? peek))
            {
                if (_content.ToString() == peek) return;
            }

            _undoStack.Push(_content.ToString());
        }

        private void ContinuePosition(int start, int lenght)
        {
            _richTextBox.SelectionStart = start + lenght;
        }

        public void SetContent()
        {
            _content = new StringBuilder(_richTextBox.Text);
        }

        public void DetectTextChange()
        {
            if (_previousText == _content.ToString()) return;

            int minLen = Math.Min(_previousText.Length, _content.Length);

            for (int i = 0; i < minLen; i++)
            {
                if (_previousText[i] != _content[i])
                {
                    SaveStateForUndo(_previousText);
                    break;
                }
            }

            _previousText = _content.ToString();
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
