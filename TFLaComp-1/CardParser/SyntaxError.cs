﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFLaComp_1.CardParser.Interface;

namespace TFLaComp_1.CardParser
{
    public class SyntaxError : ISyntaxError
    {
        public int Position { get; }
        public string Message { get; }
        public ErrorType Type { get; }

        public SyntaxError(int position, string message, ErrorType type = ErrorType.Syntax)
        {
            Position = position;
            Message = message;
            Type = type;
        }

        public override string ToString()
        {
            return $"[позиция {Position}] {Message}";
        }
    }
}