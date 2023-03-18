using System.Collections.Generic;

namespace EdiParser.ClassGenerator.Lib;

public class ValidationData
{
    public string FirstFieldPosition { get; set; }
    public List<string> OtherFields { get; set; } = new();

    public List<string> GetAllFieldDataOrdered()
    {
        var result = new List<string>();
        result.Add(FirstFieldPosition);
        result.AddRange(OtherFields);
        return result;
    }

    public ValidationData()
    {
    }
}