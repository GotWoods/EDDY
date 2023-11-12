using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3050;

[Segment("F04")]
public class F04_WeightVolumeLoss : EdiX12Segment
{
	[Position(01)]
	public decimal? Weight { get; set; }

	[Position(02)]
	public string WeightUnitCode { get; set; }

	[Position(03)]
	public string WeightQualifier { get; set; }

	[Position(04)]
	public decimal? Weight2 { get; set; }

	[Position(05)]
	public string WeightUnitCode2 { get; set; }

	[Position(06)]
	public string WeightQualifier2 { get; set; }

	[Position(07)]
	public decimal? Volume { get; set; }

	[Position(08)]
	public string VolumeUnitQualifier { get; set; }

	[Position(09)]
	public decimal? Volume2 { get; set; }

	[Position(10)]
	public string VolumeUnitQualifier2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<F04_WeightVolumeLoss>(this);
		validator.ARequiresB(x=>x.Weight, x=>x.Weight2);
		validator.IfOneIsFilled_AllAreRequired(x=>x.Volume, x=>x.VolumeUnitQualifier);
		validator.ARequiresB(x=>x.Volume, x=>x.Volume2);
		validator.IfOneIsFilled_AllAreRequired(x=>x.Volume2, x=>x.VolumeUnitQualifier2);
		validator.Length(x => x.Weight, 1, 10);
		validator.Length(x => x.WeightUnitCode, 1);
		validator.Length(x => x.WeightQualifier, 1, 2);
		validator.Length(x => x.Weight2, 1, 10);
		validator.Length(x => x.WeightUnitCode2, 1);
		validator.Length(x => x.WeightQualifier2, 1, 2);
		validator.Length(x => x.Volume, 1, 8);
		validator.Length(x => x.VolumeUnitQualifier, 1);
		validator.Length(x => x.Volume2, 1, 8);
		validator.Length(x => x.VolumeUnitQualifier2, 1);
		return validator.Results;
	}
}
