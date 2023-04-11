using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Internals;

namespace Eddy.x12.Models;

[Segment("MS6")]
public class MS6_ShipmentQuantityAndWeight : EdiX12Segment
{
	[Position(01)]
	public decimal? Quantity { get; set; }

	[Position(02)]
	public string WeightQualifier { get; set; }

	[Position(03)]
	public decimal? Weight { get; set; }

	[Position(04)]
	public string UnitOrBasisForMeasurementCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<MS6_ShipmentQuantityAndWeight>(this);
		validator.Required(x=>x.Quantity);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.WeightQualifier, 1, 2);
		validator.Length(x => x.Weight, 1, 10);
		validator.Length(x => x.UnitOrBasisForMeasurementCode, 2);
		return validator.Results;
	}
}
