namespace Eddy.MetadataTool;

/// <summary>Plain argument parsing: "--flag value" pairs plus a list of positional arguments
/// (anything not preceded by a "--flag"). Good enough for this tool's five subcommands without
/// pulling in System.CommandLine.</summary>
public sealed class Args
{
    private readonly Dictionary<string, string> _options;
    public List<string> Positional { get; }

    private Args(Dictionary<string, string> options, List<string> positional)
    {
        _options = options;
        Positional = positional;
    }

    public static Args Parse(IReadOnlyList<string> args)
    {
        var options = new Dictionary<string, string>(StringComparer.Ordinal);
        var positional = new List<string>();
        for (var i = 0; i < args.Count; i++)
        {
            var arg = args[i];
            if (arg.StartsWith("--", StringComparison.Ordinal))
            {
                var name = arg[2..];
                if (i + 1 >= args.Count)
                    throw new FormatException($"option --{name} requires a value");
                options[name] = args[++i];
            }
            else
            {
                positional.Add(arg);
            }
        }
        return new Args(options, positional);
    }

    public string Require(string name) =>
        _options.TryGetValue(name, out var value) ? value : throw new FormatException($"missing required option --{name}");

    public string? Optional(string name) => _options.GetValueOrDefault(name);
}
