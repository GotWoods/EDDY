namespace Eddy.MetadataTool;

/// <summary>Plain argument parsing: "--flag value" pairs (repeatable - later occurrences append rather
/// than overwrite), boolean "--flag" switches named in <paramref name="flagNames"/>, plus a list of
/// positional arguments (anything not preceded by a "--flag"). Good enough for this tool's subcommands
/// without pulling in System.CommandLine.</summary>
public sealed class Args
{
    private readonly Dictionary<string, List<string>> _options;
    private readonly HashSet<string> _flags;
    public List<string> Positional { get; }

    private Args(Dictionary<string, List<string>> options, HashSet<string> flags, List<string> positional)
    {
        _options = options;
        _flags = flags;
        Positional = positional;
    }

    public static Args Parse(IReadOnlyList<string> args, IReadOnlySet<string>? flagNames = null)
    {
        var options = new Dictionary<string, List<string>>(StringComparer.Ordinal);
        var flags = new HashSet<string>(StringComparer.Ordinal);
        var positional = new List<string>();
        for (var i = 0; i < args.Count; i++)
        {
            var arg = args[i];
            if (arg.StartsWith("--", StringComparison.Ordinal))
            {
                var name = arg[2..];
                if (flagNames != null && flagNames.Contains(name))
                {
                    flags.Add(name);
                    continue;
                }

                if (i + 1 >= args.Count)
                    throw new FormatException($"option --{name} requires a value");

                if (!options.TryGetValue(name, out var list))
                    options[name] = list = new List<string>();
                list.Add(args[++i]);
            }
            else
            {
                positional.Add(arg);
            }
        }
        return new Args(options, flags, positional);
    }

    public string Require(string name) =>
        _options.TryGetValue(name, out var values) ? values[0] : throw new FormatException($"missing required option --{name}");

    public string? Optional(string name) => _options.TryGetValue(name, out var values) ? values[0] : null;

    /// <summary>Every value given for a (possibly repeated) "--name value" option, in order given. Empty
    /// when the option was never given.</summary>
    public List<string> RequireAll(string name)
    {
        if (!_options.TryGetValue(name, out var values) || values.Count == 0)
            throw new FormatException($"missing required option --{name}");
        return values;
    }

    /// <summary>Whether a boolean "--name" switch (declared via <see cref="Parse"/>'s flagNames) was given.</summary>
    public bool Flag(string name) => _flags.Contains(name);
}
