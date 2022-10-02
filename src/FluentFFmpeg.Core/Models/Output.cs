using System.Collections.Generic;
using FluentFFmpeg.Core.Options;

namespace FluentFFmpeg.Core.Models;

public class Output
{
    private readonly List<OutputOption> _outputOptions = new();
    private readonly string _path;

    public Output(string path)
    {
        _path = path;
    }

    public Output(string path, OutputOption option)
    {
        _path = path;
        _outputOptions.Add(option);
    }

    public Output(string path, IEnumerable<OutputOption> options)
    {
        _path = path;
        _outputOptions.AddRange(options);
    }

    public override string ToString() => _outputOptions.Count == 0 ? $" \"{_path}\"" : $"{string.Join(" ", _outputOptions)} \"{_path}\"";
}