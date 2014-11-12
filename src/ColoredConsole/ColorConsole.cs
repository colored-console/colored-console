// <copyright file="ColorConsole.cs" company="ColoredConsole contributors">
//  Copyright (c) ColoredConsole contributors. (coloredconsole@gmail.com)
// </copyright>

namespace ColoredConsole
{
    using System;

    public static class ColorConsole
    {
        private static readonly object @lock = new object();

        public static void Write(ColorToken[] tokens)
        {
            Guard.AgainstNullArgument("tokens", tokens);

            lock (@lock)
            {
                foreach (var token in tokens)
                {
                    if (token.Color.HasValue || token.BackgroundColor.HasValue)
                    {
                        var originalColor = Console.ForegroundColor;
                        var originalBackgroundColor = Console.BackgroundColor;
                        try
                        {
                            Console.ForegroundColor = token.Color ?? originalColor;
                            Console.BackgroundColor = token.BackgroundColor ?? originalBackgroundColor;
                            Console.Write(token);
                        }
                        finally
                        {
                            Console.ForegroundColor = originalColor;
                            Console.BackgroundColor = originalBackgroundColor;
                        }
                    }
                    else
                    {
                        Console.Write(token);
                    }
                }
            }
        }

        public static void WriteLine(params ColorToken[] tokens)
        {
            lock (@lock)
            {
                Write(tokens);
                Console.WriteLine();
            }
        }
    }
}
