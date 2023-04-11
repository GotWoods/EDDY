using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.x12.Models.Elements;

[Segment("C060")]
public class C060_QuestionAndAnswer : EdiX12Component
{
    [Position(00)]
    public string AssignedIdentification { get; set; }

    [Position(01)]
    public string YesNoConditionOrResponseCode { get; set; }

    public override ValidationResult Validate()
    {
        var validator = new BasicValidator<C060_QuestionAndAnswer>(this);
        validator.Required(x => x.AssignedIdentification);
        validator.Required(x => x.YesNoConditionOrResponseCode);
        validator.Length(x => x.AssignedIdentification, 1, 20);
        validator.Length(x => x.YesNoConditionOrResponseCode, 1);
        return validator.Results;
    }
}