namespace AdventOfCode2023.day1;

public class Day1
{
    private const string FileName = "day1/Input1.txt";

    private static readonly Dictionary<string, string> NumericValues = new()
    {
        { "one", "1" },
        { "two", "2" },
        { "three", "3" },
        { "four", "4" },
        { "five", "5" },
        { "six", "6" },
        { "seven", "7" },
        { "eight", "8" },
        { "nine", "9" },
    };

    public static void Part1()
    {
        var sum = 0;
        var lines = File.ReadAllLines(FileName);
        foreach (var line in lines)
            sum += ParseLine(line, false);

        Console.WriteLine("Sum: " + sum);
    }

    public static void Part2()
    {
        var sum = 0;
        var lines = File.ReadAllLines(FileName);
        foreach (var line in lines)
            sum += ParseLine(line, true);

        Console.WriteLine("Sum: " + sum);
    }


    private static int ParseLine(string line, bool checkForWords = false)
    {
        (Dictionary<int, string> leftValues, Dictionary<int, string> rightValues) = (new(), new());
        foreach (var wordValue in NumericValues)
        {
            (int leftNumericIndex, int rightNumericIndex) = (line.IndexOf(wordValue.Value), line.LastIndexOf(wordValue.Value));
            
            if (leftNumericIndex > -1) leftValues.Add(leftNumericIndex, wordValue.Value);
            if (rightNumericIndex > -1) rightValues.Add(rightNumericIndex, wordValue.Value);
            
            if (checkForWords)
            {
                (int leftWordIndex, int rightWordIndex) = (line.IndexOf(wordValue.Key), line.LastIndexOf(wordValue.Key));
                if (leftWordIndex > -1) leftValues.Add(leftWordIndex, wordValue.Value);
                if (rightWordIndex > -1) rightValues.Add(rightWordIndex, wordValue.Value);
            }
        }
        
        return int.Parse(leftValues[leftValues.Keys.Min()] + rightValues[rightValues.Keys.Max()]);
    }
}