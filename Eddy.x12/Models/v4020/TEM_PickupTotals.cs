using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4020;

[Segment("TEM")]
public class TEM_PickUpTotals : EdiX12Segment
{
	[Position(01)]
	public decimal? Quantity { get; set; }

	[Position(02)]
	public decimal? Quantity2 { get; set; }

	[Position(03)]
	public string WeightUnitCode { get; set; }

	[Position(04)]
	public decimal? Weight { get; set; }

	[Position(05)]
	public string CommodityCharacteristicCodes { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<TEM_PickUpTotals>(this);
		validator.AtLeastOneIsRequired(x=>x.Quantity, x=>x.Quantity2);
		validator.IfOneIsFilled_AllAreRequired(x=>x.WeightUnitCode, x=>x.Weight);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.Quantity2, 1, 15);
		validator.Length(x => x.WeightUnitCode, 1);
		validator.Length(x => x.Weight, 1, 10);
		validator.Length(x => x.CommodityCharacteristicCodes, 2);
		return validator.Results;
	}
}
