// <copyright file="ColorTokenExtensions.cs" company="ColoredConsole contributors">
//  Copyright (c) ColoredConsole contributors. (coloredconsole@gmail.com)
// </copyright>

namespace ColoredConsole
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

    /// <summary>
    /// Convenience extension methods for setting background colors.
    /// </summary>
    public static class ColorTokenExtensions
    {
        public static ColorToken[] Coalesce(this IEnumerable<ColorToken> tokens, ConsoleColor color)
        {
            return tokens.Coalesce(color, null);
        }

        public static ColorToken[] Coalesce(this IEnumerable<ColorToken> tokens, ConsoleColor? color, ConsoleColor? backgroundColor)
        {
            Guard.AgainstNullArgument("tokens", tokens);

            return tokens.Select(token => token.Coalesce(color, backgroundColor)).ToArray();
        }

        [SuppressMessage(
            "Microsoft.Naming",
            "CA1719:ParameterNamesShouldNotMatchMemberNames",
            MessageId = "1#",
            Justification = "By design.")]
        public static ColorToken BackgroundColor(this ColorToken token, ConsoleColor? backgroundColor)
        {
            return new ColorToken(token.Text, token.Color, backgroundColor);
        }

        public static ColorToken BlackBackground(this ColorToken token)
        {
            return token.BackgroundColor(ConsoleColor.Black);
        }

        public static ColorToken BlueBackground(this ColorToken token)
        {
            return token.BackgroundColor(ConsoleColor.Blue);
        }

        public static ColorToken CyanBackground(this ColorToken token)
        {
            return token.BackgroundColor(ConsoleColor.Cyan);
        }

        public static ColorToken DarkBlueBackground(this ColorToken token)
        {
            return token.BackgroundColor(ConsoleColor.DarkBlue);
        }

        public static ColorToken DarkCyanBackground(this ColorToken token)
        {
            return token.BackgroundColor(ConsoleColor.DarkCyan);
        }

        public static ColorToken DarkGrayBackground(this ColorToken token)
        {
            return token.BackgroundColor(ConsoleColor.DarkGray);
        }

        public static ColorToken DarkGreenBackground(this ColorToken token)
        {
            return token.BackgroundColor(ConsoleColor.DarkGreen);
        }

        public static ColorToken DarkMagentaBackground(this ColorToken token)
        {
            return token.BackgroundColor(ConsoleColor.DarkMagenta);
        }

        public static ColorToken DarkRedBackground(this ColorToken token)
        {
            return token.BackgroundColor(ConsoleColor.DarkRed);
        }

        public static ColorToken DarkYellowBackground(this ColorToken token)
        {
            return token.BackgroundColor(ConsoleColor.DarkYellow);
        }

        public static ColorToken GrayBackground(this ColorToken token)
        {
            return token.BackgroundColor(ConsoleColor.Gray);
        }

        public static ColorToken GreenBackground(this ColorToken token)
        {
            return token.BackgroundColor(ConsoleColor.Green);
        }

        public static ColorToken MagentaBackground(this ColorToken token)
        {
            return token.BackgroundColor(ConsoleColor.Magenta);
        }

        public static ColorToken RedBackground(this ColorToken token)
        {
            return token.BackgroundColor(ConsoleColor.Red);
        }

        public static ColorToken WhiteBackground(this ColorToken token)
        {
            return token.BackgroundColor(ConsoleColor.White);
        }

        public static ColorToken YellowBackground(this ColorToken token)
        {
            return token.BackgroundColor(ConsoleColor.Yellow);
        }
    }
}
