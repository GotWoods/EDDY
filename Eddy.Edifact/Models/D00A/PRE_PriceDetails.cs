using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Models.D00A;

[Segment("PRE")]
public class PRE_PriceDetails : EdifactSegment
{
	[Position(1)]
	public E018_PriceInformation PriceInformation { get; set; }

	[Position(2)]
	public string SubLineItemPriceChangeOperationCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<PRE_PriceDetails>(this);
		validator.Length(x => x.SubLineItemPriceChangeOperationCode, 1, 3);
		return validator.Results;
	}
}
