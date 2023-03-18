using EdiParser.Attributes;
using EdiParser.Validation;

namespace EdiParser.EdiFact.Models.Elements;

public class C519_RelatedLocationOneIdentification : IElement
{
    [Position(1)]
    public string FirstRelatedLocationIdentifier { get; set; }

    [Position(2)]
    public string CodeListIdentificationCode { get; set; }

    [Position(3)]
    public string CodeListResponsibleAgencyCode { get; set; }

    [Position(4)]
    public string FirstRelatedLocationName { get; set; }

    public void Validate()
    {
        var validator = new BasicValidator<C519_RelatedLocationOneIdentification>(this);
        validator.Length(x => x.FirstRelatedLocationIdentifier, 1, 35);
        validator.Length(x => x.CodeListIdentificationCode, 1, 17);
        validator.Length(x => x.CodeListResponsibleAgencyCode, 1, 3);
        validator.Length(x => x.FirstRelatedLocationName, 1, 70);
    }
}