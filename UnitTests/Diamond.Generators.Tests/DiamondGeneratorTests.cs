using Diamond.Config;
using FluentAssertions;

namespace Diamond.Generators.Tests;

public class DiamondGeneratorTests
{
    [Fact]
    public void CanGenerateAnExpectedDiamond()
    {
        ConfigurationObject configurationObject = new ConfigurationObject('A', '*');
        DiamondGenerator diamondGenerator = new DiamondGenerator(configurationObject);
        CharacterDiamond characterDiamond = diamondGenerator.Generate('C');
        var expectedALine = new[]
        {
            configurationObject.SpacingChar,
            configurationObject.SpacingChar,
            configurationObject.InitialChar,
            configurationObject.SpacingChar,
            configurationObject.SpacingChar
        };
        var expectedBLine = new[]
        {
            configurationObject.SpacingChar,
            'B',
            configurationObject.SpacingChar,
            'B',
            configurationObject.SpacingChar
        };
        var expectedCLine = new[]
        {
            'C',
            configurationObject.SpacingChar,
            configurationObject.SpacingChar,
            configurationObject.SpacingChar,
            'C'
        };
        IEnumerable<Tuple<uint, char[]>> expectedLines = new[]
        {
            new Tuple<uint, char[]>(1, expectedALine),
            new Tuple<uint, char[]>(2, expectedBLine),
            new Tuple<uint, char[]>(3, expectedCLine),
            new Tuple<uint, char[]>(4, expectedBLine),
            new Tuple<uint, char[]>(5, expectedALine)
        };

        characterDiamond.Data.Should().BeEquivalentTo(expectedLines);
    }
}

public class CharacterDiamond
{
    public CharacterDiamond(IEnumerable<Tuple<uint, char[]>> data)
    {
        Data = data;
    }

    public IEnumerable<Tuple<uint, char[]>> Data { get;  }
}

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