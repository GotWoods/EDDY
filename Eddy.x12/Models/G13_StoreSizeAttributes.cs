using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Internals;

namespace Eddy.x12.Models;

[Segment("G13")]
public class G13_StoreSizeAttributes : EdiX12Segment
{
	[Position(01)]
	public string ClassOfTradeCode { get; set; }

	[Position(02)]
	public decimal? Quantity { get; set; }

	[Position(03)]
	public string UnitOrBasisForMeasurementCode { get; set; }

	[Position(04)]
	public int? Number { get; set; }

	[Position(05)]
	public decimal? MonetaryAmount { get; set; }

	[Position(06)]
	public string AmountQualifierCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<G13_StoreSizeAttributes>(this);
		validator.Required(x=>x.ClassOfTradeCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.Quantity, x=>x.UnitOrBasisForMeasurementCode);
		validator.ARequiresB(x=>x.AmountQualifierCode, x=>x.MonetaryAmount);
		validator.Length(x => x.ClassOfTradeCode, 2);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.UnitOrBasisForMeasurementCode, 2);
		validator.Length(x => x.Number, 1, 9);
		validator.Length(x => x.MonetaryAmount, 1, 18);
		validator.Length(x => x.AmountQualifierCode, 1, 3);
		return validator.Results;
	}
}
