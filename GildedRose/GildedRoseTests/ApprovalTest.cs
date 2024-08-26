using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Xunit;

namespace GildedRoseTests;

public class ApprovalTest
{
    [Fact]
    public void ThirtyDays()
    {
        var repoRootDirectory = GetRepoRootDirectory();

        Directory.SetCurrentDirectory(repoRootDirectory);

        var outputPath = Path.Combine(repoRootDirectory, "Outputs/ThirtyDays");
        var expectedOutputPath = Path.Combine(outputPath, "expected.txt");
        var errorOutputPath = Path.Combine(outputPath, "actual.txt");

        Directory.CreateDirectory(outputPath);

        var fakeOutput = new StringBuilder();
        Console.SetOut(new StringWriter(fakeOutput));
        Console.SetIn(new StringReader($"a{Environment.NewLine}"));

        TextTestFixture.Main(["30"]);
        var output = fakeOutput.ToString();

        if (!File.Exists(expectedOutputPath))
        {
            Assert.True(false, $"Expected output file '{expectedOutputPath}' not found.");
        }

        using (var reader = new StreamReader(expectedOutputPath))
        {
            var expectedOutput = reader.ReadToEnd();
            File.WriteAllText(errorOutputPath, output);
            if (expectedOutput != output)
            {
                Assert.True(false, $"Output does not match. Actual output saved to '{errorOutputPath}'.");
            }
        }
    }

    private string GetRepoRootDirectory()
    {
        var assemblyLocation = Assembly.GetExecutingAssembly().Location;
        var directory = Path.GetDirectoryName(assemblyLocation);

        while (directory != null)
        {
            if (Directory.GetFiles(directory, ".gitignore", SearchOption.TopDirectoryOnly).Any())
            {
                return directory;
            }

            directory = Path.GetDirectoryName(directory);
        }

        throw new Exception("Repository root directory not found.");
    }
}