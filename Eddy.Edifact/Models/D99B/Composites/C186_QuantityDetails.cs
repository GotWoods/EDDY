using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D99B.Composites;

[Segment("C186")]
public class C186_QuantityDetails : EdifactComponent
{
	[Position(1)]
	public string QuantityTypeCodeQualifier { get; set; }

	[Position(2)]
	public string Quantity { get; set; }

	[Position(3)]
	public string MeasurementUnitCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C186_QuantityDetails>(this);
		validator.Required(x=>x.QuantityTypeCodeQualifier);
		validator.Required(x=>x.Quantity);
		validator.Length(x => x.QuantityTypeCodeQualifier, 1, 3);
		validator.Length(x => x.Quantity, 1, 35);
		validator.Length(x => x.MeasurementUnitCode, 1, 3);
		return validator.Results;
	}
}
