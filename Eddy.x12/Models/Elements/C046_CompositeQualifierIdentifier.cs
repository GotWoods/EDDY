using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.x12.Models.Elements;

[Segment("C046")]
public class C046_CompositeQualifierIdentifier : EdiX12Component
{
    [Position(00)]
    public string RateValueQualifier { get; set; }

    [Position(01)]
    public string RateValueQualifier2 { get; set; }

    [Position(02)]
    public string RateValueQualifier3 { get; set; }

    [Position(03)]
    public string RateValueQualifier4 { get; set; }

    [Position(04)]
    public string RateValueQualifier5 { get; set; }

    public override ValidationResult Validate()
    {
        var validator = new BasicValidator<C046_CompositeQualifierIdentifier>(this);
        validator.Required(x => x.RateValueQualifier);
        validator.Length(x => x.RateValueQualifier, 2);
        validator.Length(x => x.RateValueQualifier2, 2);
        validator.Length(x => x.RateValueQualifier3, 2);
        validator.Length(x => x.RateValueQualifier4, 2);
        validator.Length(x => x.RateValueQualifier5, 2);
        return validator.Results;
    }
}