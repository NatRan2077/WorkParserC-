namespace TFLaComp_1.Functional
{
    public class Edit : IEdit
    {
        private RichTextBox _richTextBox;

        private Stack<string> _undoText;

        private Stack<string> _redoText;

        private string _copiedText;

        public Edit(RichTextBox richTextBox)
        {
            _richTextBox = richTextBox;

            _undoText = new Stack<string>();
            _redoText = new Stack<string>();

            _undoText.Push(_richTextBox.Text);
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

            _undoText.Push(_richTextBox.Text);
            _undoText.Push(text);
            _richTextBox.Text = text;
        }

        public void Cut()
        {
            string selectedText = _richTextBox.SelectedText;

            if (selectedText.Length <= 0) return;

            int selectionStart = _richTextBox.SelectionStart;

            _copiedText = selectedText;
            
            string text = _richTextBox.Text.Remove(_richTextBox.SelectionStart, _copiedText.Length);

            _undoText.Push(_richTextBox.Text);

            _richTextBox.Text = text;

            _richTextBox.SelectionStart = selectionStart;
        }

        public void Copy()
        {
            string selectedText = _richTextBox.SelectedText;
            if (selectedText.Length <= 0) return;

            _copiedText = selectedText;
        }

        public void Paste()
        {
            if (_copiedText.Length <= 0) return;

            int selectionStart = _richTextBox.SelectionStart + _copiedText.Length;
            string text = _richTextBox.Text.Insert(_richTextBox.SelectionStart, _copiedText);

            _undoText.Push(_richTextBox.Text);

            _richTextBox.Text = text;

            _richTextBox.SelectionStart = selectionStart;
        }

        public void Delete()
        {
            string selectedText = _richTextBox.SelectedText;
            if (selectedText.Length <= 0) return;

            string text = _richTextBox.Text.Remove(_richTextBox.SelectionStart, selectedText.Length);

            _undoText.Push(_richTextBox.Text);

            _richTextBox.Text = text;
        }

        public void SelectAll()
        {
            _richTextBox.SelectAll();
        }
    }
}
