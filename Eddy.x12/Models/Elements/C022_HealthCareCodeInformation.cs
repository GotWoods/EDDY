using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.x12.Models.Elements;

[Segment("C022")]
public class C022_HealthCareCodeInformation : EdiX12Component
{
    [Position(00)]
    public string CodeListQualifierCode { get; set; }

    [Position(01)]
    public string IndustryCode { get; set; }

    [Position(02)]
    public string DateTimePeriodFormatQualifier { get; set; }

    [Position(03)]
    public string DateTimePeriod { get; set; }

    [Position(04)]
    public decimal? MonetaryAmount { get; set; }

    [Position(05)]
    public decimal? Quantity { get; set; }

    [Position(06)]
    public string VersionIdentifier { get; set; }

    [Position(07)]
    public string IndustryCode2 { get; set; }

    [Position(08)]
    public string IndustryCode3 { get; set; }

    [Position(09)]
    public string IndustryCode4 { get; set; }

    public override ValidationResult Validate()
    {
        var validator = new BasicValidator<C022_HealthCareCodeInformation>(this);
        validator.Required(x => x.CodeListQualifierCode);
        validator.Required(x => x.IndustryCode);
        validator.IfOneIsFilled_AllAreRequired(x => x.DateTimePeriodFormatQualifier, x => x.DateTimePeriod);
        validator.OnlyOneOf(x => x.IndustryCode2, x => x.IndustryCode3);
        validator.Length(x => x.CodeListQualifierCode, 1, 3);
        validator.Length(x => x.IndustryCode, 1, 30);
        validator.Length(x => x.DateTimePeriodFormatQualifier, 2, 3);
        validator.Length(x => x.DateTimePeriod, 1, 35);
        validator.Length(x => x.MonetaryAmount, 1, 18);
        validator.Length(x => x.Quantity, 1, 15);
        validator.Length(x => x.VersionIdentifier, 1, 30);
        validator.Length(x => x.IndustryCode2, 1, 30);
        validator.Length(x => x.IndustryCode3, 1, 30);
        validator.Length(x => x.IndustryCode4, 1, 30);
        return validator.Results;
    }
}