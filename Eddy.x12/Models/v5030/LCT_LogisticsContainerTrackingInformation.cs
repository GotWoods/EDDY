using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v5030;

[Segment("LCT")]
public class LCT_LogisticsContainerTrackingInformation : EdiX12Segment
{
	[Position(01)]
	public string ReferenceIdentification { get; set; }

	[Position(02)]
	public string PackagingFormCode { get; set; }

	[Position(03)]
	public string Description { get; set; }

	[Position(04)]
	public string WeightUnitCode { get; set; }

	[Position(05)]
	public decimal? UnitWeight { get; set; }

	[Position(06)]
	public string MeasurementUnitQualifier { get; set; }

	[Position(07)]
	public decimal? Length { get; set; }

	[Position(08)]
	public decimal? Width { get; set; }

	[Position(09)]
	public decimal? Height { get; set; }

	[Position(10)]
	public string VolumeUnitQualifier { get; set; }

	[Position(11)]
	public decimal? Volume { get; set; }

	[Position(12)]
	public string PalletExchangeCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<LCT_LogisticsContainerTrackingInformation>(this);
		validator.Required(x=>x.ReferenceIdentification);
		validator.Required(x=>x.PackagingFormCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.WeightUnitCode, x=>x.UnitWeight);
		validator.IfOneIsFilledThenAtLeastOne(x=>x.MeasurementUnitQualifier, x=>x.Length, x=>x.Width, x=>x.Height);
		validator.ARequiresB(x=>x.Length, x=>x.MeasurementUnitQualifier);
		validator.ARequiresB(x=>x.Width, x=>x.MeasurementUnitQualifier);
		validator.ARequiresB(x=>x.Height, x=>x.MeasurementUnitQualifier);
		validator.IfOneIsFilled_AllAreRequired(x=>x.VolumeUnitQualifier, x=>x.Volume);
		validator.Length(x => x.ReferenceIdentification, 1, 80);
		validator.Length(x => x.PackagingFormCode, 3);
		validator.Length(x => x.Description, 1, 80);
		validator.Length(x => x.WeightUnitCode, 1);
		validator.Length(x => x.UnitWeight, 1, 8);
		validator.Length(x => x.MeasurementUnitQualifier, 1);
		validator.Length(x => x.Length, 1, 8);
		validator.Length(x => x.Width, 1, 8);
		validator.Length(x => x.Height, 1, 8);
		validator.Length(x => x.VolumeUnitQualifier, 1);
		validator.Length(x => x.Volume, 1, 8);
		validator.Length(x => x.PalletExchangeCode, 1);
		return validator.Results;
	}
}
