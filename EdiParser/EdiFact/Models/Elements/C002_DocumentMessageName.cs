using EdiParser.Attributes;
using EdiParser.Validation;

namespace EdiParser.EdiFact.Models.Elements;

public class C002_DocumentMessageName : IElement
{
    [Position(1)]
    public string Documentnamecode { get; set; }

    [Position(2)]
    public string Codelistidentificationcode { get; set; }

    [Position(3)]
    public string Codelistresponsibleagencycode { get; set; }

    [Position(4)]
    public string Documentname { get; set; }

    public void Validate()
    {
        var validator = new BasicValidator<C002_DocumentMessageName>(this);
        validator.Length(x => x.Documentnamecode, 1, 3);
        validator.Length(x => x.Codelistidentificationcode, 1, 17);
        validator.Length(x => x.Codelistresponsibleagencycode, 1, 3);
        validator.Length(x => x.Documentname, 1, 35);
    }
}