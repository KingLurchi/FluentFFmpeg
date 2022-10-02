namespace FluentFFmpeg.Core.Models;

public class Instruction
{
    public Instruction(OutputRoot root)
    {
        Root = root;
    }

    private OutputRoot Root { get; }

    public override string ToString() => $"{Root}";
}