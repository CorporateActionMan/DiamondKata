using Diamond.Config;

namespace Diamond.Generators;

public class DiamondGenerator
{
    public DiamondGenerator(ConfigurationObject configurationObject)
    {
        ConfigurationObject = configurationObject;
    }
    
    public ConfigurationObject ConfigurationObject { get;  }

    public async Task<CharacterDiamond> Generate(char targetCharacter)
    {
        // find the number of lines
        var initialCharValue = (int)ConfigurationObject.InitialChar;
        var targetCharValue = (int)targetCharacter;
        var charValueDelta = targetCharValue - initialCharValue;
        var axisLength = (uint)charValueDelta * 2 + 1;
        var lineGenerator = new LineGenerator(ConfigurationObject.SpacingChar);
        var firstCharIndex = (axisLength - 1) / 2;
        var lastCharIndex = firstCharIndex;
        uint lineNumber = 1;
        var lineParameters = new List<LineParameters>();
        for (var charIterator = initialCharValue; charIterator <= targetCharValue; charIterator++)
        {
            lineParameters.Add(new LineParameters(lineNumber, (char)charIterator, firstCharIndex,lastCharIndex, axisLength));
            if (firstCharIndex > 0)
            {
                firstCharIndex--;
                lastCharIndex++;
            }
            lineNumber++;
        }
        
        for (var charIterator = targetCharValue - 1; charIterator >= initialCharValue; charIterator--)
        {
            firstCharIndex++;
            lastCharIndex--;
            lineParameters.Add(new LineParameters(lineNumber, (char)charIterator, firstCharIndex,lastCharIndex, axisLength));
            lineNumber++;
        }

        var tasks = lineParameters.Select(lp => lineGenerator.GenerateAsync(lp)).ToArray();
        var data = await Task.WhenAll(tasks);
        return new CharacterDiamond(data);
    }
}