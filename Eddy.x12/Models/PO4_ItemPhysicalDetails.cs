using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models;

[Segment("PO4")]
public class PO4_ItemPhysicalDetails : EdiX12Segment
{
	[Position(01)]
	public int? Pack { get; set; }

	[Position(02)]
	public decimal? Size { get; set; }

	[Position(03)]
	public string UnitOrBasisForMeasurementCode { get; set; }

	[Position(04)]
	public string PackagingCode { get; set; }

	[Position(05)]
	public string WeightQualifier { get; set; }

	[Position(06)]
	public decimal? GrossWeightPerPack { get; set; }

	[Position(07)]
	public string UnitOrBasisForMeasurementCode2 { get; set; }

	[Position(08)]
	public decimal? GrossVolumePerPack { get; set; }

	[Position(09)]
	public string UnitOrBasisForMeasurementCode3 { get; set; }

	[Position(10)]
	public decimal? Length { get; set; }

	[Position(11)]
	public decimal? Width { get; set; }

	[Position(12)]
	public decimal? Height { get; set; }

	[Position(13)]
	public string UnitOrBasisForMeasurementCode4 { get; set; }

	[Position(14)]
	public int? InnerPack { get; set; }

	[Position(15)]
	public string SurfaceLayerPositionCode { get; set; }

	[Position(16)]
	public string AssignedIdentification { get; set; }

	[Position(17)]
	public string AssignedIdentification2 { get; set; }

	[Position(18)]
	public int? Number { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<PO4_ItemPhysicalDetails>(this);
		validator.IfOneIsFilled_AllAreRequired(x=>x.Size, x=>x.UnitOrBasisForMeasurementCode);
		validator.ARequiresB(x=>x.WeightQualifier, x=>x.GrossWeightPerPack);
		validator.IfOneIsFilled_AllAreRequired(x=>x.GrossWeightPerPack, x=>x.UnitOrBasisForMeasurementCode2);
		validator.IfOneIsFilled_AllAreRequired(x=>x.GrossVolumePerPack, x=>x.UnitOrBasisForMeasurementCode3);
		validator.ARequiresB(x=>x.Length, x=>x.UnitOrBasisForMeasurementCode4);
		validator.ARequiresB(x=>x.Width, x=>x.UnitOrBasisForMeasurementCode4);
		validator.ARequiresB(x=>x.Height, x=>x.UnitOrBasisForMeasurementCode4);
		validator.IfOneIsFilledThenAtLeastOne(x=>x.UnitOrBasisForMeasurementCode4, x=>x.Length, x=>x.Width, x=>x.Height);
		validator.ARequiresB(x=>x.AssignedIdentification2, x=>x.AssignedIdentification);
		validator.ARequiresB(x=>x.Number, x=>x.PackagingCode);
		validator.Length(x => x.Pack, 1, 6);
		validator.Length(x => x.Size, 1, 8);
		validator.Length(x => x.UnitOrBasisForMeasurementCode, 2);
		validator.Length(x => x.PackagingCode, 3, 5);
		validator.Length(x => x.WeightQualifier, 1, 2);
		validator.Length(x => x.GrossWeightPerPack, 1, 9);
		validator.Length(x => x.UnitOrBasisForMeasurementCode2, 2);
		validator.Length(x => x.GrossVolumePerPack, 1, 9);
		validator.Length(x => x.UnitOrBasisForMeasurementCode3, 2);
		validator.Length(x => x.Length, 1, 8);
		validator.Length(x => x.Width, 1, 8);
		validator.Length(x => x.Height, 1, 8);
		validator.Length(x => x.UnitOrBasisForMeasurementCode4, 2);
		validator.Length(x => x.InnerPack, 1, 6);
		validator.Length(x => x.SurfaceLayerPositionCode, 2);
		validator.Length(x => x.AssignedIdentification, 1, 20);
		validator.Length(x => x.AssignedIdentification2, 1, 20);
		validator.Length(x => x.Number, 1, 9);
		return validator.Results;
	}
}
