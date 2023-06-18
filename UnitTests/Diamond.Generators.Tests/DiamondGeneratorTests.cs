using Diamond.Config;
using FluentAssertions;

namespace Diamond.Generators.Tests;

public class DiamondGeneratorTests
{
    [Theory]
    [MemberData(nameof(DiamondScenarios))]
    public async Task CanGenerateAnExpectedDiamond(char targetCharacter, IEnumerable<Tuple<uint, char[]>> expectedLines)
    {
        ConfigurationObject configurationObject = new ConfigurationObject('A', '*');
        DiamondGenerator diamondGenerator = new DiamondGenerator(configurationObject);
        CharacterDiamond characterDiamond = await diamondGenerator.Generate(targetCharacter);
 

        characterDiamond.Data.Should().BeEquivalentTo(expectedLines);
    }
    
    public static IEnumerable<object[]> DiamondScenarios => new List<object[]>
    {
        new object[] { 'A', Scenario_A() },
        new object[] { 'B', Scenario_B() },
        new object[] { 'C', Scenario_C() },
        new object[] { 'G', Scenario_G() },
    };

    private static IEnumerable<Tuple<uint, char[]>> Scenario_A()
    {
        ConfigurationObject configurationObject = new ConfigurationObject('A', '*');
        var expectedALine = new[]
        {
            configurationObject.InitialChar
        };
        
        IEnumerable<Tuple<uint, char[]>> expectedLines = new[]
        {
            new Tuple<uint, char[]>(1, expectedALine)
        };

        return expectedLines;
    }
    private static IEnumerable<Tuple<uint, char[]>> Scenario_B()
    {
        ConfigurationObject configurationObject = new ConfigurationObject('A', '*');
        var expectedALine = new[]
        {
            configurationObject.SpacingChar,
            configurationObject.InitialChar,
            configurationObject.SpacingChar
        };
        var expectedBLine = new[]
        {
            'B',
            configurationObject.SpacingChar,
            'B'
        };
        IEnumerable<Tuple<uint, char[]>> expectedLines = new[]
        {
            new Tuple<uint, char[]>(1, expectedALine),
            new Tuple<uint, char[]>(2, expectedBLine),
            new Tuple<uint, char[]>(3, expectedALine)
        };

        return expectedLines;
    }
    private static IEnumerable<Tuple<uint, char[]>> Scenario_C()
    {
        ConfigurationObject configurationObject = new ConfigurationObject('A', '*');
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

        return expectedLines;
    }
    private static IEnumerable<Tuple<uint, char[]>> Scenario_G()
    {
        ConfigurationObject configurationObject = new ConfigurationObject('A', '*');
        var expectedALine = new[]
        {
            configurationObject.SpacingChar,
            configurationObject.SpacingChar,
            configurationObject.SpacingChar,
            configurationObject.SpacingChar,
            configurationObject.SpacingChar,
            configurationObject.SpacingChar,
            configurationObject.InitialChar,
            configurationObject.SpacingChar,
            configurationObject.SpacingChar,
            configurationObject.SpacingChar,
            configurationObject.SpacingChar,
            configurationObject.SpacingChar,
            configurationObject.SpacingChar
        };
        var expectedBLine = new[]
        {
            configurationObject.SpacingChar,
            configurationObject.SpacingChar,
            configurationObject.SpacingChar,
            configurationObject.SpacingChar,
            configurationObject.SpacingChar,
            'B',
            configurationObject.SpacingChar,
            'B',
            configurationObject.SpacingChar,
            configurationObject.SpacingChar,
            configurationObject.SpacingChar,
            configurationObject.SpacingChar,
            configurationObject.SpacingChar
        };
        var expectedCLine = new[]
        {
            configurationObject.SpacingChar,
            configurationObject.SpacingChar,
            configurationObject.SpacingChar,
            configurationObject.SpacingChar,
            'C',
            configurationObject.SpacingChar,
            configurationObject.SpacingChar,
            configurationObject.SpacingChar,
            'C',
            configurationObject.SpacingChar,
            configurationObject.SpacingChar,
            configurationObject.SpacingChar,
            configurationObject.SpacingChar
        };
        var expectedDLine = new[]
        {
            configurationObject.SpacingChar,
            configurationObject.SpacingChar,
            configurationObject.SpacingChar,
            'D',
            configurationObject.SpacingChar,
            configurationObject.SpacingChar,
            configurationObject.SpacingChar,
            configurationObject.SpacingChar,
            configurationObject.SpacingChar,
            'D',
            configurationObject.SpacingChar,
            configurationObject.SpacingChar,
            configurationObject.SpacingChar
        };
        var expectedELine = new[]
        {
            configurationObject.SpacingChar,
            configurationObject.SpacingChar,
            'E',
            configurationObject.SpacingChar,
            configurationObject.SpacingChar,
            configurationObject.SpacingChar,
            configurationObject.SpacingChar,
            configurationObject.SpacingChar,
            configurationObject.SpacingChar,
            configurationObject.SpacingChar,
            'E',
            configurationObject.SpacingChar,
            configurationObject.SpacingChar
        };
        var expectedFLine = new[]
        {
            configurationObject.SpacingChar,
            'F',
            configurationObject.SpacingChar,
            configurationObject.SpacingChar,
            configurationObject.SpacingChar,
            configurationObject.SpacingChar,
            configurationObject.SpacingChar,
            configurationObject.SpacingChar,
            configurationObject.SpacingChar,
            configurationObject.SpacingChar,
            configurationObject.SpacingChar,
            'F',
            configurationObject.SpacingChar
        };
        var expectedGLine = new[]
        {
            'G',
            configurationObject.SpacingChar,
            configurationObject.SpacingChar,
            configurationObject.SpacingChar,
            configurationObject.SpacingChar,
            configurationObject.SpacingChar,
            configurationObject.SpacingChar,
            configurationObject.SpacingChar,
            configurationObject.SpacingChar,
            configurationObject.SpacingChar,
            configurationObject.SpacingChar,
            configurationObject.SpacingChar,
            'G'
        };
        IEnumerable<Tuple<uint, char[]>> expectedLines = new[]
        {
            new Tuple<uint, char[]>(1, expectedALine),
            new Tuple<uint, char[]>(2, expectedBLine),
            new Tuple<uint, char[]>(3, expectedCLine),
            new Tuple<uint, char[]>(4, expectedDLine),
            new Tuple<uint, char[]>(5, expectedELine),
            new Tuple<uint, char[]>(6, expectedFLine),
            new Tuple<uint, char[]>(7, expectedGLine),
            new Tuple<uint, char[]>(8, expectedFLine),
            new Tuple<uint, char[]>(9, expectedELine),
            new Tuple<uint, char[]>(10, expectedDLine),
            new Tuple<uint, char[]>(11, expectedCLine),
            new Tuple<uint, char[]>(12, expectedBLine),
            new Tuple<uint, char[]>(13, expectedALine)
        };

        return expectedLines;
    }
}