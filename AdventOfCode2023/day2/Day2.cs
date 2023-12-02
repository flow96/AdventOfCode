public class Day2
{
    private const string FileName = "day2/Input.txt";
    
    private class Game
    {
        public int Id;
        public List<Reveal> Reveals = new();
        
        public int MaxRed => Reveals.Max(r => r.Red);
        public int MaxGreen => Reveals.Max(r => r.Green);
        public int MaxBlue => Reveals.Max(r => r.Blue);
    }

    private class Reveal
    {
        public int Red = 0;
        public int Green = 0;
        public int Blue = 0;
    }
    
    public static void Part1()
    {
        var games = ParseGames();
        var sum = games.Sum(g => g.MaxRed <= 12 && g.MaxGreen <= 13 && g.MaxBlue <= 14 ? g.Id : 0);
        Console.WriteLine("Sum: " + sum);
    }
    
    public static void Part2()
    {
        var games = ParseGames();
        var sum = games.Sum(g => g.MaxRed * g.MaxGreen * g.MaxBlue);
        Console.WriteLine("Sum: " + sum);
    }
    
    private static List<Game> ParseGames()
    {
        List<Game> games = new();
        foreach (var line in File.ReadAllLines(FileName))
        {
            var game = new Game();
            game.Id = Int32.Parse(line.Substring(5, line.IndexOf(':') - 5));
            var allReleveals = line.Substring(line.IndexOf(':') + 2);
            foreach (var revealString in allReleveals.Split(';'))
            {
                Reveal reveal = new Reveal();
                // e.g. "3 blue, 4 red"
                foreach (var cube in revealString.Split(','))
                {
                    // [0] => 3; [1] => blue 
                    var cubeValues = cube.Trim().Split(' ');
                    var count = Int32.Parse(cubeValues[0]);
                    if (cubeValues[1] == "red")
                        reveal.Red = count;
                    if (cubeValues[1] == "green")
                        reveal.Green = count;
                    if (cubeValues[1] == "blue")
                        reveal.Blue = count;
                }
                game.Reveals.Add(reveal);
            }
            games.Add(game);
        }
        
        return games;
    }
}
