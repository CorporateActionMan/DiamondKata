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
        var line = lineGenerator.Generate(lineNumber, lineCharacter, 0, 22, lineLength);
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
        var expectedLine = new Tuple<uint, char[]>(
            lineNumber, expectedCharArray
            );
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
        var line = lineGenerator.Generate(lineNumber, lineCharacter, 0, 22, lineLength);
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
        var expectedLine = new Tuple<uint, char[]>(
            lineNumber, expectedCharArray
        );
        line.Item1.Should().Be(lineNumber);
        line.Item2.Should().NotBeEquivalentTo(expectedCharArray);
    }
}

public class LineGenerator
{
    public LineGenerator(char spaceSeparator)
    {
        SpaceSeparator = spaceSeparator;
    }
    
    public char SpaceSeparator { get; }

    public Tuple<uint, char[]> Generate(
        uint lineNumber, 
        char lineCharacter, 
        uint firstCharIndex, 
        uint lastCharIndex, 
        uint lineLength)
    {
        var lineCharacters = new char[lineLength];
        // set all items in the array to the space separator character
        for (var index = 0; index < lineCharacters.Length; index++)
        {
            lineCharacters[index] = SpaceSeparator;
        }
        // overwrite firstCharIndex with the lineCharacter
        lineCharacters[firstCharIndex] = lineCharacter;
        // overwrite lastCharIndex with the lineCharacter
        lineCharacters[lastCharIndex] = lineCharacter;
        return new Tuple<uint, char[]>(lineNumber, lineCharacters);
    }
}