using System;
using System.IO;

namespace Eddy.x12.DomainModels.CommunicationsAndControls.Tests;

/// <summary>Loads and mutates the 204 sample used across the acknowledgment builder tests.</summary>
public static class SampleData
{
    public static string LoadClean204()
    {
        var path = Path.Combine(AppContext.BaseDirectory, "Fixtures", "Sample-204-LoadTender.edi");
        return File.ReadAllText(path);
    }

    /// <summary>Blanks N101 (EntityIdentifierCode), which is required -- produces one AK3/AK4 element error.</summary>
    public static string With204N101Blanked()
    {
        var text = LoadClean204();
        var original = "N1*PF*XYZ CORP*9*9995555500000";
        var mutated = "N1**XYZ CORP*9*9995555500000";
        if (!text.Contains(original))
            throw new InvalidOperationException("Sample fixture did not contain the expected N1 segment to mutate.");
        return text.Replace(original, mutated);
    }

    /// <summary>Corrupts the SE segment count so it no longer matches the actual number of segments.</summary>
    public static string With204WrongSegmentCount()
    {
        var text = LoadClean204();
        var original = "SE*16*0001";
        var mutated = "SE*4*0001";
        if (!text.Contains(original))
            throw new InvalidOperationException("Sample fixture did not contain the expected SE segment to mutate.");
        return text.Replace(original, mutated);
    }

    /// <summary>Inserts a segment identifier that is not registered for any version -- an unknown segment.</summary>
    public static string With204UnknownSegment()
    {
        var text = LoadClean204();
        var original = "B2A*04\n";
        var mutated = "B2A*04\nZZZ*UNKNOWN\n";
        if (!text.Contains(original))
            throw new InvalidOperationException("Sample fixture did not contain the expected B2A segment to mutate.");
        // SE's segment count must grow by one to match, so the unknown segment is the only problem being tested.
        return text.Replace(original, mutated).Replace("SE*16*0001", "SE*17*0001");
    }

    /// <summary>Duplicates the ST..SE transaction set within the same functional group, giving it a second control number.</summary>
    public static string With204TwoTransactionSets()
    {
        var text = LoadClean204();
        var stStart = text.IndexOf("ST*204*0001", StringComparison.Ordinal);
        var seMarker = "SE*16*0001\n";
        var seEnd = text.IndexOf(seMarker, StringComparison.Ordinal);
        if (stStart < 0 || seEnd < 0)
            throw new InvalidOperationException("Sample fixture did not contain the expected ST/SE transaction set to duplicate.");

        var transactionSetText = text.Substring(stStart, seEnd + seMarker.Length - stStart);
        var secondTransactionSetText = transactionSetText.Replace("0001", "0002");

        var insertAt = seEnd + seMarker.Length;
        var withSecondTransaction = text.Substring(0, insertAt) + secondTransactionSetText + text.Substring(insertAt);

        return withSecondTransaction.Replace("GE*1*2100", "GE*2*2100");
    }

    /// <summary>Rewrites the sample's ISA12/GS08 so it parses as a 005010 document instead of 004010.</summary>
    public static string As5010(string text)
    {
        return text
            .Replace("*00401*", "*00501*")
            .Replace("*004010\n", "*005010\n");
    }
}
