using Diamond.Generators;

namespace Diamond.Writers;

public class ConsoleWriter
{
    public ConsoleWriter(bool writeLineNumbers)
    {
        WriteLineNumbers = writeLineNumbers;
    }
    public bool WriteLineNumbers { get; private set; }
    
    public void Write(CharacterDiamond diamond)
    {
        
        foreach (var line in diamond.Data)
        {
            var lineOutput = GetLineConsoleLineOutput(line);
            Console.WriteLine(lineOutput);
        }
    }

    private string GetLineConsoleLineOutput(Tuple<uint, char[]> line)
    {
        var lineNumberPrefix = WriteLineNumbers ? $"{line.Item1}\t" : string.Empty;
        var lineAsString = new string(line.Item2);
        return $"{lineNumberPrefix}{lineAsString}";
    }
}