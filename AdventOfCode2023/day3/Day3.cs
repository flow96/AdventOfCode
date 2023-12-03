using AdventOfCode2023.Base;

namespace AdventOfCode2023.day3;

public class Day3 : PuzzleBase
{
    public Day3() : base(("day3/Input.txt"))
    {
    }

    public override void Part1()
    {
        string[] lines = ReadInput();
        var sum = 0;
        for (int lineRowIndex = 0; lineRowIndex < lines.Length; lineRowIndex++)
        {
            var numberStartIndex = -1;
            var line = lines[lineRowIndex];
            for (int lineIndex = 0; lineIndex < line.Length; lineIndex++)
            {
                var isDigit = Char.IsDigit(line[lineIndex]);
                if (isDigit)
                {
                    if (numberStartIndex == -1) numberStartIndex = lineIndex;
                    if (lineIndex < line.Length - 1) continue;
                }
                if (numberStartIndex > -1)
                {
                    var numberEndIndex = lineIndex >= line.Length - 1 && isDigit ? lineIndex: lineIndex - 1; 
                    int number = int.Parse(line.Substring(numberStartIndex, numberEndIndex - numberStartIndex + 1));
                    var range = Enumerable.Range(numberStartIndex - 1, numberEndIndex - numberStartIndex + 3).ToArray();
                    // Check surroundings for symbols
                    if ((lineRowIndex > 0 && HasSymbolAtPositions(lines[lineRowIndex - 1], range)) ||
                        HasSymbolAtPositions(line, new[] { numberStartIndex - 1, lineIndex }) ||
                        (lineRowIndex + 1 < lines.Length - 1 && HasSymbolAtPositions(lines[lineRowIndex + 1], range)))
                    {
                        sum += number;
                    }
                    numberStartIndex = -1;
                }
            }
        }
        Console.WriteLine("Sum: " + sum);
    }

    public override void Part2()
    {
        throw new NotImplementedException();
    }

    private bool HasSymbolAtPositions(string line, IEnumerable<int> positions)
    {
        foreach (var pos in positions)
        {
            if (pos < 0 || pos > line.Length - 1)
                continue;
            
            var charAtPosition = line[pos];
            if (!Char.IsDigit(charAtPosition) && charAtPosition != '.')
                return true;
        }

        return false;
    }
}