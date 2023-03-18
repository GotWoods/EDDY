using System.Collections.Generic;
using EdiParser.x12.Models;

namespace EdiParser.x12.DomainModels._210;

public class LadingInformation
{
    public string PackagingFormCode { get; set; }
    public int? Quantity { get; set; }
    public string WeightUnitCode { get; set; }
    public decimal? UnitWeight{ get; set; }
    public decimal? Weight { get; set; }

    public List<KeyValuePair<string, string>> Products { get; set; }

    public string ProductServiceIdQualifier { get; set; }
    public string ProductServiceId { get; set; }
    public string ProductServiceId2 { get; set; }
    public string ProductServiceIdQualifier2 { get; set; }
    public string ProductServiceId3 { get; set; }
    public string ProductServiceIdQualifier3 { get; set; }
    
    public static LadingInformation FromLAD(LAD_LadingDetail input)
    {
        var result = new LadingInformation();
        result.PackagingFormCode = input.PackagingFormCode;
        result.Weight = input.Weight;
        result.WeightUnitCode = input.WeightUnitCode;
        result.Quantity = input.LadingQuantity;
        result.UnitWeight = input.UnitWeight;
        
        //TODO: put this into Products
        result.ProductServiceIdQualifier = input.ProductServiceIDQualifier;
        result.ProductServiceId = input.ProductServiceID;
        result.ProductServiceIdQualifier2 = input.ProductServiceIDQualifier2;
        result.ProductServiceId2 = input.ProductServiceID2;
        result.ProductServiceIdQualifier3 = input.ProductServiceIDQualifier3;
        result.ProductServiceId3 = input.ProductServiceID3;
        return result;
    }

    public LAD_LadingDetail ToLAD()
    {
        var result = new LAD_LadingDetail();
        result.PackagingFormCode = PackagingFormCode;
        result.Weight = Weight;
        result.WeightUnitCode = WeightUnitCode;
        result.LadingQuantity = Quantity;
        result.UnitWeight = UnitWeight;
        result.ProductServiceIDQualifier = ProductServiceIdQualifier;
        result.ProductServiceID = ProductServiceId;
        result.ProductServiceIDQualifier2 = ProductServiceIdQualifier2;
        result.ProductServiceID2 = ProductServiceId2;
        result.ProductServiceIDQualifier3 = ProductServiceIdQualifier3;
        result.ProductServiceID3 = ProductServiceId3;
        return result;
    }
}