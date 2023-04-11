using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Internals;

namespace Eddy.x12.Models;

[Segment("MI1")]
public class MI1_MileageSource : EdiX12Segment
{
	[Position(01)]
	public string MileageSourceCode { get; set; }

	[Position(02)]
	public string YesNoConditionOrResponseCode { get; set; }

	[Position(03)]
	public int? Number { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<MI1_MileageSource>(this);
		validator.Required(x=>x.MileageSourceCode);
		validator.Required(x=>x.YesNoConditionOrResponseCode);
		validator.Length(x => x.MileageSourceCode, 2);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		validator.Length(x => x.Number, 1, 9);
		return validator.Results;
	}
}
