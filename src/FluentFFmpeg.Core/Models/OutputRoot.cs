using System.Collections.Generic;

namespace FluentFFmpeg.Core.Models;

public class OutputRoot
{
    private readonly List<Output> _outputs = new();
    private readonly InputRoot _root;

    public OutputRoot(InputRoot root, Output output)
    {
        _root = root;
        _outputs.Add(output);
    }

    public OutputRoot(InputRoot root, IEnumerable<Output> outputs)
    {
        _root = root;
        _outputs.AddRange(outputs);
    }

    public override string ToString() => $"{_root} {string.Join(" ", _outputs)}";
}