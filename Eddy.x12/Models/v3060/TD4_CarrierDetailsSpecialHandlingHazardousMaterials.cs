using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3060;

[Segment("TD4")]
public class TD4_CarrierDetailsSpecialHandlingOrHazardousMaterialsOrBoth : EdiX12Segment
{
	[Position(01)]
	public string SpecialHandlingCode { get; set; }

	[Position(02)]
	public string HazardousMaterialCodeQualifier { get; set; }

	[Position(03)]
	public string HazardousMaterialClassCode { get; set; }

	[Position(04)]
	public string Description { get; set; }

	[Position(05)]
	public string YesNoConditionOrResponseCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<TD4_CarrierDetailsSpecialHandlingOrHazardousMaterialsOrBoth>(this);
		validator.ARequiresB(x=>x.HazardousMaterialCodeQualifier, x=>x.HazardousMaterialClassCode);
		validator.Length(x => x.SpecialHandlingCode, 2, 3);
		validator.Length(x => x.HazardousMaterialCodeQualifier, 1);
		validator.Length(x => x.HazardousMaterialClassCode, 1, 4);
		validator.Length(x => x.Description, 1, 80);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		return validator.Results;
	}
}
