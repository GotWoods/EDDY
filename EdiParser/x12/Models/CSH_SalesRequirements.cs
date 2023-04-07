using EdiParser.Attributes;
using EdiParser.Validation;
using EdiParser.x12.Internals;

namespace EdiParser.x12.Models;

[Segment("CSH")]
public class CSH_SalesRequirements : EdiX12Segment
{
    [Position(01)]
    public string SalesRequirementCode { get; set; }

    [Position(02)]
    public string ActionCode { get; set; }

    [Position(03)]
    public string Amount { get; set; }

    [Position(04)]
    public string AccountNumber { get; set; }

    [Position(05)]
    public string Date { get; set; }

    [Position(06)]
    public string AgencyQualifierCode { get; set; }

    [Position(07)]
    public string SpecialServicesCode { get; set; }

    [Position(08)]
    public string ProductServiceSubstitutionCode { get; set; }

    [Position(09)]
    public decimal? PercentageAsDecimal { get; set; }

    [Position(10)]
    public string PercentQualifier { get; set; }

    public override ValidationResult Validate()
    {
        var validator = new BasicValidator<CSH_SalesRequirements>(this);
        validator.ARequiresB(x => x.ActionCode, x => x.Amount);
        validator.IfOneIsFilled_AllAreRequired(x => x.AgencyQualifierCode, x => x.SpecialServicesCode);
        validator.IfOneIsFilled_AllAreRequired(x => x.PercentageAsDecimal, x => x.PercentQualifier);
        validator.Length(x => x.SalesRequirementCode, 1, 2);
        validator.Length(x => x.ActionCode, 1, 2);
        validator.Length(x => x.Amount, 1, 15);
        validator.Length(x => x.AccountNumber, 1, 35);
        validator.Length(x => x.Date, 8);
        validator.Length(x => x.AgencyQualifierCode, 2);
        validator.Length(x => x.SpecialServicesCode, 2, 10);
        validator.Length(x => x.ProductServiceSubstitutionCode, 1, 2);
        validator.Length(x => x.PercentageAsDecimal, 1, 10);
        validator.Length(x => x.PercentQualifier, 1, 2);
        return validator.Results;
    }
}