// <copyright file="MaskingFeature.cs" company="ColoredConsole contributors">
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

    public static class MaskingFeature
    {
        [Scenario]
        public static void MaskingColors(
            TestConsole console, ColorToken[] input, ColorToken[] output)
        {
            "Given a console"
                .f(c => console = new TestConsole(ConsoleColor.White, ConsoleColor.Black).Using(c));

            "And the text 'Hello' in red, a space and 'world'"
                .f(() => input = new[] { "Hello".Red(), " ", "world" });

            "When I mask the text with blue"
                .f(() => input = input.Mask(ConsoleColor.Blue));

            "When I write a line containing the text"
                .f(() => ColorConsole.WriteLine(input));

            "And look at the console"
                .f(() => output = console.Tokens.ToArray());

            "Then the console contains a line"
                .f(() =>
                {
                    output.Length.Should().Be(
                        4, "there should be two tokens for the words, a token for the space and a token for the line ending");

                    output[3].Text.Should().Be(Environment.NewLine, "the last token should be a new line");
                });

            "And the line contains 'Hello' in red, a space in blue and 'world' in blue"
                .f(() =>
                {
                    output[0].Text.Should().Be("Hello");
                    output[0].Color.Should().Be(ConsoleColor.Red);
                    output[1].Text.Should().Be(" ");
                    output[1].Color.Should().Be(ConsoleColor.Blue);
                    output[2].Text.Should().Be("world");
                    output[2].Color.Should().Be(ConsoleColor.Blue);
                });
        }

        [Scenario]
        public static void MaskingBackgroundColors(
            TestConsole console, ColorToken[] input, ColorToken[] output)
        {
            "Given a console"
                .f(c => console = new TestConsole(ConsoleColor.White, ConsoleColor.Black).Using(c));

            "And the text 'Hello' on red, a space and 'world'"
                .f(() => input = new[] { "Hello".OnRed(), " ", "world".OnBlue() });

            "When I mask the text with no color on blue"
                .f(() => input = input.Mask(null, ConsoleColor.Blue));

            "When I write a line containing the text"
                .f(() => ColorConsole.WriteLine(input));

            "And look at the console"
                .f(() => output = console.Tokens.ToArray());

            "Then the console contains a line"
                .f(() =>
                {
                    output.Length.Should().Be(
                        4, "there should be two tokens for the words, a token for the space and a token for the line ending");

                    output[3].Text.Should().Be(Environment.NewLine, "the last token should be a new line");
                });

            "And the line contains 'Hello' on red, a space on blue and 'world' on blue"
                .f(() =>
                {
                    output[0].Text.Should().Be("Hello");
                    output[0].BackgroundColor.Should().Be(ConsoleColor.Red);
                    output[1].Text.Should().Be(" ");
                    output[1].BackgroundColor.Should().Be(ConsoleColor.Blue);
                    output[2].Text.Should().Be("world");
                    output[2].BackgroundColor.Should().Be(ConsoleColor.Blue);
                });
        }

        [Scenario]
        public static void MaskingColorsAndBackgroundColors(
            TestConsole console, ColorToken[] input, ColorToken[] output)
        {
            "Given a console"
                .f(c => console = new TestConsole(ConsoleColor.White, ConsoleColor.Black).Using(c));

            "And the text 'Hello' in red on yellow, a space and 'world'"
                .f(() => input = new[] { "Hello".Red().OnYellow(), " ", "world" });

            "When I mask the text with blue on cyan"
                .f(() => input = input.Mask(ConsoleColor.Blue, ConsoleColor.Cyan));

            "When I write a line containing the text"
                .f(() => ColorConsole.WriteLine(input));

            "And look at the console"
                .f(() => output = console.Tokens.ToArray());

            "Then the console contains a line"
                .f(() =>
                {
                    output.Length.Should().Be(
                        4, "there should be two tokens for the words, a token for the space and a token for the line ending");

                    output[3].Text.Should().Be(Environment.NewLine, "the last token should be a new line");
                });

            "And the line contains 'Hello' in red on yellow, a space and 'world' in blue on cyan"
                .f(() =>
                {
                    output[0].Text.Should().Be("Hello");
                    output[0].Color.Should().Be(ConsoleColor.Red);
                    output[0].BackgroundColor.Should().Be(ConsoleColor.Yellow);
                    output[1].Text.Should().Be(" ");
                    output[1].Color.Should().Be(ConsoleColor.Blue);
                    output[1].BackgroundColor.Should().Be(ConsoleColor.Cyan);
                    output[2].Text.Should().Be("world");
                    output[2].Color.Should().Be(ConsoleColor.Blue);
                    output[2].BackgroundColor.Should().Be(ConsoleColor.Cyan);
                });
        }
    }
}
