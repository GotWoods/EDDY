using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3050;

[Segment("L13")]
public class L13_CommodityDetails : EdiX12Segment
{
	[Position(01)]
	public string CommodityCodeQualifier { get; set; }

	[Position(02)]
	public string CommodityCode { get; set; }

	[Position(03)]
	public string QuantityQualifier { get; set; }

	[Position(04)]
	public decimal? Quantity { get; set; }

	[Position(05)]
	public string AmountQualifierCode { get; set; }

	[Position(06)]
	public decimal? MonetaryAmount { get; set; }

	[Position(07)]
	public int? AssignedNumber { get; set; }

	[Position(08)]
	public string QuantityQualifier2 { get; set; }

	[Position(09)]
	public decimal? Quantity2 { get; set; }

	[Position(10)]
	public string WeightUnitCode { get; set; }

	[Position(11)]
	public decimal? Weight { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<L13_CommodityDetails>(this);
		validator.Required(x=>x.CommodityCodeQualifier);
		validator.Required(x=>x.CommodityCode);
		validator.Required(x=>x.QuantityQualifier);
		validator.Required(x=>x.Quantity);
		validator.Required(x=>x.AmountQualifierCode);
		validator.Required(x=>x.MonetaryAmount);
		validator.Required(x=>x.AssignedNumber);
		validator.IfOneIsFilled_AllAreRequired(x=>x.QuantityQualifier2, x=>x.Quantity2);
		validator.IfOneIsFilled_AllAreRequired(x=>x.WeightUnitCode, x=>x.Weight);
		validator.Length(x => x.CommodityCodeQualifier, 1);
		validator.Length(x => x.CommodityCode, 1, 30);
		validator.Length(x => x.QuantityQualifier, 2);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.AmountQualifierCode, 1, 2);
		validator.Length(x => x.MonetaryAmount, 1, 15);
		validator.Length(x => x.AssignedNumber, 1, 6);
		validator.Length(x => x.QuantityQualifier2, 2);
		validator.Length(x => x.Quantity2, 1, 15);
		validator.Length(x => x.WeightUnitCode, 1);
		validator.Length(x => x.Weight, 1, 10);
		return validator.Results;
	}
}
