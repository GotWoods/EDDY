using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D96A.Composites;

[Segment("C186")]
public class C186_QuantityDetails : EdifactComponent
{
	[Position(1)]
	public string QuantityQualifier { get; set; }

	[Position(2)]
	public string Quantity { get; set; }

	[Position(3)]
	public string MeasureUnitQualifier { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C186_QuantityDetails>(this);
		validator.Required(x=>x.QuantityQualifier);
		validator.Required(x=>x.Quantity);
		validator.Length(x => x.QuantityQualifier, 1, 3);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.MeasureUnitQualifier, 1, 3);
		return validator.Results;
	}
}
