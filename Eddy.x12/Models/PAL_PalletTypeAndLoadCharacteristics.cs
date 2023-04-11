using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Internals;

namespace Eddy.x12.Models;

[Segment("PAL")]
public class PAL_PalletTypeAndLoadCharacteristics : EdiX12Segment
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
	public string UnitOrBasisForMeasurementCode { get; set; }

	[Position(07)]
	public decimal? Length { get; set; }

	[Position(08)]
	public decimal? Width { get; set; }

	[Position(09)]
	public decimal? Height { get; set; }

	[Position(10)]
	public string UnitOrBasisForMeasurementCode2 { get; set; }

	[Position(11)]
	public decimal? GrossWeightPerPack { get; set; }

	[Position(12)]
	public string UnitOrBasisForMeasurementCode3 { get; set; }

	[Position(13)]
	public decimal? GrossVolumePerPack { get; set; }

	[Position(14)]
	public string UnitOrBasisForMeasurementCode4 { get; set; }

	[Position(15)]
	public string PalletExchangeCode { get; set; }

	[Position(16)]
	public int? InnerPack { get; set; }

	[Position(17)]
	public string PalletStructureCode { get; set; }

	[Position(18)]
	public decimal? Quantity { get; set; }

	[Position(19)]
	public string YesNoConditionOrResponseCode { get; set; }

	[Position(20)]
	public string Description { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<PAL_PalletTypeAndLoadCharacteristics>(this);
		validator.IfOneIsFilled_AllAreRequired(x=>x.UnitWeight, x=>x.UnitOrBasisForMeasurementCode);
		validator.ARequiresB(x=>x.Length, x=>x.UnitOrBasisForMeasurementCode2);
		validator.ARequiresB(x=>x.Width, x=>x.UnitOrBasisForMeasurementCode2);
		validator.ARequiresB(x=>x.Height, x=>x.UnitOrBasisForMeasurementCode2);
		validator.IfOneIsFilledThenAtLeastOne(x=>x.UnitOrBasisForMeasurementCode2, x=>x.Length, x=>x.Width, x=>x.Height);
		validator.IfOneIsFilled_AllAreRequired(x=>x.GrossWeightPerPack, x=>x.UnitOrBasisForMeasurementCode3);
		validator.IfOneIsFilled_AllAreRequired(x=>x.GrossVolumePerPack, x=>x.UnitOrBasisForMeasurementCode4);
		validator.Length(x => x.PalletTypeCode, 1, 2);
		validator.Length(x => x.PalletTiers, 1, 3);
		validator.Length(x => x.PalletBlocks, 1, 3);
		validator.Length(x => x.Pack, 1, 6);
		validator.Length(x => x.UnitWeight, 1, 8);
		validator.Length(x => x.UnitOrBasisForMeasurementCode, 2);
		validator.Length(x => x.Length, 1, 8);
		validator.Length(x => x.Width, 1, 8);
		validator.Length(x => x.Height, 1, 8);
		validator.Length(x => x.UnitOrBasisForMeasurementCode2, 2);
		validator.Length(x => x.GrossWeightPerPack, 1, 9);
		validator.Length(x => x.UnitOrBasisForMeasurementCode3, 2);
		validator.Length(x => x.GrossVolumePerPack, 1, 9);
		validator.Length(x => x.UnitOrBasisForMeasurementCode4, 2);
		validator.Length(x => x.PalletExchangeCode, 1);
		validator.Length(x => x.InnerPack, 1, 6);
		validator.Length(x => x.PalletStructureCode, 1);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		validator.Length(x => x.Description, 1, 80);
		return validator.Results;
	}
}
