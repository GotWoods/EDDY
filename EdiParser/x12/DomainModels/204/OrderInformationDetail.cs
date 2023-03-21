using System.Collections.Generic;
using EdiParser.x12.DomainModels._210;

namespace EdiParser.x12.DomainModels._204;

public class OrderInformationDetail
{
    public string ReferenceIdentification { get; set; }
    public string PackagingFormCode { get; set; }
    public decimal? Quantity { get; set; }
    public string WeightUnitCode { get; set; }
    public decimal? Weight { get; set; }
    public string LadingPackagingFormCode { get; set; }
    public List<LadingInformation> LadingInformation { get; set; } = new();
    public string PurchaseOrderNumber { get; set; }
    public List<DescriptionMarksAndNumbers> DescriptionAndMarks { get; set; } = new();
}