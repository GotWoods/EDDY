using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.x12.Models.Elements;

[Segment("C040")]
public class C040_ReferenceIdentifier : EdiX12Component
{
    [Position(00)]
    public string ReferenceIdentificationQualifier { get; set; }

    [Position(01)]
    public string ReferenceIdentification { get; set; }

    [Position(02)]
    public string ReferenceIdentificationQualifier2 { get; set; }

    [Position(03)]
    public string ReferenceIdentification2 { get; set; }

    [Position(04)]
    public string ReferenceIdentificationQualifier3 { get; set; }

    [Position(05)]
    public string ReferenceIdentification3 { get; set; }

    public override ValidationResult Validate()
    {
        var validator = new BasicValidator<C040_ReferenceIdentifier>(this);
        validator.Required(x => x.ReferenceIdentificationQualifier);
        validator.Required(x => x.ReferenceIdentification);
        validator.IfOneIsFilled_AllAreRequired(x => x.ReferenceIdentificationQualifier2, x => x.ReferenceIdentification2);
        validator.IfOneIsFilled_AllAreRequired(x => x.ReferenceIdentificationQualifier3, x => x.ReferenceIdentification3);
        validator.Length(x => x.ReferenceIdentificationQualifier, 2, 3);
        validator.Length(x => x.ReferenceIdentification, 1, 80);
        validator.Length(x => x.ReferenceIdentificationQualifier2, 2, 3);
        validator.Length(x => x.ReferenceIdentification2, 1, 80);
        validator.Length(x => x.ReferenceIdentificationQualifier3, 2, 3);
        validator.Length(x => x.ReferenceIdentification3, 1, 80);
        return validator.Results;
    }
}