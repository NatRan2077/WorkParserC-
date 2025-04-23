using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFLaComp_1.CardParser.Interface
{
    public interface ITokenizer
    {
        List<string> Tokens { get; }
        IEnumerable<ISyntaxError> Errors { get; }
    }
}
