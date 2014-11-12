// <copyright file="ColorTokenExtensions.cs" company="ColoredConsole contributors">
//  Copyright (c) ColoredConsole contributors. (coloredconsole@gmail.com)
// </copyright>

namespace ColoredConsole
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Convenience extension methods for setting background colors.
    /// </summary>
    public static class ColorTokenExtensions
    {
        [SuppressMessage(
            "Microsoft.Naming",
            "CA1719:ParameterNamesShouldNotMatchMemberNames",
            MessageId = "1#",
            Justification = "By design.")]
        public static ColorToken On(this ColorToken token, ConsoleColor? backgroundColor)
        {
            return new ColorToken(token.Text, token.Color, backgroundColor);
        }

        public static ColorToken OnBlack(this ColorToken token)
        {
            return token.On(ConsoleColor.Black);
        }

        public static ColorToken OnBlue(this ColorToken token)
        {
            return token.On(ConsoleColor.Blue);
        }

        public static ColorToken OnCyan(this ColorToken token)
        {
            return token.On(ConsoleColor.Cyan);
        }

        public static ColorToken OnDarkBlue(this ColorToken token)
        {
            return token.On(ConsoleColor.DarkBlue);
        }

        public static ColorToken OnDarkCyan(this ColorToken token)
        {
            return token.On(ConsoleColor.DarkCyan);
        }

        public static ColorToken OnDarkGray(this ColorToken token)
        {
            return token.On(ConsoleColor.DarkGray);
        }

        public static ColorToken OnDarkGreen(this ColorToken token)
        {
            return token.On(ConsoleColor.DarkGreen);
        }

        public static ColorToken OnDarkMagenta(this ColorToken token)
        {
            return token.On(ConsoleColor.DarkMagenta);
        }

        public static ColorToken OnDarkRed(this ColorToken token)
        {
            return token.On(ConsoleColor.DarkRed);
        }

        public static ColorToken OnDarkYellow(this ColorToken token)
        {
            return token.On(ConsoleColor.DarkYellow);
        }

        public static ColorToken OnGray(this ColorToken token)
        {
            return token.On(ConsoleColor.Gray);
        }

        public static ColorToken OnGreen(this ColorToken token)
        {
            return token.On(ConsoleColor.Green);
        }

        public static ColorToken OnMagenta(this ColorToken token)
        {
            return token.On(ConsoleColor.Magenta);
        }

        public static ColorToken OnRed(this ColorToken token)
        {
            return token.On(ConsoleColor.Red);
        }

        public static ColorToken OnWhite(this ColorToken token)
        {
            return token.On(ConsoleColor.White);
        }

        public static ColorToken OnYellow(this ColorToken token)
        {
            return token.On(ConsoleColor.Yellow);
        }
    }
}
