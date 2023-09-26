using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v5020;

[Segment("AT2")]
public class AT2_BillOfLadingLineItemDetail : EdiX12Segment
{
	[Position(01)]
	public int? LadingQuantity { get; set; }

	[Position(02)]
	public string PackagingFormCode { get; set; }

	[Position(03)]
	public string WeightQualifier { get; set; }

	[Position(04)]
	public string WeightUnitCode { get; set; }

	[Position(05)]
	public decimal? Weight { get; set; }

	[Position(06)]
	public int? LadingQuantity2 { get; set; }

	[Position(07)]
	public string PackagingFormCode2 { get; set; }

	[Position(08)]
	public string YesNoConditionOrResponseCode { get; set; }

	[Position(09)]
	public string CommodityCode { get; set; }

	[Position(10)]
	public string FreightClassCode { get; set; }

	[Position(11)]
	public string YesNoConditionOrResponseCode2 { get; set; }

	[Position(12)]
	public decimal? LadingValue { get; set; }

	[Position(13)]
	public string VolumeUnitQualifier { get; set; }

	[Position(14)]
	public decimal? Volume { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<AT2_BillOfLadingLineItemDetail>(this);
		validator.IfOneIsFilled_AllAreRequired(x=>x.LadingQuantity, x=>x.PackagingFormCode);
		validator.Required(x=>x.WeightQualifier);
		validator.Required(x=>x.WeightUnitCode);
		validator.Required(x=>x.Weight);
		validator.IfOneIsFilled_AllAreRequired(x=>x.LadingQuantity2, x=>x.PackagingFormCode2);
		validator.IfOneIsFilled_AllAreRequired(x=>x.VolumeUnitQualifier, x=>x.Volume);
		validator.Length(x => x.LadingQuantity, 1, 7);
		validator.Length(x => x.PackagingFormCode, 3);
		validator.Length(x => x.WeightQualifier, 1, 2);
		validator.Length(x => x.WeightUnitCode, 1);
		validator.Length(x => x.Weight, 1, 10);
		validator.Length(x => x.LadingQuantity2, 1, 7);
		validator.Length(x => x.PackagingFormCode2, 3);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		validator.Length(x => x.CommodityCode, 1, 30);
		validator.Length(x => x.FreightClassCode, 2, 5);
		validator.Length(x => x.YesNoConditionOrResponseCode2, 1);
		validator.Length(x => x.LadingValue, 2, 9);
		validator.Length(x => x.VolumeUnitQualifier, 1);
		validator.Length(x => x.Volume, 1, 8);
		return validator.Results;
	}
}
