using System;

namespace FluentFFmpeg.Core.Events;

public class InfoEventArgs : EventArgs
{
    internal InfoEventArgs(string args)
    {
        Info = args;
    }

    public string Info { get; }

    public override string ToString() => Info;
}