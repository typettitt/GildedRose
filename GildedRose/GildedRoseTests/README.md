# Gilded Rose starting position in Csharp Core

## Build the project

Use your normal build tools. 

## Run the TextTestFixture from the Command-Line

For e.g. 10 days:

```
dotnet run --project GildedRoseTests/GildedRoseTests.csproj 10
```

You should make sure the command shown above works when you execute it in a terminal before trying to use TextTest (see below). If your tooling has placed the executable somewhere else, you will need to adjust the path above.


## Running the ApprovalTest

The approval test will run the TextTestFixture with an argument of 30 for 30 days. If the the expected results do not match, a file named actual.txt will be created in `Outputs/ThirtyDays` in the repository root directory. You can manually compare `actual.txt` and `expected.txt` with a diff tool.