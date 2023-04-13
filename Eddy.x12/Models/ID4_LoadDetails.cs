using Eddy.Core.Attributes;
using Eddy.Core.Validation;


namespace Eddy.x12.Models;

[Segment("ID4")]
public class ID4_LoadDetails : EdiX12Segment
{
	[Position(01)]
	public string DeclaredValue { get; set; }

	[Position(02)]
	public string PickupOrDeliveryCode { get; set; }

	[Position(03)]
	public string WeightQualifier { get; set; }

	[Position(04)]
	public decimal? Weight { get; set; }

	[Position(05)]
	public string VolumeUnitQualifier { get; set; }

	[Position(06)]
	public decimal? Volume { get; set; }

	[Position(07)]
	public int? Number { get; set; }

	[Position(08)]
	public string YesNoConditionOrResponseCode { get; set; }

	[Position(09)]
	public string YesNoConditionOrResponseCode2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<ID4_LoadDetails>(this);
		validator.IfOneIsFilled_AllAreRequired(x=>x.WeightQualifier, x=>x.Weight);
		validator.IfOneIsFilled_AllAreRequired(x=>x.VolumeUnitQualifier, x=>x.Volume);
		validator.Length(x => x.DeclaredValue, 2, 12);
		validator.Length(x => x.PickupOrDeliveryCode, 1, 2);
		validator.Length(x => x.WeightQualifier, 1, 2);
		validator.Length(x => x.Weight, 1, 10);
		validator.Length(x => x.VolumeUnitQualifier, 1);
		validator.Length(x => x.Volume, 1, 8);
		validator.Length(x => x.Number, 1, 9);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		validator.Length(x => x.YesNoConditionOrResponseCode2, 1);
		return validator.Results;
	}
}
