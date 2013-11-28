// <copyright file="ColorConsole.cs" company="ColoredConsole contributors">
//  Copyright (c) ColoredConsole contributors. (coloredconsole@gmail.com)
// </copyright>

namespace ColoredConsole
{
    using System;

    public static class ColorConsole
    {
        private static readonly object @lock = new object();

        public static void WriteLine(ColorText text)
        {
            lock (@lock)
            {
                foreach (var token in text.ToTokenArray())
                {
                    if (token.Color.HasValue)
                    {
                        var originalColor = Console.ForegroundColor;
                        Console.ForegroundColor = token.Color.Value;
                        try
                        {
                            Console.Write(token);
                        }
                        finally
                        {
                            Console.ForegroundColor = originalColor;
                        }
                    }
                    else
                    {
                        Console.Write(token);
                    }
                }

                Console.WriteLine();
            }
        }
    }
}
