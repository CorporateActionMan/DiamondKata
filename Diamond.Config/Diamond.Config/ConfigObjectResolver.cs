using System.Text.Json;

namespace Diamond.Config;

public static class ConfigObjectResolver
{
    public static ConfigurationObject Resolve(string configPath, string initialChar, string spaceChar)
    {
        var resolvedConfigPath = string.IsNullOrWhiteSpace(configPath)
            ? Path.Combine(Directory.GetCurrentDirectory(), "diamondConfig.json") : configPath;
        // TODO to check if configPath is actually a path if not throw an exception
        var configJsonString = File.ReadAllText(resolvedConfigPath);
        // TODO handle Json parsing errors more gracefully
        var configObject = JsonSerializer.Deserialize<ConfigurationObject>(configJsonString);
        if(configObject == null)
        {
            throw new ApplicationException("Configuration was null put a better error message here");
        }

        if (!string.IsNullOrWhiteSpace(initialChar) && !string.IsNullOrEmpty(spaceChar))
        {
            return new ConfigurationObject(initialChar[0], spaceChar[0]);
        }

        if (!string.IsNullOrWhiteSpace(initialChar))
        {
            return configObject with { InitialChar = initialChar[0] };
        }

        if (!string.IsNullOrEmpty(spaceChar))
        {
            return configObject with { SpacingChar = spaceChar[0] };
        }

        return configObject;
    }
}