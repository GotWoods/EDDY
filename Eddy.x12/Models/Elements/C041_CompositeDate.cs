using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.x12.Models.Elements;

[Segment("C041")]
public class C041_CompositeDate : EdiX12Component
{
    [Position(01)]
    public string Date { get; set; }

    [Position(02)]
    public int? Century { get; set; }

    public override ValidationResult Validate()
    {
        var validator = new BasicValidator<C041_CompositeDate>(this);
        validator.Required(x => x.Date);
        validator.Length(x => x.Date, 6);
        validator.Length(x => x.Century, 2);
        return validator.Results;
    }
}