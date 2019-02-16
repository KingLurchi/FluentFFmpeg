using System;
using System.Globalization;
using FluentFFmpeg.Core.Options;

namespace FluentFFmpeg.Core.Constants
{
    public static class Options
    {
        public static class Global
        {
            public static readonly GlobalOption HideBanner = new GlobalOption("hide_banner");
            public static readonly GlobalOption NoStats = new GlobalOption("nostats");
            public static readonly GlobalOption Stats = new GlobalOption("stats");
            public static GlobalOption OverwriteOutput(bool overwrite) => new GlobalOption(overwrite ? "y" : "n");
        }

        public static class Input
        {
            public static InputOption Codec(string streamSpecifier, string codec) => new InputOption("c", streamSpecifier, codec);
            public static InputOption F(string format) => new InputOption("f", format);
            public static InputOption Ss(double duration) => new InputOption("ss", duration.ToString(CultureInfo.InvariantCulture));
            public static InputOption Ss(TimeSpan duration) => new InputOption("ss", duration.ToString("c"));
            public static InputOption StreamLoop(int number) => new InputOption("stream_loop", number.ToString());
            public static InputOption T(double duration) => new InputOption("t", duration.ToString(CultureInfo.InvariantCulture));
            public static InputOption T(TimeSpan duration) => new InputOption("t", duration.ToString("c"));
        }

        public static class Output
        {
            public static OutputOption Codec(string streamSpecifier, string codec) => new OutputOption("c", streamSpecifier, codec);
            public static OutputOption Crf(int number) => new OutputOption("crf", number.ToString());
            public static OutputOption F(string format) => new OutputOption("f", format);
            public static OutputOption Map(int stream, string channel) => new OutputOption("map", stream.ToString(), channel);
            public static OutputOption Movflags() => new OutputOption("movflags", "faststart");
            public static OutputOption Preset(string preset) => new OutputOption("preset", preset);
            public static OutputOption Ss(double duration) => new OutputOption("ss", duration.ToString(CultureInfo.InvariantCulture));
            public static OutputOption Ss(TimeSpan duration) => new OutputOption("ss", duration.ToString("c"));
            public static OutputOption T(double duration) => new OutputOption("t", duration.ToString(CultureInfo.InvariantCulture));
            public static OutputOption T(TimeSpan duration) => new OutputOption("t", duration.ToString("c"));
        }

        public static class Support
        {
            public static readonly SupportOption Bsfs = new SupportOption("bsfs");
            public static readonly SupportOption Codecs = new SupportOption("codecs");
            public static readonly SupportOption Decoders = new SupportOption("decoders");
            public static readonly SupportOption Demuxers = new SupportOption("demuxers");
            public static readonly SupportOption Devices = new SupportOption("devices");
            public static readonly SupportOption Encoders = new SupportOption("encoders");
            public static readonly SupportOption Filters = new SupportOption("filters");
            public static readonly SupportOption Formats = new SupportOption("formats");
            public static SupportOption Help(string arg = null) => new SupportOption("-help", arg);
            public static readonly SupportOption License = new SupportOption("L");
            public static readonly SupportOption Muxers = new SupportOption("Muxers");
            public static readonly SupportOption PixFmts = new SupportOption("pix_fmts");
            public static readonly SupportOption Protocols = new SupportOption("protocols");
            public static readonly SupportOption SampleFmts = new SupportOption("sample_fmts");
            public static readonly SupportOption Version = new SupportOption("version");
        }
    }
}