using FluentAssertions;

namespace Diamond.Generators.Tests;

public class LineGeneratorTests
{
    [Fact]
    public void CanGenerateTheExpectedLine()
    {
        const char spaceSeparator = '_';
        var lineGenerator = new LineGenerator(spaceSeparator);
        const uint lineNumber = 11;
        const char lineCharacter = 'K';
        const uint lineLength = (lineNumber * 2) + 1;
        var lineParameters = new LineParameters(lineNumber, lineCharacter, 0, 22, lineLength);
        var line = lineGenerator.Generate(lineParameters);
        var expectedCharArray = new[]
        {
            lineCharacter,
            spaceSeparator,
            spaceSeparator,
            spaceSeparator,
            spaceSeparator,
            spaceSeparator,
            spaceSeparator,
            spaceSeparator,
            spaceSeparator,
            spaceSeparator,
            spaceSeparator,
            spaceSeparator,
            spaceSeparator,
            spaceSeparator,
            spaceSeparator,
            spaceSeparator,
            spaceSeparator,
            spaceSeparator,
            spaceSeparator,
            spaceSeparator,
            spaceSeparator,
            spaceSeparator,
            lineCharacter
        };
        line.Item1.Should().Be(lineNumber);
        line.Item2.Should().BeEquivalentTo(expectedCharArray);
    }
    
    [Fact]
    public void CanGenerateTheExpectedLineWhenTheExpectedIsOutOfOrder()
    {
        const char spaceSeparator = '_';
        var lineGenerator = new LineGenerator(spaceSeparator);
        const uint lineNumber = 11;
        const char lineCharacter = 'K';
        const uint lineLength = (lineNumber * 2) + 1;
        var lineParameters = new LineParameters(lineNumber, lineCharacter, 0, 22, lineLength);
        var line = lineGenerator.Generate(lineParameters);
        var expectedCharArray = new[]
        {
            lineCharacter,
            spaceSeparator,
            spaceSeparator,
            spaceSeparator,
            spaceSeparator,
            spaceSeparator,
            spaceSeparator,
            spaceSeparator,
            spaceSeparator,
            spaceSeparator,
            spaceSeparator,
            lineCharacter,
            spaceSeparator,
            spaceSeparator,
            spaceSeparator,
            spaceSeparator,
            spaceSeparator,
            spaceSeparator,
            spaceSeparator,
            spaceSeparator,
            spaceSeparator,
            spaceSeparator
        };
        line.Item1.Should().Be(lineNumber);
        line.Item2.Should().NotBeEquivalentTo(expectedCharArray);
    }
}