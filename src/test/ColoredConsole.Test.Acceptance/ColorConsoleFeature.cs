// <copyright file="ColorConsoleFeature.cs" company="ColoredConsole contributors">
//  Copyright (c) ColoredConsole contributors. (coloredconsole@gmail.com)
// </copyright>

namespace ColoredConsole.Test.Acceptance
{
    using System;
    using System.Linq;
    using ColoredConsole;
    using ColoredConsole.Test.Acceptance.Support;
    using FluentAssertions;
    using Xbehave;

    public static class ColorConsoleFeature
    {
        [Scenario]
        public static void WritingALineWithColors(
            TestConsole console, ColorToken[] input, ColorToken[] output)
        {
            "Given a console"
                .x(c => console = new TestConsole(ConsoleColor.White, ConsoleColor.Black).Using(c));

            "And the text 'Hello' in red, a space and 'world' in blue"
                .x(() => input = new[] { "Hello".Red(), " ", "world".Blue() });

            "When I write a line containing the text"
                .x(() => ColorConsole.WriteLine(input));

            "And look at the console"
                .x(() => output = console.Tokens.ToArray());

            "Then the console contains a line"
                .x(() =>
                {
                    output.Length.Should().Be(
                        4, "there should be two tokens for the words, a token for the space and a token for the line ending");

                    output[3].Text.Should().Be(Environment.NewLine, "the last token should be a new line");
                });

            "And the line contains 'Hello' in red, a space and 'world' in blue"
                .x(() =>
                {
                    output[0].Text.Should().Be("Hello");
                    output[0].Color.Should().Be(ConsoleColor.Red);
                    output[1].Text.Should().Be(" ");
                    output[1].Color.Should().Be(console.InitialForegroundColor);
                    output[2].Text.Should().Be("world");
                    output[2].Color.Should().Be(ConsoleColor.Blue);
                });
        }

        [Scenario]
        public static void WritingALineWithBackgroundColors(
            TestConsole console, ColorToken[] input, ColorToken[] output)
        {
            "Given a console"
                .x(c => console = new TestConsole(ConsoleColor.White, ConsoleColor.Black).Using(c));

            "And the text 'Hello' on red, a space and 'world' on blue"
                .x(() => input = new[] { "Hello".OnRed(), " ", "world".OnBlue() });

            "When I write a line containing the text"
                .x(() => ColorConsole.WriteLine(input));

            "And look at the console"
                .x(() => output = console.Tokens.ToArray());

            "Then the console contains a line"
                .x(() =>
                {
                    output.Length.Should().Be(
                        4, "there should be two tokens for the words, a token for the space and a token for the line ending");

                    output[3].Text.Should().Be(Environment.NewLine, "the last token should be a new line");
                });

            "And the line contains 'Hello' on red, a space and 'world' on blue"
                .x(() =>
                {
                    output[0].Text.Should().Be("Hello");
                    output[0].BackgroundColor.Should().Be(ConsoleColor.Red);
                    output[1].Text.Should().Be(" ");
                    output[1].BackgroundColor.Should().Be(console.InitialBackgroundColor);
                    output[2].Text.Should().Be("world");
                    output[2].BackgroundColor.Should().Be(ConsoleColor.Blue);
                });
        }

        [Scenario]
        public static void WritingALineWithColorsAndBackgroundColors(
            TestConsole console, ColorToken[] input, ColorToken[] output)
        {
            "Given a console"
                .x(c => console = new TestConsole(ConsoleColor.White, ConsoleColor.Black).Using(c));

            "And the text 'Hello' in red on yellow, a space and 'world' in blue on cyan"
                .x(() => input = new[] { "Hello".Red().OnYellow(), " ", "world".Blue().OnCyan() });

            "When I write a line containing the text"
                .x(() => ColorConsole.WriteLine(input));

            "And look at the console"
                .x(() => output = console.Tokens.ToArray());

            "Then the console contains a line"
                .x(() =>
                {
                    output.Length.Should().Be(
                        4, "there should be two tokens for the words, a token for the space and a token for the line ending");

                    output[3].Text.Should().Be(Environment.NewLine, "the last token should be a new line");
                });

            "And the line contains 'Hello' in red on yellow, a space and 'world' in blue on cyan"
                .x(() =>
                {
                    output[0].Text.Should().Be("Hello");
                    output[0].Color.Should().Be(ConsoleColor.Red);
                    output[0].BackgroundColor.Should().Be(ConsoleColor.Yellow);
                    output[1].Text.Should().Be(" ");
                    output[1].Color.Should().Be(console.InitialForegroundColor);
                    output[1].BackgroundColor.Should().Be(console.InitialBackgroundColor);
                    output[2].Text.Should().Be("world");
                    output[2].Color.Should().Be(ConsoleColor.Blue);
                    output[2].BackgroundColor.Should().Be(ConsoleColor.Cyan);
                });
        }

        [Scenario]
        public static void WritingALineWithParsedStringColors(TestConsole console, string input, ColorToken[] output)
        {
            "Given a console"
                .x(c => console = new TestConsole(ConsoleColor.White, ConsoleColor.Black).Using(c));

            "And the text 'Hello ' in red and 'world' in blue"
                .x(() => input = "@RED@Hello @BLUE@world");

            "When I write a line containing the text"
                .x(() => ColorConsole.WriteLine(input.ParseColor()));

            "And look at the console"
                .x(() => output = console.Tokens.ToArray());

            "Then the console contains a line"
                .x(() =>
                    {
                        output.Length.Should().Be(
                            3, "there should be two tokens for the words and a token for the line ending");

                        output[2].Text.Should().Be(Environment.NewLine, "the last token should be a new line");
                    });

            "And the line contains 'Hello ' in red and 'world' in blue"
                .x(() =>
                    {
                        output[0].Text.Should().Be("Hello ");
                        output[0].Color.Should().Be(ConsoleColor.Red);
                        output[1].Text.Should().Be("world");
                        output[1].Color.Should().Be(ConsoleColor.Blue);
                    });
        }
    }
}
