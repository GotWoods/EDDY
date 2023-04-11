using System.Collections.Generic;
using Eddy.x12.Models;

namespace Eddy.x12;

public class Section
{
    public string SectionType { get; set; }
    public List<EdiX12Segment> Segments { get; set; } = new();
    public string TransactionSetControlNumber { get; set; }
}