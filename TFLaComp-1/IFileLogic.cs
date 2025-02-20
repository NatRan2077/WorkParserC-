using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFLaComp_1
{
    public interface IFileLogic
    {
        void Create(string text);
        void Save(string text);
        void SaveAs(string text);
        void Open();
        void Close();
    }
}
