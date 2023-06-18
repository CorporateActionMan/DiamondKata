using System.Text.Json;
using FluentAssertions;

namespace Diamond.Config.Tests;

public class ConfigurationObjectTests
{
    [Fact]
    public void CanInitializeTheConfigurationObjectWithTheInitialCharAndTheSpacingChar()
    {
        const char initialChar = 'A';
        const char spacingChar = '*';
        var configObject = new ConfigurationObject(initialChar, spacingChar);
        configObject.InitialChar.Should().Be(initialChar);
        configObject.SpacingChar.Should().Be(spacingChar);
    }

    [Fact]
    public void CanSerializeTheConfigurationObjectAsExpectedJson()
    {
        const char initialChar = 'A';
        const char spacingChar = '*';
        var configObject = new ConfigurationObject(initialChar, spacingChar);
        var jsonString = JsonSerializer.Serialize(configObject);
        jsonString.Should().Be("{\"initialChar\":\"A\",\"spacingChar\":\"*\"}");
    }

    [Fact]
    public void CanDeserializeTheConfigurationFromValidJson()
    {
        const string jsonString = "{\"initialChar\":\"A\",\"spacingChar\":\"*\"}";
        var configObject = JsonSerializer.Deserialize<ConfigurationObject>(jsonString);
        configObject.Should().NotBeNull();
#pragma warning disable CS8602
        configObject.InitialChar.Should().Be('A');
#pragma warning restore CS8602
        configObject.SpacingChar.Should().Be('*');
    }
}