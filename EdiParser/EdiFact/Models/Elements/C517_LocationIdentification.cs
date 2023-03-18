using EdiParser.Attributes;
using EdiParser.Validation;

namespace EdiParser.EdiFact.Models.Elements;

public class C517_LocationIdentification : IElement
{
    [Position(1)]
    public string LocationIdentifier { get; set; }

    [Position(2)]
    public string CodeListIdentificationCode { get; set; }

    [Position(3)]
    public string CodeListResponsibleAgencyCode { get; set; }

    [Position(4)]
    public string LocationName { get; set; }

    public void Validate()
    {
        var validator = new BasicValidator<C517_LocationIdentification>(this);
        validator.Length(x => x.LocationIdentifier, 1, 35);
        validator.Length(x => x.CodeListIdentificationCode, 1, 17);
        validator.Length(x => x.CodeListResponsibleAgencyCode, 1, 3);
        validator.Length(x => x.LocationName, 1, 256);
    }
}