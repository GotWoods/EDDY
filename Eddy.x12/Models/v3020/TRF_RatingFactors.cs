using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3020;

[Segment("TRF")]
public class TRF_RatingFactors : EdiX12Segment
{
	[Position(01)]
	public string QuantityQualifier { get; set; }

	[Position(02)]
	public string UnitOfMeasurementCode { get; set; }

	[Position(03)]
	public decimal? Quantity { get; set; }

	[Position(04)]
	public string UnitOfMeasurementCode2 { get; set; }

	[Position(05)]
	public decimal? Quantity2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<TRF_RatingFactors>(this);
		validator.Required(x=>x.QuantityQualifier);
		validator.Required(x=>x.UnitOfMeasurementCode);
		validator.Required(x=>x.Quantity);
		validator.Required(x=>x.UnitOfMeasurementCode2);
		validator.Required(x=>x.Quantity2);
		validator.Length(x => x.QuantityQualifier, 2);
		validator.Length(x => x.UnitOfMeasurementCode, 2);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.UnitOfMeasurementCode2, 2);
		validator.Length(x => x.Quantity2, 1, 15);
		return validator.Results;
	}
}
