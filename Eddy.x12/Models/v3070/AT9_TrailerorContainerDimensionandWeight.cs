using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3070;

[Segment("AT9")]
public class AT9_TrailerOrContainerDimensionAndWeight : EdiX12Segment
{
	[Position(01)]
	public int? EquipmentLength { get; set; }

	[Position(02)]
	public decimal? Height { get; set; }

	[Position(03)]
	public decimal? Width { get; set; }

	[Position(04)]
	public string WeightQualifier { get; set; }

	[Position(05)]
	public string WeightUnitCode { get; set; }

	[Position(06)]
	public decimal? Weight { get; set; }

	[Position(07)]
	public string VolumeUnitQualifier { get; set; }

	[Position(08)]
	public decimal? Volume { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<AT9_TrailerOrContainerDimensionAndWeight>(this);
		validator.IfOneIsFilled_AllAreRequired(x=>x.VolumeUnitQualifier, x=>x.Volume);
		validator.Length(x => x.EquipmentLength, 4, 5);
		validator.Length(x => x.Height, 1, 8);
		validator.Length(x => x.Width, 1, 8);
		validator.Length(x => x.WeightQualifier, 1, 2);
		validator.Length(x => x.WeightUnitCode, 1);
		validator.Length(x => x.Weight, 1, 10);
		validator.Length(x => x.VolumeUnitQualifier, 1);
		validator.Length(x => x.Volume, 1, 8);
		return validator.Results;
	}
}
