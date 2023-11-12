using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3040;

[Segment("CDD")]
public class CDD_CreditDebitAdjustmentDetail : EdiX12Segment
{
	[Position(01)]
	public string AdjustmentReasonCode { get; set; }

	[Position(02)]
	public string CreditDebitFlagCode { get; set; }

	[Position(03)]
	public string AssignedIdentification { get; set; }

	[Position(04)]
	public string Amount { get; set; }

	[Position(05)]
	public string ReturnFlagCode { get; set; }

	[Position(06)]
	public string PriceBracketIdentifier { get; set; }

	[Position(07)]
	public decimal? CreditDebitQuantity { get; set; }

	[Position(08)]
	public string UnitOrBasisForMeasurementCode { get; set; }

	[Position(09)]
	public decimal? UnitPriceDifference { get; set; }

	[Position(10)]
	public string PriceIdentifierCode { get; set; }

	[Position(11)]
	public decimal? UnitPrice { get; set; }

	[Position(12)]
	public string PriceIdentifierCode2 { get; set; }

	[Position(13)]
	public decimal? UnitPrice2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<CDD_CreditDebitAdjustmentDetail>(this);
		validator.Required(x=>x.AdjustmentReasonCode);
		validator.Required(x=>x.CreditDebitFlagCode);
		validator.AtLeastOneIsRequired(x=>x.Amount, x=>x.CreditDebitQuantity);
		validator.IfOneIsFilled_AllAreRequired(x=>x.PriceIdentifierCode, x=>x.UnitPrice);
		validator.IfOneIsFilled_AllAreRequired(x=>x.PriceIdentifierCode2, x=>x.UnitPrice2);
		validator.Length(x => x.AdjustmentReasonCode, 2);
		validator.Length(x => x.CreditDebitFlagCode, 1);
		validator.Length(x => x.AssignedIdentification, 1, 11);
		validator.Length(x => x.Amount, 1, 15);
		validator.Length(x => x.ReturnFlagCode, 1);
		validator.Length(x => x.PriceBracketIdentifier, 1, 3);
		validator.Length(x => x.CreditDebitQuantity, 1, 10);
		validator.Length(x => x.UnitOrBasisForMeasurementCode, 2);
		validator.Length(x => x.UnitPriceDifference, 1, 9);
		validator.Length(x => x.PriceIdentifierCode, 3);
		validator.Length(x => x.UnitPrice, 1, 14);
		validator.Length(x => x.PriceIdentifierCode2, 3);
		validator.Length(x => x.UnitPrice2, 1, 14);
		return validator.Results;
	}
}
