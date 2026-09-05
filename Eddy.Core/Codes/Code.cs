using System;
using System.Reflection;

namespace Eddy.Core.Codes;

/// <summary>
/// A code-list-backed identifier value: an X12 or EDIFACT element whose data type is Identifier and
/// whose meaning is described by <typeparamref name="TList"/> (a generated or hand-written
/// <see cref="CodeList"/> subclass). Holds any string - a standard code, a partner-specific override
/// outside the published list, or an empty/unset value - and answers whether it happens to be one of
/// the standard's own codes.
/// </summary>
public sealed class Code<TList> : IEquatable<Code<TList>> where TList : CodeList, new()
{
    private static readonly TList _list = new TList();

    /// <summary>The (single, cached) <typeparamref name="TList"/> instance backing this closed generic type.</summary>
    public static TList List
    {
        get { return _list; }
    }

    /// <summary>The raw value as it appeared (or will appear) in the segment. May be a standard code, a
    /// partner-specific override, or empty.</summary>
    public string Value { get; }

    public Code(string value)
    {
        Value = value;
    }

    /// <summary>Is <see cref="Value"/> one of the standard codes, in any loaded version of the standard?</summary>
    public bool IsStandard
    {
        get { return List.Contains(Value); }
    }

    /// <summary>Is <see cref="Value"/> one of the standard codes in this specific version?</summary>
    public bool IsStandardIn(string version)
    {
        return List.Contains(Value, version);
    }

    /// <summary>Description of <see cref="Value"/> from the loaded catalog, or null when unknown.</summary>
    public string Description
    {
        get { return List.Describe(Value); }
    }

    public static implicit operator Code<TList>(string value)
    {
        return value == null ? null : new Code<TList>(value);
    }

    public static implicit operator string(Code<TList> code)
    {
        return ReferenceEquals(code, null) ? null : code.Value;
    }

    /// <summary>Converts an enum member decorated with <see cref="CodeValueAttribute"/> (or, absent that
    /// attribute, named after the code itself) into a code value.</summary>
    public static implicit operator Code<TList>(Enum value)
    {
        if (value == null)
            return null;

        var name = value.ToString();
        var field = value.GetType().GetField(name, BindingFlags.Public | BindingFlags.Static);
        var attribute = field == null ? null : field.GetCustomAttribute<CodeValueAttribute>();
        var code = attribute != null ? attribute.Code : name;
        return new Code<TList>(code);
    }

    /// <summary>Finds the member of <typeparamref name="TEnum"/> whose <see cref="CodeValueAttribute"/>
    /// (or, absent that attribute, name) matches <see cref="Value"/>.</summary>
    public bool TryGetEnum<TEnum>(out TEnum result) where TEnum : struct, Enum
    {
        foreach (var field in typeof(TEnum).GetFields(BindingFlags.Public | BindingFlags.Static))
        {
            var attribute = field.GetCustomAttribute<CodeValueAttribute>();
            var code = attribute != null ? attribute.Code : field.Name;
            if (string.Equals(code, Value, StringComparison.Ordinal))
            {
                result = (TEnum)field.GetValue(null);
                return true;
            }
        }

        result = default(TEnum);
        return false;
    }

    public static bool operator ==(Code<TList> left, Code<TList> right)
    {
        if (ReferenceEquals(left, right))
            return true;
        if (ReferenceEquals(left, null) || ReferenceEquals(right, null))
            return false;
        return string.Equals(left.Value, right.Value, StringComparison.Ordinal);
    }

    public static bool operator !=(Code<TList> left, Code<TList> right)
    {
        return !(left == right);
    }

    public static bool operator ==(Code<TList> left, string right)
    {
        if (ReferenceEquals(left, null))
            return right == null;
        return string.Equals(left.Value, right, StringComparison.Ordinal);
    }

    public static bool operator !=(Code<TList> left, string right)
    {
        return !(left == right);
    }

    public static bool operator ==(string left, Code<TList> right)
    {
        return right == left;
    }

    public static bool operator !=(string left, Code<TList> right)
    {
        return !(right == left);
    }

    public bool Equals(Code<TList> other)
    {
        if (ReferenceEquals(other, null))
            return false;
        return string.Equals(Value, other.Value, StringComparison.Ordinal);
    }

    public override bool Equals(object obj)
    {
        return Equals(obj as Code<TList>);
    }

    public override int GetHashCode()
    {
        return Value == null ? 0 : StringComparer.Ordinal.GetHashCode(Value);
    }

    public override string ToString()
    {
        return Value;
    }
}
