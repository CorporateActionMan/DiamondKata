using System.Text.Json.Serialization;

namespace Diamond.Config;

public record ConfigurationObject(
    [property:JsonPropertyName("initialChar")]char InitialChar, 
    [property:JsonPropertyName("spacingChar")]char SpacingChar);