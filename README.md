# DiamondKata
Repository to solve the Diamond Kata

# Instructions
1. Clone this repository
1. Open up the .Net solution in the IDE of your choice. The following IDEs have been tested:
    - Rider
    - Visual studio Community Edition
    - VS Code
1. Build the Code
1. Run the tests
1. Choose how you are going to run the application:
    - Console App via IDE
    - Console App via shell

## Run via shell
Issue the following command:

`dotnet Diamond.Console.dll --help`

Sample command that will render starting from the letter 'O' to the diamond's apex at X with the '%' char as the spacing character

`dotnet Diamond.Console.dll -l -i O -s '%' -t X`

## Things to consider
- Create an interface and implementations of other Diamond Katas, then create a Test with an extremely large diamond to bench mark
the implementations against each other
- Create a Json Writer so it can be consumed by a Web Api