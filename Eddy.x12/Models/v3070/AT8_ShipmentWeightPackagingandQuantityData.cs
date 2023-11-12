using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3070;

[Segment("AT8")]
public class AT8_ShipmentWeightPackagingAndQuantityData : EdiX12Segment
{
	[Position(01)]
	public string WeightQualifier { get; set; }

	[Position(02)]
	public string WeightUnitCode { get; set; }

	[Position(03)]
	public decimal? Weight { get; set; }

	[Position(04)]
	public int? LadingQuantity { get; set; }

	[Position(05)]
	public int? LadingQuantity2 { get; set; }

	[Position(06)]
	public string VolumeUnitQualifier { get; set; }

	[Position(07)]
	public decimal? Volume { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<AT8_ShipmentWeightPackagingAndQuantityData>(this);
		validator.IfOneIsFilled_AllAreRequired(x=>x.VolumeUnitQualifier, x=>x.Volume);
		validator.Length(x => x.WeightQualifier, 1, 2);
		validator.Length(x => x.WeightUnitCode, 1);
		validator.Length(x => x.Weight, 1, 10);
		validator.Length(x => x.LadingQuantity, 1, 7);
		validator.Length(x => x.LadingQuantity2, 1, 7);
		validator.Length(x => x.VolumeUnitQualifier, 1);
		validator.Length(x => x.Volume, 1, 8);
		return validator.Results;
	}
}
