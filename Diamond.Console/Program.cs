// See https://aka.ms/new-console-template for more information

using System.CommandLine;
using System.Text.Json;
using Diamond.Config;
using Diamond.Generators;
using Diamond.Writers;

var targetCharOption = new Option<string>(
    aliases: new[] { "--target-char", "-t" },
    description: "the target character that is rendered to shape the diamond");
var initialCharOption = new Option<string>(
    aliases: new[] { "--initial-char", "-i" },
    description: "the initial character that is rendered in the diamond");
var spacingCharOption = new Option<string>(
    aliases: new[] { "--space-char", "-s" },
    description: "the spacing character that is rendered in the diamond");
var configPathOption = new Option<string>(
    aliases: new[] { "--config-path", "-c" },
    description: "the path to the configuration file, defaults to current working directory");
var writeLineNumbersOption = new Option<bool>(
    aliases: new[] { "--line-numbers", "-l" },
    description: "indicates if the output should include line numbers");

var rootCommand = new RootCommand(description: "A Diamond Kata implementation by Ashley Wagstaffe")
{
    targetCharOption,
    initialCharOption,
    spacingCharOption,
    configPathOption,
    writeLineNumbersOption
};

rootCommand.SetHandler(
    async (string targetChar, string initialChar, string spaceChar, string configPath, bool writeLineNumbers) =>
    {
        var consoleWriter = new ConsoleWriter(writeLineNumbers);

        var configObject = ConfigObjectResolver.Resolve(configPath, initialChar, spaceChar);
        var diamondGenerator = new DiamondGenerator(configObject);
        var characterDiamond = await diamondGenerator.Generate(targetChar[0]);
        consoleWriter.Write(characterDiamond);
    }, 
    targetCharOption,
    initialCharOption, 
    spacingCharOption,
    configPathOption,
    writeLineNumbersOption);
    
    await rootCommand.InvokeAsync(args);