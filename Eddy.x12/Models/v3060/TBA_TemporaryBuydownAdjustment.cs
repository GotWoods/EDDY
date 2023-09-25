using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3060;

[Segment("TBA")]
public class TBA_TemporaryBuydownAdjustment : EdiX12Segment
{
	[Position(01)]
	public C001_CompositeUnitOfMeasure CompositeUnitOfMeasure { get; set; }

	[Position(02)]
	public decimal? Quantity { get; set; }

	[Position(03)]
	public decimal? Percent { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<TBA_TemporaryBuydownAdjustment>(this);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.Percent, 1, 10);
		return validator.Results;
	}
}
