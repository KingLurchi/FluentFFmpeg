using System.Collections.Generic;
using FluentFFmpeg.Core.Options;

namespace FluentFFmpeg.Core.Models
{
    public class Input
    {
        private readonly List<InputOption> _inputOptions = new List<InputOption>();
        private readonly string _path;

        public Input(string path)
        {
            _path = path;
        }

        public Input(string path, InputOption option)
        {
            _path = path;
            _inputOptions.Add(option);
        }

        public Input(string path, IEnumerable<InputOption> options)
        {
            _path = path;
            _inputOptions.AddRange(options);
        }

        public override string ToString()
        {
            return _inputOptions.Count == 0 ? $"-i \"{_path}\"" : $"{string.Join(" ", _inputOptions)} -i \"{_path}\"";
        }
    }
}