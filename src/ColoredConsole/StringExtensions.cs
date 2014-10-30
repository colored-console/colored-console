// <copyright file="StringExtensions.cs" company="ColoredConsole contributors">
//  Copyright (c) ColoredConsole contributors. (coloredconsole@gmail.com)
// </copyright>

namespace ColoredConsole
{
    using System;

    /// <summary>
    /// Convenience extension methods for colorizing strings.
    /// </summary>
    public static class StringExtensions
    {
        public static ColorToken Colored(this string text, ConsoleColor? color = null)
        {
            return new ColorToken(text, color);
        }

        public static ColorToken Black(this string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return null;
            }

            return text.Colored(ConsoleColor.Black);
        }

        public static ColorToken Blue(this string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return null;
            }

            return text.Colored(ConsoleColor.Blue);
        }

        public static ColorToken Cyan(this string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return null;
            }

            return text.Colored(ConsoleColor.Cyan);
        }

        public static ColorToken DarkBlue(this string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return null;
            }

            return text.Colored(ConsoleColor.DarkBlue);
        }

        public static ColorToken DarkCyan(this string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return null;
            }

            return text.Colored(ConsoleColor.DarkCyan);
        }

        public static ColorToken DarkGray(this string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return null;
            }

            return text.Colored(ConsoleColor.DarkGray);
        }

        public static ColorToken DarkGreen(this string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return null;
            }

            return text.Colored(ConsoleColor.DarkGreen);
        }

        public static ColorToken DarkMagenta(this string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return null;
            }

            return text.Colored(ConsoleColor.DarkMagenta);
        }

        public static ColorToken DarkRed(this string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return null;
            }

            return text.Colored(ConsoleColor.DarkRed);
        }

        public static ColorToken DarkYellow(this string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return null;
            }

            return text.Colored(ConsoleColor.DarkYellow);
        }

        public static ColorToken Gray(this string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return null;
            }

            return text.Colored(ConsoleColor.Gray);
        }

        public static ColorToken Green(this string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return null;
            }

            return text.Colored(ConsoleColor.Green);
        }

        public static ColorToken Magenta(this string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return null;
            }

            return text.Colored(ConsoleColor.Magenta);
        }

        public static ColorToken Red(this string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return null;
            }

            return text.Colored(ConsoleColor.Red);
        }

        public static ColorToken White(this string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return null;
            }

            return text.Colored(ConsoleColor.White);
        }

        public static ColorToken Yellow(this string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return null;
            }

            return text.Colored(ConsoleColor.Yellow);
        }
    }
}
