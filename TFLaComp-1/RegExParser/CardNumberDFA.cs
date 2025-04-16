using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFLaComp_1.DTO; // подключаем DTO

namespace TFLaComp_1.RegExParser
{
    public class CardNumberDFA
    {
        private enum State
        {
            Start,
            Digit,
            Separator
        }

        private State currentState;
        private int digitCount;
        private int startIndex;
        private StringBuilder currentDigits;
        private List<CardDTO> foundCards;

        public CardNumberDFA()
        {
            currentState = State.Start;
            digitCount = 0;
            startIndex = -1;
            currentDigits = new StringBuilder();
            foundCards = new List<CardDTO>();
        }

        public List<CardDTO> Run(string input)
        {
            Reset();

            for (int i = 0; i < input.Length; i++)
            {
                char c = input[i];
                ProcessChar(c, i, input);
            }

            if (digitCount == 16)
            {
                foundCards.Add(new CardDTO(currentDigits.ToString(), startIndex, input.Length - 1));
            }

            return foundCards;
        }

        private void Reset()
        {
            currentState = State.Start;
            digitCount = 0;
            currentDigits.Clear();
            foundCards.Clear();
            startIndex = -1;
        }

        private void ResetPartial()
        {
            currentState = State.Start;
            digitCount = 0;
            currentDigits.Clear();
            startIndex = -1;
        }

        private void ProcessChar(char c, int index, string input)
        {
            bool isSeparator = c == ' ' || c == '-' || c == '_';

            switch (currentState)
            {
                case State.Start:
                    if (char.IsDigit(c))
                    {
                        currentDigits.Clear();
                        currentDigits.Append(c);
                        digitCount = 1;
                        startIndex = index;
                        currentState = State.Digit;
                    }
                    break;

                case State.Digit:
                    if (char.IsDigit(c))
                    {
                        if (digitCount < 16)
                        {
                            currentDigits.Append(c);
                            digitCount++;
                        }
                        else
                        {
                            ResetPartial();
                            return;
                        }

                        if (digitCount == 16)
                        {
                            if (index + 1 < input.Length && char.IsDigit(input[index + 1]))
                            {
                                ResetPartial();
                            }
                            else
                            {
                                foundCards.Add(new CardDTO(currentDigits.ToString(), startIndex, index));
                                ResetPartial();
                            }
                        }
                    }
                    else if (isSeparator)
                    {
                        currentState = State.Separator;
                    }
                    else
                    {
                        ResetPartial();
                    }
                    break;

                case State.Separator:
                    if (char.IsDigit(c))
                    {
                        if (digitCount < 16)
                        {
                            currentDigits.Append(c);
                            digitCount++;
                            currentState = State.Digit;

                            if (digitCount == 16)
                            {
                                if (index + 1 < input.Length && char.IsDigit(input[index + 1]))
                                {
                                    ResetPartial();
                                }
                                else
                                {
                                    foundCards.Add(new CardDTO(currentDigits.ToString(), startIndex, index));
                                    ResetPartial();
                                }
                            }
                        }
                        else
                        {
                            ResetPartial();
                        }
                    }
                    else
                    {
                        ResetPartial();
                    }
                    break;
            }
        }
    }
}
