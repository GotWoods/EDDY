#nullable enable
using System.Collections.Generic;

namespace Eddy.ClassGenerator.Lib;

public class ParsedTransactionSet
{
    public string SegmentType { get; set; }
    public string ClassName { get; set; }

    public List<ITransactionSetModel> Header { get; set; } = new();
    public List<ITransactionSetModel> Detail { get; set; } = new();
    public List<ITransactionSetModel> Summary { get; set; } = new();

    // public override bool Equals(object obj)
    // {
    //     var compareTo = obj as ParsedSegment;
    //     if (compareTo == null)
    //         return false;
    //
    //     if (this.Items.Count != compareTo.Items.Count)
    //         return false;
    //
    //     for (var index = 0; index < this.Items.Count; index++)
    //     {
    //         if (!this.Items[index].DeepEquals(compareTo.Items[index]))
    //             return false;
    //     }
    //     return true;
    // }
    //
    // public override int GetHashCode()
    // {
    //     return HashCode.Combine(SegmentType, ClassName, Items);
    // }
}