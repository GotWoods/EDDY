using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.x12.Models;

[Segment("LH3")]
public class LH3_HazardousMaterialShippingNameInformation : EdiX12Segment
{
    [Position(01)]
    public string HazardousMaterialShippingName { get; set; }

    [Position(02)]
    public string HazardousMaterialShippingNameQualifier { get; set; }

    [Position(03)]
    public string NOSIndicatorCode { get; set; }

    [Position(04)]
    public string YesNoConditionOrResponseCode { get; set; }

    public override ValidationResult Validate()
    {
        var validator = new BasicValidator<LH3_HazardousMaterialShippingNameInformation>(this);
        validator.IfOneIsFilled_AllAreRequired(x => x.HazardousMaterialShippingName, x => x.HazardousMaterialShippingNameQualifier);
        validator.Length(x => x.HazardousMaterialShippingName, 1, 25);
        validator.Length(x => x.HazardousMaterialShippingNameQualifier, 1);
        validator.Length(x => x.NOSIndicatorCode, 3);
        validator.Length(x => x.YesNoConditionOrResponseCode, 1);
        return validator.Results;
    }
}