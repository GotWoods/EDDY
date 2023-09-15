using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("G31")]
public class G31_TotalInvoiceQuantity : EdiX12Segment
{
	[Position(01)]
	public decimal? NumberOfUnitsShipped { get; set; }

	[Position(02)]
	public string UnitOfMeasurementCode { get; set; }

	[Position(03)]
	public decimal? Weight { get; set; }

	[Position(04)]
	public string UnitOfMeasurementCode2 { get; set; }

	[Position(05)]
	public decimal? Volume { get; set; }

	[Position(06)]
	public string UnitOfMeasurementCode3 { get; set; }

	[Position(07)]
	public decimal? EquivalentWeight { get; set; }

	[Position(08)]
	public string PriceBracketIdentifier { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<G31_TotalInvoiceQuantity>(this);
		validator.Required(x=>x.NumberOfUnitsShipped);
		validator.Required(x=>x.UnitOfMeasurementCode);
		validator.Length(x => x.NumberOfUnitsShipped, 1, 10);
		validator.Length(x => x.UnitOfMeasurementCode, 2);
		validator.Length(x => x.Weight, 1, 8);
		validator.Length(x => x.UnitOfMeasurementCode2, 2);
		validator.Length(x => x.Volume, 1, 8);
		validator.Length(x => x.UnitOfMeasurementCode3, 2);
		validator.Length(x => x.EquivalentWeight, 1, 10);
		validator.Length(x => x.PriceBracketIdentifier, 1, 3);
		return validator.Results;
	}
}
