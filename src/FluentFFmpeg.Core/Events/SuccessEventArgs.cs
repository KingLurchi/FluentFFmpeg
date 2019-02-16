using System;

namespace FluentFFmpeg.Core.Events
{
    public class SuccessEventArgs : EventArgs
    {
        internal SuccessEventArgs(bool success)
        {
            Success = success;
        }

        public bool Success { get; }
    }
}