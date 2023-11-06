using System.Collections.Generic;

namespace Eddy.ClassGenerator.Lib;

public class IndustryGroup
{
    public string Name { get; set; }
    public List<SegmentData> TransactionSets { get; set; } = new();
}