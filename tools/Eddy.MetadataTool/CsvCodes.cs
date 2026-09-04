namespace Eddy.MetadataTool;

/// <summary>Minimal CSV reader for the "dataElement,code,description" format used by
/// import-codes. Supports double-quoted fields with "" as an escaped quote, which is enough for
/// hand-authored or spreadsheet-exported code tables without pulling in a CSV library.</summary>
public static class CsvCodes
{
    public sealed record Row(string DataElement, string Code, string Description);

    public static IEnumerable<Row> Read(string path)
    {
        using var reader = new StreamReader(path);
        string? headerLine = reader.ReadLine();
        if (headerLine is null) yield break;

        var header = SplitLine(headerLine);
        var dataElementIndex = IndexOf(header, "dataElement");
        var codeIndex = IndexOf(header, "code");
        var descriptionIndex = IndexOf(header, "description");
        if (dataElementIndex < 0 || codeIndex < 0 || descriptionIndex < 0)
            throw new FormatException($"{path}: header must contain dataElement,code,description (found: {headerLine})");

        string? line;
        while ((line = reader.ReadLine()) is not null)
        {
            if (line.Length == 0) continue;
            var fields = SplitLine(line);
            if (fields.Count <= Math.Max(dataElementIndex, Math.Max(codeIndex, descriptionIndex))) continue;
            yield return new Row(fields[dataElementIndex], fields[codeIndex], fields[descriptionIndex]);
        }
    }

    private static int IndexOf(List<string> header, string name) =>
        header.FindIndex(h => string.Equals(h.Trim(), name, StringComparison.OrdinalIgnoreCase));

    private static List<string> SplitLine(string line)
    {
        var fields = new List<string>();
        var current = new System.Text.StringBuilder();
        var inQuotes = false;
        for (var i = 0; i < line.Length; i++)
        {
            var c = line[i];
            if (inQuotes)
            {
                if (c == '"')
                {
                    if (i + 1 < line.Length && line[i + 1] == '"')
                    {
                        current.Append('"');
                        i++;
                    }
                    else
                    {
                        inQuotes = false;
                    }
                }
                else
                {
                    current.Append(c);
                }
            }
            else
            {
                if (c == '"')
                    inQuotes = true;
                else if (c == ',')
                {
                    fields.Add(current.ToString());
                    current.Clear();
                }
                else
                    current.Append(c);
            }
        }
        fields.Add(current.ToString());
        return fields;
    }
}
