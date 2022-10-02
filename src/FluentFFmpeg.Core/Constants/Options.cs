using System;
using System.Globalization;
using FluentFFmpeg.Core.Options;

namespace FluentFFmpeg.Core.Constants;

public static class Options
{
    public static class Global
    {
        public static readonly GlobalOption HideBanner = new("hide_banner");
        public static readonly GlobalOption NoStats = new("nostats");
        public static readonly GlobalOption Stats = new("stats");
        public static GlobalOption OverwriteOutput(bool overwrite) => new(overwrite ? "y" : "n");
    }

    public static class Input
    {
        public static InputOption Codec(string streamSpecifier, string codec) => new("c", streamSpecifier, codec);
        public static InputOption F(string format) => new("f", format);
        public static InputOption Ss(double duration) => new("ss", duration.ToString(CultureInfo.InvariantCulture));
        public static InputOption Ss(TimeSpan duration) => new("ss", duration.ToString("c"));
        public static InputOption StreamLoop(int number) => new("stream_loop", number.ToString());
        public static InputOption T(double duration) => new("t", duration.ToString(CultureInfo.InvariantCulture));
        public static InputOption T(TimeSpan duration) => new("t", duration.ToString("c"));
    }

    public static class Output
    {
        public static OutputOption Codec(string streamSpecifier, string codec) => new("c", streamSpecifier, codec);
        public static OutputOption Crf(int number) => new("crf", number.ToString());
        public static OutputOption F(string format) => new("f", format);
        public static OutputOption Map(int stream, string channel) => new("map", stream.ToString(), channel);
        public static OutputOption Movflags() => new("movflags", "faststart");
        public static OutputOption Preset(string preset) => new("preset", preset);
        public static OutputOption Ss(double duration) => new("ss", duration.ToString(CultureInfo.InvariantCulture));
        public static OutputOption Ss(TimeSpan duration) => new("ss", duration.ToString("c"));
        public static OutputOption T(double duration) => new("t", duration.ToString(CultureInfo.InvariantCulture));
        public static OutputOption T(TimeSpan duration) => new("t", duration.ToString("c"));
    }

    public static class Support
    {
        public static readonly SupportOption Bsfs = new("bsfs");
        public static readonly SupportOption Codecs = new("codecs");
        public static readonly SupportOption Decoders = new("decoders");
        public static readonly SupportOption Demuxers = new("demuxers");
        public static readonly SupportOption Devices = new("devices");
        public static readonly SupportOption Encoders = new("encoders");
        public static readonly SupportOption Filters = new("filters");
        public static readonly SupportOption Formats = new("formats");
        public static SupportOption Help(string arg = null) => new("-help", arg);
        public static readonly SupportOption License = new("L");
        public static readonly SupportOption Muxers = new("Muxers");
        public static readonly SupportOption PixFmts = new("pix_fmts");
        public static readonly SupportOption Protocols = new("protocols");
        public static readonly SupportOption SampleFmts = new("sample_fmts");
        public static readonly SupportOption Version = new("version");
    }
}