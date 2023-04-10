using EdiParser.Attributes;
using EdiParser.Validation;

namespace EdiParser.x12.Models.Elements;

[Segment("C998")]
public class C998_ContextIdentification : EdiX12Component
{
    [Position(00)]
    public string ContextName { get; set; }

    [Position(01)]
    public string ContextReference { get; set; }

    public override ValidationResult Validate()
    {
        var validator = new BasicValidator<C998_ContextIdentification>(this);
        validator.Required(x => x.ContextName);
        validator.Length(x => x.ContextName, 1, 35);
        validator.Length(x => x.ContextReference, 1, 50);
        return validator.Results;
    }
}