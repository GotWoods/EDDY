using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.Elements;

public class C107_TextReference : IElement
{
    [Position(1)]
    public string FreeTextDescriptionCode { get; set; }

    [Position(2)]
    public string CodeListIdentificationCode { get; set; }

    [Position(3)]
    public string CodeListResponsibleAgencyCode { get; set; }

    public void Validate()
    {
        var validator = new BasicValidator<C107_TextReference>(this);
        validator.Length(x => x.FreeTextDescriptionCode, 1, 17);
        validator.Length(x => x.CodeListIdentificationCode, 1, 17);
        validator.Length(x => x.CodeListResponsibleAgencyCode, 1, 3);
    }
}