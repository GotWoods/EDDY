using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4020;

[Segment("PDI")]
public class PDI_PracticeDetailInformation : EdiX12Segment
{
	[Position(01)]
	public string GenderCode { get; set; }

	[Position(02)]
	public decimal? RangeMinimum { get; set; }

	[Position(03)]
	public decimal? RangeMaximum { get; set; }

	[Position(04)]
	public string YesNoConditionOrResponseCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<PDI_PracticeDetailInformation>(this);
		validator.Length(x => x.GenderCode, 1);
		validator.Length(x => x.RangeMinimum, 1, 20);
		validator.Length(x => x.RangeMaximum, 1, 20);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		return validator.Results;
	}
}
