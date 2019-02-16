using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using FluentFFmpeg.Core.Events;
using FluentFFmpeg.Core.Models;

namespace FluentFFmpeg.Core
{
    public interface IFFmpeg
    {
        void Execute(Instruction instruction);
        Task ExecuteAsync(Instruction instruction, CancellationToken token);
    }

    public class FFmpeg : IFFmpeg
    {
        public event Action<ExceptionEventArgs> Exception;
        public event Action<InfoEventArgs> Info;
        public event Action<ProgressEventArgs> Progress;
        public event Action<SuccessEventArgs> Success;

        public void Execute(Instruction instruction)
        {
            using (var process = new Process())
            {
                process.StartInfo = StartInfo(instruction);
            }
        }

        public async Task ExecuteAsync(Instruction instruction, CancellationToken token = default)
        {
            using (var process = new Process())
            {
                process.StartInfo = StartInfo(instruction);

                var outputCompleted = new TaskCompletionSource<bool>();
                process.ErrorDataReceived += (s, e) =>
                {
                    if (string.IsNullOrEmpty(e.Data))
                        outputCompleted.SetResult(true);
                    else if(e.Data.StartsWith("frame="))
                        OnProgressReceived(new ProgressEventArgs(e.Data));
                    else
                        OnInfoReceived(new InfoEventArgs(e.Data));
                };

                try
                {
                    process.Start();
                }
                catch (Exception e)
                {
                    OnExceptionReceived(new ExceptionEventArgs(e));
                    return;
                }

                process.BeginErrorReadLine();
                process.BeginOutputReadLine();

                var exitTask = WaitForExitAsync(process, token);
                var processTask = Task.WhenAll(exitTask, outputCompleted.Task);

                if (await Task.WhenAny(processTask) == processTask && exitTask.Result)
                {
                    OnSuccessReceived(new SuccessEventArgs(true));
                }
                else
                {
                    try
                    {
                        process.Kill();
                    }
                    catch
                    {
                        OnSuccessReceived(new SuccessEventArgs(false));
                    }
                }
            }
        }

        private void OnExceptionReceived(ExceptionEventArgs e)
        {
            Exception?.Invoke(e);
        }

        private void OnInfoReceived(InfoEventArgs e)
        {
            Info?.Invoke(e);
        }

        private void OnProgressReceived(ProgressEventArgs e)
        {
            Progress?.Invoke(e);
        }

        private void OnSuccessReceived(SuccessEventArgs e)
        {
            Success?.Invoke(e);
        }

        private static ProcessStartInfo StartInfo(Instruction instruction) => new ProcessStartInfo
        {
            Arguments = instruction.ToString(),
            FileName = "ffmpeg",
            CreateNoWindow = true,
            UseShellExecute = false,
            RedirectStandardInput = false,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            WindowStyle = ProcessWindowStyle.Hidden
        };

        private Task<bool> WaitForExitAsync(Process process, CancellationToken token)
        {
            var exitCompleted = new TaskCompletionSource<bool>();

            process.EnableRaisingEvents = true;
            process.Exited += (s, e) => 
                exitCompleted.SetResult(true);

            if (token != default)
                token.Register(exitCompleted.SetCanceled);

            return exitCompleted.Task;
        }
    }
}