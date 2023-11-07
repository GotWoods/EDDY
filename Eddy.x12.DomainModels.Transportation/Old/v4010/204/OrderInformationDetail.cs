using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.DomainModels.Transportation.v4010._204;

public class OrderInformationDetail
{
    [SectionPosition(1)]
    public OID_OrderIdentificationDetail Detail { get; set; }
    [SectionPosition(2)]
    public List<G62_DateTime> Dates { get; set; } = new();
    
    [SectionPosition(3)]
    public List<LAD_LadingDetail> LadingInformation { get; set; } = new();

    // [SectionPosition(4)] //starts with L5
    // public List<OrderInformationShipmentData> OrderInformationShipmentData { get; set; } = new();
}