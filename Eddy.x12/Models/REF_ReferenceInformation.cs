using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models;

[Segment("REF")]
public class REF_ReferenceInformation : EdiX12Segment
{
    [Position(01)]
    public string ReferenceIdentificationQualifier { get; set; }

    [Position(02)]
    public string ReferenceIdentification { get; set; }

    [Position(03)]
    public string Description { get; set; }

    [Position(04)]
    public C040_ReferenceIdentifier ReferenceIdentifier { get; set; }

    public override ValidationResult Validate()
    {
        var validator = new BasicValidator<REF_ReferenceInformation>(this);
        validator.Required(x => x.ReferenceIdentificationQualifier);
        validator.AtLeastOneIsRequired(x => x.ReferenceIdentification, x => x.Description);
        validator.Length(x => x.ReferenceIdentificationQualifier, 2, 3);
        validator.Length(x => x.ReferenceIdentification, 1, 80);
        validator.Length(x => x.Description, 1, 80);
        return validator.Results;
    }
}