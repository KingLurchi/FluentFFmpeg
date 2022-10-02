using System;

namespace FluentFFmpeg.Core.Events;

public class ExceptionEventArgs : EventArgs
{
    internal ExceptionEventArgs(Exception e)
    {
        Exception = e;
    }

    public Exception Exception { get; }
}