using System.Collections.Generic;

namespace EdiParser.x12.DomainModels._210;

public class StopDetails
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