namespace Diamond.Generators;

public class LineGenerator
{
    public LineGenerator(char spaceSeparator)
    {
        SpaceSeparator = spaceSeparator;
    }
    
    public char SpaceSeparator { get; }

    public async Task<Tuple<uint, char[]>> GenerateAsync(LineParameters lineParameters)
    {
        return await Task.Run(() => Generate(lineParameters));
    }

    public Tuple<uint, char[]> Generate(
        LineParameters lineParameters)

    {
        var lineCharacters = new char[lineParameters.LineLength];
        // set all items in the array to the space separator character
        for (var index = 0; index < lineCharacters.Length; index++)
        {
            lineCharacters[index] = SpaceSeparator;
        }

        // overwrite firstCharIndex with the lineCharacter
        lineCharacters[lineParameters.FirstCharIndex] = lineParameters.LineCharacter;
        // overwrite lastCharIndex with the lineCharacter
        lineCharacters[lineParameters.LastCharIndex] = lineParameters.LineCharacter;
        return new Tuple<uint, char[]>(lineParameters.LineNumber, lineCharacters);
    }
}