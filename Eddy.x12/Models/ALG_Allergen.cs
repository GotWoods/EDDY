using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.x12.Models;

[Segment("ALG")]
public class ALG_Allergen : EdiX12Segment
{
    [Position(01)] public string AssignedIdentification { get; set; }

    [Position(02)] public string AllergenTypeCode { get; set; }

    [Position(03)] public string YesNoConditionOrResponseCode { get; set; }

    [Position(04)] public string Description { get; set; }

    [Position(05)] public string ConditionIndicatorCode { get; set; }

    public override ValidationResult Validate()
    {
        var validator = new BasicValidator<ALG_Allergen>(this);
        validator.Required(x => x.AllergenTypeCode);
        validator.Required(x => x.YesNoConditionOrResponseCode);
        validator.OnlyOneOf(x => x.YesNoConditionOrResponseCode, x => x.Description);
        validator.Length(x => x.AssignedIdentification, 1, 20);
        validator.Length(x => x.AllergenTypeCode, 1, 3);
        validator.Length(x => x.YesNoConditionOrResponseCode, 1);
        validator.Length(x => x.Description, 1, 80);
        validator.Length(x => x.ConditionIndicatorCode, 2, 3);
        return validator.Results;
    }
}