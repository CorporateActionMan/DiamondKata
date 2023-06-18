using Diamond.Config;

namespace Diamond.Generators;

public class DiamondGenerator
{
    public DiamondGenerator(ConfigurationObject configurationObject)
    {
        ConfigurationObject = configurationObject;
    }
    
    public ConfigurationObject ConfigurationObject { get;  }

    public CharacterDiamond Generate(char targetCharacter)
    {
        // find the number of lines
        var initialCharValue = (int)ConfigurationObject.InitialChar;
        var targetCharValue = (int)targetCharacter;
        var charValueDelta = targetCharValue - initialCharValue;
        var axisLength = (uint)charValueDelta * 2 + 1;
        var lineGenerator = new LineGenerator(ConfigurationObject.SpacingChar);
        var firstCharIndex = (axisLength - 1) / 2;
        var lastCharIndex = firstCharIndex;
        var data = new List<Tuple<uint, char[]>>();
        uint lineNumber = 1;
        for (var charIterator = initialCharValue; charIterator <= targetCharValue; charIterator++)
        {
            var lineData = lineGenerator.Generate(lineNumber, (char)charIterator, firstCharIndex,lastCharIndex, axisLength);
            data.Add(lineData);
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
            var lineData = lineGenerator.Generate(lineNumber, (char)charIterator, firstCharIndex,lastCharIndex, axisLength);
            data.Add(lineData);
            lineNumber++;
        }

        return new CharacterDiamond(data);
    }
}