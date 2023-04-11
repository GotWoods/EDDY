using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Internals;

namespace Eddy.x12.Models;

[Segment("FTH")]
public class FTH_FirstTimeHomeBuyer : EdiX12Segment
{
	[Position(01)]
	public string YesNoConditionOrResponseCode { get; set; }

	[Position(02)]
	public string YesNoConditionOrResponseCode2 { get; set; }

	[Position(03)]
	public string TypeOfResidenceCode { get; set; }

	[Position(04)]
	public string TypeOfAccountCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<FTH_FirstTimeHomeBuyer>(this);
		validator.Required(x=>x.YesNoConditionOrResponseCode);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		validator.Length(x => x.YesNoConditionOrResponseCode2, 1);
		validator.Length(x => x.TypeOfResidenceCode, 1);
		validator.Length(x => x.TypeOfAccountCode, 2);
		return validator.Results;
	}
}
