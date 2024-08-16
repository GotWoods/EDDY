using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D99B.Composites;

[Segment("E958")]
public class E958_QuantityAndActionDetails : EdifactComponent
{
	[Position(1)]
	public string Quantity { get; set; }

	[Position(2)]
	public string StatusDescriptionCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E958_QuantityAndActionDetails>(this);
		validator.Length(x => x.Quantity, 1, 35);
		validator.Length(x => x.StatusDescriptionCode, 1, 3);
		return validator.Results;
	}
}
