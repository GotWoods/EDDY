using System.Collections.Generic;
using EdiParser.Attributes;
using EdiParser.x12.Models;

namespace EdiParser.x12.DomainModels._204;

public class OrderInformationDetail2
{
    [SectionPosition(1)]
    public OID_OrderInformationDetail OrderInformationDetail { get; set; }
    [SectionPosition(2)]
    public List<G62_DateTime> Dates { get; set; } = new();
    
    [SectionPosition(3)]
    public List<LAD_LadingDetail> LadingInformation { get; set; } = new();
}