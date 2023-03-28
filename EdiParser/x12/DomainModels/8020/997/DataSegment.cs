using System.Collections.Generic;
using EdiParser.Attributes;
using EdiParser.x12.Models;

namespace EdiParser.x12.DomainModels._8020._997;

public class DataSegment
{
    [SectionPosition(1)]
    public AK3_DataSegmentNote DataSegmentNote { get; set; }

    [SectionPosition(2)]
    public List<AK4_DataElementNote> DataElementNote { get; set; } = new();

}