using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Models.D99B;

[Segment("ARD")]
public class ARD_MonetaryAmountFunction : EdifactSegment
{
	[Position(1)]
	public C549_MonetaryAmountFunction MonetaryAmountFunction { get; set; }

	[Position(2)]
	public C008_MonetaryAmountFunctionDetail MonetaryAmountFunctionDetail { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<ARD_MonetaryAmountFunction>(this);
		return validator.Results;
	}
}
