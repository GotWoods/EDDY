using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00A.Composites;

[Segment("E030")]
public class E030_AdjustmentInformation : EdifactComponent
{
	[Position(1)]
	public string AdjustmentCategoryCode { get; set; }

	[Position(2)]
	public string AdjustmentReasonDescriptionCode { get; set; }

	[Position(3)]
	public string MonetaryAmount { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E030_AdjustmentInformation>(this);
		validator.Required(x=>x.AdjustmentCategoryCode);
		validator.Required(x=>x.AdjustmentReasonDescriptionCode);
		validator.Length(x => x.AdjustmentCategoryCode, 1, 3);
		validator.Length(x => x.AdjustmentReasonDescriptionCode, 1, 3);
		validator.Length(x => x.MonetaryAmount, 1, 35);
		return validator.Results;
	}
}
