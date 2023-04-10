using EdiParser.Attributes;
using EdiParser.Validation;

namespace EdiParser.x12.Models.Elements;

[Segment("C056")]
public class C056_CompositeRaceOrEthnicityInformation : EdiX12Component
{
    [Position(00)]
    public string RaceOrEthnicityCode { get; set; }

    [Position(01)]
    public string CodeListQualifierCode { get; set; }

    [Position(02)]
    public string IndustryCode { get; set; }

    public override ValidationResult Validate()
    {
        var validator = new BasicValidator<C056_CompositeRaceOrEthnicityInformation>(this);
        validator.IfOneIsFilled_AllAreRequired(x => x.CodeListQualifierCode, x => x.IndustryCode);
        validator.Length(x => x.RaceOrEthnicityCode, 1);
        validator.Length(x => x.CodeListQualifierCode, 1, 3);
        validator.Length(x => x.IndustryCode, 1, 30);
        return validator.Results;
    }
}