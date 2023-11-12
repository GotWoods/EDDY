using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3070;

[Segment("MS6")]
public class MS6_ShipmentQuantityAndWeight : EdiX12Segment
{
	[Position(01)]
	public decimal? Quantity { get; set; }

	[Position(02)]
	public string WeightQualifier { get; set; }

	[Position(03)]
	public decimal? Weight { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<MS6_ShipmentQuantityAndWeight>(this);
		validator.Required(x=>x.Quantity);
		validator.IfOneIsFilled_AllAreRequired(x=>x.WeightQualifier, x=>x.Weight);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.WeightQualifier, 1, 2);
		validator.Length(x => x.Weight, 1, 10);
		return validator.Results;
	}
}
