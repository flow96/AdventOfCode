namespace AdventOfCode2023.Base;

public abstract class PuzzleBase {
    
    protected string FileName;
    
    public PuzzleBase(string fileName)
    {
        this.FileName = fileName;
    }
    
    public abstract void Part1();
    public abstract void Part2();
    
    protected string[] ReadInput()
    {
        return File.ReadAllLines(FileName);
    }
}