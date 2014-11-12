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

        [SuppressMessage(
            "Microsoft.Naming",
            "CA1719:ParameterNamesShouldNotMatchMemberNames",
            MessageId = "1#",
            Justification = "By design.")]
        public static ColorToken Color(this ColorToken token, ConsoleColor? color)
        {
            return new ColorToken(token.Text, color, token.BackgroundColor);
        }

        public static ColorToken Black(this ColorToken token)
        {
            return token.Color(ConsoleColor.Black);
        }

        public static ColorToken Blue(this ColorToken token)
        {
            return token.Color(ConsoleColor.Blue);
        }

        public static ColorToken Cyan(this ColorToken token)
        {
            return token.Color(ConsoleColor.Cyan);
        }

        public static ColorToken DarkBlue(this ColorToken token)
        {
            return token.Color(ConsoleColor.DarkBlue);
        }

        public static ColorToken DarkCyan(this ColorToken token)
        {
            return token.Color(ConsoleColor.DarkCyan);
        }

        public static ColorToken DarkGray(this ColorToken token)
        {
            return token.Color(ConsoleColor.DarkGray);
        }

        public static ColorToken DarkGreen(this ColorToken token)
        {
            return token.Color(ConsoleColor.DarkGreen);
        }

        public static ColorToken DarkMagenta(this ColorToken token)
        {
            return token.Color(ConsoleColor.DarkMagenta);
        }

        public static ColorToken DarkRed(this ColorToken token)
        {
            return token.Color(ConsoleColor.DarkRed);
        }

        public static ColorToken DarkYellow(this ColorToken token)
        {
            return token.Color(ConsoleColor.DarkYellow);
        }

        public static ColorToken Gray(this ColorToken token)
        {
            return token.Color(ConsoleColor.Gray);
        }

        public static ColorToken Green(this ColorToken token)
        {
            return token.Color(ConsoleColor.Green);
        }

        public static ColorToken Magenta(this ColorToken token)
        {
            return token.Color(ConsoleColor.Magenta);
        }

        public static ColorToken Red(this ColorToken token)
        {
            return token.Color(ConsoleColor.Red);
        }

        public static ColorToken White(this ColorToken token)
        {
            return token.Color(ConsoleColor.White);
        }

        public static ColorToken Yellow(this ColorToken token)
        {
            return token.Color(ConsoleColor.Yellow);
        }
    }
}
