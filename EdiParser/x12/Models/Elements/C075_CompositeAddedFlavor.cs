using EdiParser.Attributes;
using EdiParser.Validation;

namespace EdiParser.x12.Models.Elements;

[Segment("C075")]
public class C075_CompositeAddedFlavor : EdiX12Component
{
    [Position(00)]
    public string AddedFlavor { get; set; }

    [Position(01)]
    public string AddedFlavor2 { get; set; }

    [Position(02)]
    public string AddedFlavor3 { get; set; }

    public override ValidationResult Validate()
    {
        var validator = new BasicValidator<C075_CompositeAddedFlavor>(this);
        validator.Required(x => x.AddedFlavor);
        validator.ARequiresB(x => x.AddedFlavor3, x => x.AddedFlavor2);
        validator.Length(x => x.AddedFlavor, 2, 3);
        validator.Length(x => x.AddedFlavor2, 2, 3);
        validator.Length(x => x.AddedFlavor3, 2, 3);
        return validator.Results;
    }
}