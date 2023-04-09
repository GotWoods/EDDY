using EdiParser.Attributes;
using EdiParser.Validation;

namespace EdiParser.x12.Models;

[Segment("AM1")]
public class AM1_InformationalValues : EdiX12Segment
{
    [Position(01)] public string CodeCategory { get; set; }

    [Position(02)] public string ProductServiceIDQualifier { get; set; }

    [Position(03)] public string ProductServiceID { get; set; }

    [Position(04)] public decimal? MonetaryAmount { get; set; }

    [Position(05)] public decimal? Quantity { get; set; }

    [Position(06)] public decimal? PercentageAsDecimal { get; set; }

    public override ValidationResult Validate()
    {
        var validator = new BasicValidator<AM1_InformationalValues>(this);
        validator.Required(x => x.CodeCategory);
        validator.Required(x => x.ProductServiceIDQualifier);
        validator.Required(x => x.ProductServiceID);
        validator.Length(x => x.CodeCategory, 2);
        validator.Length(x => x.ProductServiceIDQualifier, 2);
        validator.Length(x => x.ProductServiceID, 1, 80);
        validator.Length(x => x.MonetaryAmount, 1, 18);
        validator.Length(x => x.Quantity, 1, 15);
        validator.Length(x => x.PercentageAsDecimal, 1, 10);
        return validator.Results;
    }
}