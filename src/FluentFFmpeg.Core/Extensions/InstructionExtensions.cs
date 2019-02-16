using System.Collections.Generic;
using FluentFFmpeg.Core.Models;

namespace FluentFFmpeg.Core.Extensions
{
    public static class InstructionExtensions
    {
        public static InputRoot AddInput(this InstructionRoot root, Input input)
        {
            return new InputRoot(root, input);
        }

        public static InputRoot AddInputs(this InstructionRoot root, IEnumerable<Input> inputs)
        {
            return new InputRoot(root, inputs);
        }

        public static OutputRoot AddOutput(this InputRoot root, Output output)
        {
            return new OutputRoot(root, output);
        }

        public static OutputRoot AddOutputs(this InputRoot root, IEnumerable<Output> outputs)
        {
            return new OutputRoot(root, outputs);
        }

        public static Instruction GetInstruction(this OutputRoot root)
        {
            return new Instruction(root);
        }
    }
}