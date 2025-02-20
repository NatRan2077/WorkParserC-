using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFLaComp_1
{
    public class FileLogic : IFileLogic
    {
        private string currentFilePath = string.Empty;

        public void Create(string text)
        {
            text = string.Empty;
            currentFilePath = string.Empty;
        }


        public void Open()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    currentFilePath = openFileDialog.FileName;
                }
            }
        }

        public void Save(string text)
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
            Application.Exit();
        }
    }
}
