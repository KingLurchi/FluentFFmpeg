using System.Collections.Generic;
using FluentFFmpeg.Core.Models;

namespace FluentFFmpeg.Core.Extensions;

public static class InstructionExtensions
{
    public static InputRoot AddInput(this InstructionRoot root, Input input) => new(root, input);
    public static InputRoot AddInputs(this InstructionRoot root, IEnumerable<Input> inputs) => new(root, inputs);
    public static OutputRoot AddOutput(this InputRoot root, Output output) => new(root, output);
    public static OutputRoot AddOutputs(this InputRoot root, IEnumerable<Output> outputs) => new(root, outputs);
    public static Instruction GetInstruction(this OutputRoot root) => new(root);
}