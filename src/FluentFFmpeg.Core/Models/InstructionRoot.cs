using System.Collections.Generic;
using FluentFFmpeg.Core.Options;

namespace FluentFFmpeg.Core.Models;

public class InstructionRoot
{
    private readonly List<GlobalOption> _globalOptions = new();

    public InstructionRoot()
    {
    }

    public InstructionRoot(GlobalOption option)
    {
        _globalOptions.Add(option);
    }

    public InstructionRoot(IEnumerable<GlobalOption> options)
    {
        _globalOptions.AddRange(options);
    }

    public override string ToString() => _globalOptions.Count == 0 ? "" : string.Join(" ", _globalOptions);
}