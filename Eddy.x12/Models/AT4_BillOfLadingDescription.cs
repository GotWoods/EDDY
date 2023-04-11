using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.x12.Models;

[Segment("AT4")]
public class AT4_BillOfLadingDescription : EdiX12Segment
{
    [Position(01)]
    public string LadingDescription { get; set; }

    public override ValidationResult Validate()
    {
        var validator = new BasicValidator<AT4_BillOfLadingDescription>(this);
        validator.Required(x => x.LadingDescription);
        validator.Length(x => x.LadingDescription, 1, 50);
        return validator.Results;
    }
}