using System.Collections.Generic;
using EdiParser.x12.Internals;
using EdiParser.x12.Models;

namespace EdiParser.x12;

public class Section
{
    public string SectionType { get; set; }
    public List<EdiX12Segment> Segments { get; set; } = new();
    public string TransactionSetControlNumber { get; set; }
}