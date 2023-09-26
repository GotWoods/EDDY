using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3050;

[Segment("RPA")]
public class RPA_RateAmountsOrPercents : EdiX12Segment
{
	[Position(01)]
	public string RateOrValueTypeCode { get; set; }

	[Position(02)]
	public decimal? MonetaryAmount { get; set; }

	[Position(03)]
	public decimal? Rate { get; set; }

	[Position(04)]
	public C001_CompositeUnitOfMeasure CompositeUnitOfMeasure { get; set; }

	[Position(05)]
	public decimal? Percent { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<RPA_RateAmountsOrPercents>(this);
		validator.Required(x=>x.RateOrValueTypeCode);
		validator.Length(x => x.RateOrValueTypeCode, 1, 2);
		validator.Length(x => x.MonetaryAmount, 1, 15);
		validator.Length(x => x.Rate, 1, 9);
		validator.Length(x => x.Percent, 1, 10);
		return validator.Results;
	}
}
