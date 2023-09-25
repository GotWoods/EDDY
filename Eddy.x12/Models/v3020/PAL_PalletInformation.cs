using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3020;

[Segment("PAL")]
public class PAL_PalletInformation : EdiX12Segment
{
	[Position(01)]
	public string PalletTypeCode { get; set; }

	[Position(02)]
	public int? PalletTiers { get; set; }

	[Position(03)]
	public int? PalletBlocks { get; set; }

	[Position(04)]
	public int? Pack { get; set; }

	[Position(05)]
	public decimal? UnitWeight { get; set; }

	[Position(06)]
	public string UnitOfMeasurementCode { get; set; }

	[Position(07)]
	public decimal? Length { get; set; }

	[Position(08)]
	public decimal? Width { get; set; }

	[Position(09)]
	public decimal? Height { get; set; }

	[Position(10)]
	public string UnitOfMeasurementCode2 { get; set; }

	[Position(11)]
	public decimal? GrossWeightPerPack { get; set; }

	[Position(12)]
	public string UnitOfMeasurementCode3 { get; set; }

	[Position(13)]
	public decimal? GrossVolumePerPack { get; set; }

	[Position(14)]
	public string UnitOfMeasurementCode4 { get; set; }

	[Position(15)]
	public string PalletExchangeCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<PAL_PalletInformation>(this);
		validator.IfOneIsFilled_AllAreRequired(x=>x.UnitWeight, x=>x.UnitOfMeasurementCode);
		validator.ARequiresB(x=>x.Length, x=>x.UnitOfMeasurementCode2);
		validator.ARequiresB(x=>x.Width, x=>x.UnitOfMeasurementCode2);
		validator.ARequiresB(x=>x.Height, x=>x.UnitOfMeasurementCode2);
		validator.IfOneIsFilled_AllAreRequired(x=>x.GrossWeightPerPack, x=>x.UnitOfMeasurementCode3);
		validator.IfOneIsFilled_AllAreRequired(x=>x.GrossVolumePerPack, x=>x.UnitOfMeasurementCode4);
		validator.Length(x => x.PalletTypeCode, 1, 2);
		validator.Length(x => x.PalletTiers, 1, 3);
		validator.Length(x => x.PalletBlocks, 1, 3);
		validator.Length(x => x.Pack, 1, 6);
		validator.Length(x => x.UnitWeight, 1, 8);
		validator.Length(x => x.UnitOfMeasurementCode, 2);
		validator.Length(x => x.Length, 1, 8);
		validator.Length(x => x.Width, 1, 8);
		validator.Length(x => x.Height, 1, 8);
		validator.Length(x => x.UnitOfMeasurementCode2, 2);
		validator.Length(x => x.GrossWeightPerPack, 1, 9);
		validator.Length(x => x.UnitOfMeasurementCode3, 2);
		validator.Length(x => x.GrossVolumePerPack, 1, 9);
		validator.Length(x => x.UnitOfMeasurementCode4, 2);
		validator.Length(x => x.PalletExchangeCode, 1);
		return validator.Results;
	}
}
