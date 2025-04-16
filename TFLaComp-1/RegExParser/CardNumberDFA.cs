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
                ProcessChar(c, i);
            }

            if (currentState == State.Digit && digitCount == 16)
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

        private void ProcessChar(char c, int index)
        {
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
                        currentDigits.Append(c);
                        digitCount++;
                        if (digitCount == 16)
                        {
                            foundCards.Add(new CardDTO(currentDigits.ToString(), startIndex, index));
                            currentState = State.Start;
                            digitCount = 0;
                            currentDigits.Clear();
                            startIndex = -1;
                        }
                    }
                    else if (c == ' ' || c == '-')
                    {
                        currentState = State.Separator;
                    }
                    else
                    {
                        currentState = State.Start;
                        digitCount = 0;
                        currentDigits.Clear();
                        startIndex = -1;
                    }
                    break;

                case State.Separator:
                    if (char.IsDigit(c))
                    {
                        currentDigits.Append(c);
                        digitCount++;
                        if (digitCount == 16)
                        {
                            foundCards.Add(new CardDTO(currentDigits.ToString(), startIndex, index));
                            currentState = State.Start;
                            digitCount = 0;
                            currentDigits.Clear();
                            startIndex = -1;
                        }
                        else
                        {
                            currentState = State.Digit;
                        }
                    }
                    else
                    {
                        currentState = State.Start;
                        digitCount = 0;
                        currentDigits.Clear();
                        startIndex = -1;
                    }
                    break;
            }
        }
    }
}
