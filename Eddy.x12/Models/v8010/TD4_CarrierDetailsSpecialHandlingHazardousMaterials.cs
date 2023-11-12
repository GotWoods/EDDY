using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v8010;

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

	[Position(06)]
	public string HazardousMaterialShippingName { get; set; }

	[Position(07)]
	public string DangerousGoodsPrimaryClassificationCode { get; set; }

	[Position(08)]
	public string PrimaryClassificationCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<TD4_CarrierDetailsSpecialHandlingOrHazardousMaterialsOrBoth>(this);
		validator.ARequiresB(x=>x.HazardousMaterialCodeQualifier, x=>x.HazardousMaterialClassCode);
		validator.Length(x => x.SpecialHandlingCode, 2, 3);
		validator.Length(x => x.HazardousMaterialCodeQualifier, 1);
		validator.Length(x => x.HazardousMaterialClassCode, 1, 4);
		validator.Length(x => x.Description, 1, 80);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		validator.Length(x => x.HazardousMaterialShippingName, 1, 25);
		validator.Length(x => x.DangerousGoodsPrimaryClassificationCode, 1, 6);
		validator.Length(x => x.PrimaryClassificationCode, 1, 3);
		return validator.Results;
	}
}
