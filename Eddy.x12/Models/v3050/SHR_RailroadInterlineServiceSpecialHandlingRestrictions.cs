using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3050;

[Segment("SHR")]
public class SHR_RailroadInterlineServiceSpecialHandlingRestrictions : EdiX12Segment
{
	[Position(01)]
	public string YesNoConditionOrResponseCode { get; set; }

	[Position(02)]
	public string SpecialHandlingCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<SHR_RailroadInterlineServiceSpecialHandlingRestrictions>(this);
		validator.Required(x=>x.YesNoConditionOrResponseCode);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		validator.Length(x => x.SpecialHandlingCode, 2, 3);
		return validator.Results;
	}
}
