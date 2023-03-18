using EdiParser.x12.Models;

namespace EdiParser.x12.DomainModels._210;

public class DescriptionMarksAndNumbers
{
    public int? LadingLineItemNumber { get; set; }
    public string Description { get; set; }
    public string CommodityCode { get; set; }
    public string CommodityCodeQualifier { get; set; }
    public string PackagingCode { get; set; }
    public string MarksAndNumbers { get; set; }
    public string MarksAndNumberQualifier { get; set; }

    public string CommodityCode2 { get; set; }
    public string CommodityCodeQualifier2 { get; set; }
    public string CompartmentIdCode { get; set; }
    public static DescriptionMarksAndNumbers CreateFromL5(L5_DescriptionMarksAndNumbers input)
    {
        return new DescriptionMarksAndNumbers
        {
            LadingLineItemNumber = input.LadingLineItemNumber,
            Description = input.LadingDescription,
            CommodityCode = input.CommodityCode,
            CommodityCodeQualifier = input.CommodityCodeQualifier,
            PackagingCode = input.PackagingCode,
            MarksAndNumbers = input.MarksAndNumbers,
            MarksAndNumberQualifier = input.MarksAndNumbersQualifier,
            CommodityCode2 = input.CommodityCode2,
            CommodityCodeQualifier2 = input.CommodityCodeQualifier2,
            CompartmentIdCode = input.CompartmentIDCode
        };
    }

    public L5_DescriptionMarksAndNumbers ToL5()
    {
        return new L5_DescriptionMarksAndNumbers()
        {
            LadingLineItemNumber = this.LadingLineItemNumber,
            LadingDescription= this.Description,
            CommodityCode = this.CommodityCode,
            CommodityCodeQualifier = this.CommodityCodeQualifier,
            PackagingCode = this.PackagingCode,
            MarksAndNumbers = this.MarksAndNumbers,
            MarksAndNumbersQualifier = this.MarksAndNumberQualifier,
            CommodityCode2 = this.CommodityCode2,
            CommodityCodeQualifier2 = this.CommodityCodeQualifier2,
            CompartmentIDCode = this.CompartmentIdCode
        };
    }


}