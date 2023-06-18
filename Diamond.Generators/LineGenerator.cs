namespace Diamond.Generators;

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