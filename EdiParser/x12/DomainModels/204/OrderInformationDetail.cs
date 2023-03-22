using System.Collections.Generic;
using EdiParser.x12.DomainModels._210;
using EdiParser.x12.Models;

namespace EdiParser.x12.DomainModels._204;

public class OrderInformationDetail
{
    public List<LAD_LadingDetail> LadingInformation { get; set; } = new();
    public List<OrderDetail> OrderDetails { get; set; } = new();
    public OID_OrderInformationDetail Summary { get; set; }
}