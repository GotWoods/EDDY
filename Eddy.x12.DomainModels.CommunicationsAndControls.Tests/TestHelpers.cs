using System;
using System.Collections.Generic;
using System.Linq;

namespace Eddy.x12.DomainModels.CommunicationsAndControls.Tests;

public static class TestHelpers
{
    /// <summary>Splits generated (or sample) EDI text into its individual segment lines, in order.</summary>
    public static List<string> Segments(string text)
    {
        return text.Split('\n')
            .Select(s => s.TrimEnd('\r'))
            .Where(s => s.Length > 0)
            .ToList();
    }

    /// <summary>All segment lines whose identifier (before the first '*') equals <paramref name="identifier"/>, in order.</summary>
    public static List<string> SegmentsOf(string text, string identifier)
    {
        return Segments(text).Where(s => s == identifier || s.StartsWith(identifier + "*", StringComparison.Ordinal)).ToList();
    }

    public static string SingleSegmentOf(string text, string identifier)
    {
        return SegmentsOf(text, identifier).Single();
    }
}
