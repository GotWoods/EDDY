using System.Collections.Generic;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.DomainModels._4010._214;

public class OrderDetail
{
    public OID_OrderIdentificationDetail Detail { get; set; }
    public List<SDQ_DestinationQuantity> DestinationQuantity { get; set; } = new();
}