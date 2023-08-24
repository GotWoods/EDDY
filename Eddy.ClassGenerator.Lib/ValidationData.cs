using System;
using System.Collections.Generic;

namespace Eddy.ClassGenerator.Lib;

public class ValidationData : IEquatable<ValidationData>
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

    public bool Equals(ValidationData other)
    {
        if (other == null) return false;

        if (FirstFieldPosition != other.FirstFieldPosition) return false;

        if (OtherFields.Count != other.OtherFields.Count) return false;

        for (int i = 0; i < OtherFields.Count; i++)
        {
            if (OtherFields[i] != other.OtherFields[i]) return false;
        }
        return true;
    }


    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((ValidationData)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(FirstFieldPosition, OtherFields);
    }
}