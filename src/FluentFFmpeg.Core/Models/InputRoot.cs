using System.Collections.Generic;

namespace FluentFFmpeg.Core.Models
{
    public class InputRoot
    {
        private readonly List<Input> _inputs = new List<Input>();
        private readonly InstructionRoot _root;

        public InputRoot(InstructionRoot root, Input input)
        {
            _root = root;
            _inputs.Add(input);
        }

        public InputRoot(InstructionRoot root, IEnumerable<Input> inputs)
        {
            _root = root;
            _inputs.AddRange(inputs);
        }

        public override string ToString()
        {
            return $"{_root} {string.Join(" ", _inputs)}";
        }
    }
}