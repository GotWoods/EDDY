using Eddy.Core.Attributes;
using Eddy.x12.Models;

namespace Eddy.x12.DomainModels._4010._830;

public class Item
{
    [SectionPosition(1)] public LIN_ItemIdentification ItemIdentification { get; set; }
    //[SectionPosition(2)] public UIT
    [SectionPosition(3)] DTM_DateTimeReference dateTimeReferences { get; set; }
    //[SectionPosition(1)] PO3
}