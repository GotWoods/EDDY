using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3020;

[Segment("TBA")]
public class TBA_TemporaryBuydownAdjustment : EdiX12Segment
{
	[Position(01)]
	public string UnitOfMeasurementCode { get; set; }

	[Position(02)]
	public decimal? Quantity { get; set; }

	[Position(03)]
	public decimal? Percent { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<TBA_TemporaryBuydownAdjustment>(this);
		validator.ARequiresB(x=>x.Quantity, x=>x.UnitOfMeasurementCode);
		validator.Length(x => x.UnitOfMeasurementCode, 2);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.Percent, 1, 10);
		return validator.Results;
	}
}
