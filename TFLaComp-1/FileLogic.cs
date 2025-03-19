using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TFLaComp_1
{
    public class FileLogic : IFileLogic
    {
        private string currentFilePath = string.Empty;

        private RichTextBox _richTextBoxOutput;

        private string _logFilePath = "log.txt";

        public void Create(ref string text)
        {
            text = string.Empty;
            currentFilePath = string.Empty;
        }


        public string Open()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    currentFilePath = openFileDialog.FileName;
                    //try
                    //{
                        return File.ReadAllText(currentFilePath);
                    //}
                    //catch (Exception ex)
                    //{
                    //    new Exception("Ошибка при чтении файла", ex);
                    //}
                }
            }
            return null;
        }

        public void Save(string text)
        {
            if (string.IsNullOrEmpty(currentFilePath))
            {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        currentFilePath = saveFileDialog.FileName;
                        File.WriteAllText(currentFilePath, text);
                    }
                }
            }
            else
            {
                File.WriteAllText(currentFilePath, text);
            }
        }

        public void SaveAs(string text)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    currentFilePath = saveFileDialog.FileName;
                    File.WriteAllText(currentFilePath, text);
                }
            }
        }

        public void Close()
        {
            //Application.Exit();
        }

        public void WriteToLog()
        {
            try
            {
                string logEntry = $"{DateTime.Now}: {_richTextBoxOutput.Text}{Environment.NewLine}";
                File.AppendAllText(_logFilePath, logEntry);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при записи в лог-файл: {ex.Message}");
            }
        }

        public void LogCurrentText(string filename)
        {
            try
            {
                string logEntry = $"{DateTime.Now}: {_richTextBoxOutput.Text}{Environment.NewLine}";
                File.AppendAllText(filename, logEntry);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при записи в лог-файл: {ex.Message}");
            }
        }
    }
}
