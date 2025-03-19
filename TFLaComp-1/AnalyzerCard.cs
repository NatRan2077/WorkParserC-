using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TFLaComp_1.DTO;

namespace TFLaComp_1
{
    internal class AnalyzerCard
    {
        private readonly List<CardDTO> _cards;


        private static readonly Dictionary<string, string> PaymentSystems = new()
        {
            { "4", "Visa" },
            { "5", "MasterCard" },
            { "6", "UnionPay" },
            { "22", "Мир" }
        };

        private static readonly Dictionary<string, string> BankCodes = new()
        {
            { "4276", "Сбербанк" },
            { "5469", "Альфа-Банк" },
            { "5213", "Тинькофф Банк" },
            { "4000", "Bank of America" },
            { "3762", "American Express Bank" }
        };


        public AnalyzerCard(List<CardDTO> cards) 
        {
            _cards = cards;
        }

        private string GetPaymentSystem(CardDTO card)
        {
            string paymentSystemId = card.NumberCard.Substring(0, 1);
            if (PaymentSystems.ContainsKey(paymentSystemId))
            {
                return PaymentSystems[paymentSystemId];
            }
            else
                return "Неизвестная платежная система";
        }

        private string GetBankCode(CardDTO card)
        {
            string bin = card.NumberCard.Substring(0, 4); // Первые 6 цифр — BIN
            
            if(BankCodes.ContainsKey(bin))
            {
                return BankCodes[bin];
            }
            else
                return "Неизвестный банк";
        }

        public List<FullCardDTO> Analyze()
        {

            List<FullCardDTO> fullCards = new List<FullCardDTO>();

            foreach (CardDTO card in _cards) 
            {
                FullCardDTO fullCardDTO = new FullCardDTO(card, GetPaymentSystem(card), GetBankCode(card));
                fullCards.Add(fullCardDTO);
            }

            return fullCards;
        }

    }
}
