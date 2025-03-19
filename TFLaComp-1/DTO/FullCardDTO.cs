using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFLaComp_1.DTO
{
    public class FullCardDTO
    {
        private readonly CardDTO _card;

        public string PaymentSystem { get; private set; }
        public string Bank { get; private set; }

        public FullCardDTO(CardDTO card, string paymentSystem, string bank)
        {
            _card = card;
            PaymentSystem = paymentSystem;
            Bank = bank;
        }




    }
}
