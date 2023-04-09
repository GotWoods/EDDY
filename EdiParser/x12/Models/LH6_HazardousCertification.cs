using EdiParser.Attributes;
using EdiParser.Validation;

namespace EdiParser.x12.Models;

[Segment("LH6")]
public class LH6_HazardousCertification : EdiX12Segment
{
    [Position(01)]
    public string Name { get; set; }

    [Position(02)]
    public string HazardousCertificationCode { get; set; }

    [Position(03)]
    public string HazardousCertificationDeclaration { get; set; }

    [Position(04)]
    public string HazardousCertificationDeclaration2 { get; set; }

    public override ValidationResult Validate()
    {
        var validator = new BasicValidator<LH6_HazardousCertification>(this);
        validator.IfOneIsFilled_AllAreRequired(x => x.HazardousCertificationCode, x => x.HazardousCertificationDeclaration);
        validator.Length(x => x.Name, 1, 60);
        validator.Length(x => x.HazardousCertificationCode, 1);
        validator.Length(x => x.HazardousCertificationDeclaration, 1, 25);
        validator.Length(x => x.HazardousCertificationDeclaration2, 1, 25);
        return validator.Results;
    }
}