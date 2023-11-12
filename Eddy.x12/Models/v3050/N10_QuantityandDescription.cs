using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3050;

[Segment("N10")]
public class N10_QuantityAndDescription : EdiX12Segment
{
	[Position(01)]
	public decimal? Quantity { get; set; }

	[Position(02)]
	public string FreeFormDescription { get; set; }

	[Position(03)]
	public string MarksAndNumbers { get; set; }

	[Position(04)]
	public string CommodityCodeQualifier { get; set; }

	[Position(05)]
	public string CommodityCode { get; set; }

	[Position(06)]
	public string CustomsShipmentValue { get; set; }

	[Position(07)]
	public string WeightUnitCode { get; set; }

	[Position(08)]
	public decimal? Weight { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<N10_QuantityAndDescription>(this);
		validator.IfOneIsFilled_AllAreRequired(x=>x.CommodityCodeQualifier, x=>x.CommodityCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.WeightUnitCode, x=>x.Weight);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.FreeFormDescription, 1, 45);
		validator.Length(x => x.MarksAndNumbers, 1, 45);
		validator.Length(x => x.CommodityCodeQualifier, 1);
		validator.Length(x => x.CommodityCode, 1, 30);
		validator.Length(x => x.CustomsShipmentValue, 2, 8);
		validator.Length(x => x.WeightUnitCode, 1);
		validator.Length(x => x.Weight, 1, 10);
		return validator.Results;
	}
}
