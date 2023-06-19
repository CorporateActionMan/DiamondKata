using FluentAssertions;

namespace Diamond.Config.Tests;

public class ConfigObjectResolverTests
{
    // TODO write negative tests about the config file path and the fact the initialChar and spaceChar might
    // have more than one char it is a limitation of the System.CommandLine Framework that char is not supported as a type
    [Fact]
    public void WhenNoInitialCharOrSpaceCharSpecifiedThenItResolvesFromTheFile()
    {
        var configObject = ConfigObjectResolver.Resolve("diamondConfig.json", "", "");
        configObject.InitialChar.Should().Be('A');
        configObject.SpacingChar.Should().Be('*');
    }

    [Fact]
    public void WhenOnlyInitialCharSuppliedThenItUsesThat()
    {
        var configObject = ConfigObjectResolver.Resolve("diamondConfig.json", "P", "");
        configObject.InitialChar.Should().Be('P');
        configObject.SpacingChar.Should().Be('*');
    }

    [Fact]
    public void WhenOnlySpaceCharSuppliedThenItUsesThat()
    {
        var configObject = ConfigObjectResolver.Resolve("diamondConfig.json", "", "|");
        configObject.InitialChar.Should().Be('A');
        configObject.SpacingChar.Should().Be('|');
    }

    [Fact]
    public void WhenBothSpaceCharAndInitialCharSuppliedItUsesThose()
    {
        var configObject = ConfigObjectResolver.Resolve("diamondConfig.json", "L", "@");
        configObject.InitialChar.Should().Be('L');
        configObject.SpacingChar.Should().Be('@');
    }
}