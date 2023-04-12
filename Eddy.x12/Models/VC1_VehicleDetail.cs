using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models;

[Segment("VC1")]
public class VC1_VehicleDetail : EdiX12Segment
{
	[Position(01)]
	public string Color { get; set; }

	[Position(02)]
	public string Color2 { get; set; }

	[Position(03)]
	public string VehicleDimension { get; set; }

	[Position(04)]
	public string SpecialHandlingCode { get; set; }

	[Position(05)]
	public string CurrencyCode { get; set; }

	[Position(06)]
	public decimal? MonetaryAmount { get; set; }

	[Position(07)]
	public string WeightUnitCode { get; set; }

	[Position(08)]
	public decimal? Weight { get; set; }

	[Position(09)]
	public string MeasurementUnitQualifier { get; set; }

	[Position(10)]
	public decimal? Height { get; set; }

	[Position(11)]
	public decimal? Length { get; set; }

	[Position(12)]
	public decimal? Width { get; set; }

	[Position(13)]
	public string VolumeUnitQualifier { get; set; }

	[Position(14)]
	public decimal? Volume { get; set; }

	[Position(15)]
	public string LocationIdentifier { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<VC1_VehicleDetail>(this);
		validator.ARequiresB(x=>x.MonetaryAmount, x=>x.CurrencyCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.VolumeUnitQualifier, x=>x.Volume);
		validator.Length(x => x.Color, 1, 10);
		validator.Length(x => x.Color2, 1, 10);
		validator.Length(x => x.VehicleDimension, 1, 6);
		validator.Length(x => x.SpecialHandlingCode, 2, 3);
		validator.Length(x => x.CurrencyCode, 3);
		validator.Length(x => x.MonetaryAmount, 1, 18);
		validator.Length(x => x.WeightUnitCode, 1);
		validator.Length(x => x.Weight, 1, 10);
		validator.Length(x => x.MeasurementUnitQualifier, 1);
		validator.Length(x => x.Height, 1, 8);
		validator.Length(x => x.Length, 1, 8);
		validator.Length(x => x.Width, 1, 8);
		validator.Length(x => x.VolumeUnitQualifier, 1);
		validator.Length(x => x.Volume, 1, 8);
		validator.Length(x => x.LocationIdentifier, 1, 30);
		return validator.Results;
	}
}
