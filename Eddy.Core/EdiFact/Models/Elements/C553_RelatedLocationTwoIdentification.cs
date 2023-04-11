using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Core.EdiFact.Models.Elements;

public class C553_RelatedLocationTwoIdentification : IElement
{
    [Position(1)]
    public string SecondRelatedLocationIdentifier { get; set; }

    [Position(2)]
    public string CodeListIdentificationCode { get; set; }

    [Position(3)]
    public string CodeListResponsibleAgencyCode { get; set; }

    [Position(4)]
    public string SecondRelatedLocationName { get; set; }

    public void Validate()
    {
        var validator = new BasicValidator<C553_RelatedLocationTwoIdentification>(this);
        validator.Length(x => x.SecondRelatedLocationIdentifier, 1, 35);
        validator.Length(x => x.CodeListIdentificationCode, 1, 17);
        validator.Length(x => x.CodeListResponsibleAgencyCode, 1, 3);
        validator.Length(x => x.SecondRelatedLocationName, 1, 70);
    }
}