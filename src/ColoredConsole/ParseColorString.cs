// ColoredConsole - Copyright (c) 2017 CaptiveAire

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ColoredConsole
{
    public class ParseColorString
    {
        public ParseColorString(char tokenDelimiter = '@')
        {
            this.TokenDelimiter = tokenDelimiter;
        }

        public char TokenDelimiter { get; }

        IEnumerable<ColorCharacter> ParseAsCharacters(string input, ConsoleColor currentColor)
        {
            bool inColor = false;

            var token = new StringBuilder();

            foreach (var c in input)
            {
                if (inColor)
                {
                    if (c == this.TokenDelimiter)
                    {
                        if (token.Length == 0)
                        {
                            yield return new ColorCharacter(this.TokenDelimiter, currentColor);

                            inColor = false;
                        }
                        else
                        {
                            // end...
                            ConsoleColor value;
                            if (Enum.TryParse(token.ToString(), true, out value))
                            {
                                currentColor = value;
                            }

                            inColor = false;
                        }
                    }
                    else
                    {
                        token.Append(c);
                    }
                }
                else if (c == this.TokenDelimiter)
                {
                    inColor = true;
                    token.Clear();
                }
                else
                {
                    yield return new ColorCharacter(c, currentColor);
                }
            }
        }

        public IEnumerable<ColorToken> Parse(string input, ConsoleColor? initialForegroundColor = null)
        {
            if (string.IsNullOrEmpty(input))
                yield break;

            ConsoleColor currentColor = initialForegroundColor ?? Console.ForegroundColor;

            var characterArray = this.ParseAsCharacters(input, currentColor).ToList();
            var buffer = new List<ColorCharacter>();

            // tokenize...
            foreach (var c in characterArray)
            {
                if (c.ForegroundColor != currentColor)
                {
                    if (buffer.Any())
                    {
                        yield return new ColorToken(new string(buffer.Select(s => s.Value).ToArray()), currentColor);

                        buffer.Clear();
                    }

                    currentColor = c.ForegroundColor;
                }

                buffer.Add(c);
            }

            if (buffer.Any())
            {
                yield return new ColorToken(new string(buffer.Select(s => s.Value).ToArray()), currentColor);
            }
        }

        internal class ColorCharacter
        {
            internal ColorCharacter(char value, ConsoleColor foregroundColor)
            {
                this.Value = value;
                this.ForegroundColor = foregroundColor;
            }

            public char Value { get; set; }
            public ConsoleColor ForegroundColor { get; set; }
        }
    }
}