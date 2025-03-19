using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFLaComp_1.DTO
{
    public class CardDTO
    {
        public string NumberCard { get; set; }
        public int IndexStart { get; set; }
        public int IndexEnd { get; set; }
        public CardDTO(string numberCard, int start, int end)
        {
            NumberCard = numberCard;
            IndexStart = start;
            IndexEnd = end;
        }
    }
}
