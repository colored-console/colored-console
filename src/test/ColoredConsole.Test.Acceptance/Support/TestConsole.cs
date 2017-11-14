// <copyright file="TestConsole.cs" company="ColoredConsole contributors">
//  Copyright (c) ColoredConsole contributors. (coloredconsole@gmail.com)
// </copyright>

[assembly: Xunit.CollectionBehavior(DisableTestParallelization = true)]
namespace ColoredConsole.Test.Acceptance.Support
{
    using System;
    using System.Collections.Generic;
    using ColoredConsole;

    public sealed class TestConsole : IConsole, IDisposable
    {
        private readonly IConsole originalConsole;
        private readonly ConsoleColor initialForegroundColor;
        private readonly ConsoleColor initialBackgroundColor;
        private readonly List<ColorToken> tokens = new List<ColorToken>();

        public TestConsole(ConsoleColor initialForegroundColor, ConsoleColor initialBackgroundColor)
        {
            this.originalConsole = ColorConsole.Console;
            this.initialForegroundColor = initialForegroundColor;
            this.initialBackgroundColor = initialBackgroundColor;
            this.ForegroundColor = initialForegroundColor;
            this.BackgroundColor = initialBackgroundColor;
            ColorConsole.Console = this;
        }

        public ConsoleColor InitialForegroundColor
        {
            get { return this.initialForegroundColor; }
        }

        public ConsoleColor InitialBackgroundColor
        {
            get { return this.initialBackgroundColor; }
        }

        public ConsoleColor ForegroundColor { get; set; }

        public ConsoleColor BackgroundColor { get; set; }

        public IEnumerable<ColorToken> Tokens
        {
            get { return this.tokens.ToArray(); }
        }

        public void Write(string text)
        {
            this.tokens.Add(new ColorToken(text, this.ForegroundColor, this.BackgroundColor));
        }

        public void WriteLine()
        {
            this.tokens.Add(new ColorToken(Environment.NewLine, this.ForegroundColor, this.BackgroundColor));
        }

        public void Dispose()
        {
            ColorConsole.Console = this.originalConsole;
        }
    }
}
