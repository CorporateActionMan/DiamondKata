namespace Diamond.Generators;

public record LineParameters(uint LineNumber, 
    char LineCharacter, 
    uint FirstCharIndex, 
    uint LastCharIndex, 
    uint LineLength);