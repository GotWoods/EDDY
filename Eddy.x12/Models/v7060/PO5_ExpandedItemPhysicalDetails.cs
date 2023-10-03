using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7060.Composites;

namespace Eddy.x12.Models.v7060;

[Segment("PO5")]
public class PO5_ExpandedItemPhysicalDetails : EdiX12Segment
{
	[Position(01)]
	public int? Pack { get; set; }

	[Position(02)]
	public decimal? Size { get; set; }

	[Position(03)]
	public string UnitOrBasisForMeasurementCode { get; set; }

	[Position(04)]
	public decimal? Volume { get; set; }

	[Position(05)]
	public string VolumeUnitQualifier { get; set; }

	[Position(06)]
	public decimal? Length { get; set; }

	[Position(07)]
	public string UnitOrBasisForMeasurementCode2 { get; set; }

	[Position(08)]
	public decimal? Width { get; set; }

	[Position(09)]
	public string UnitOrBasisForMeasurementCode3 { get; set; }

	[Position(10)]
	public decimal? Height { get; set; }

	[Position(11)]
	public string UnitOrBasisForMeasurementCode4 { get; set; }

	[Position(12)]
	public decimal? ItemDepth { get; set; }

	[Position(13)]
	public string UnitOrBasisForMeasurementCode5 { get; set; }

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

	[Position(19)]
	public C067_CompositeProductWeightBasis CompositeProductWeightBasis { get; set; }

	[Position(20)]
	public int? TareWeight { get; set; }

	[Position(21)]
	public string UnitOrBasisForMeasurementCode6 { get; set; }

	[Position(22)]
	public decimal? Quantity { get; set; }

	[Position(23)]
	public string PegCode { get; set; }

	[Position(24)]
	public string UnitOrBasisForMeasurementCode7 { get; set; }

	[Position(25)]
	public string ReferenceIdentification { get; set; }

	[Position(26)]
	public decimal? XPeg { get; set; }

	[Position(27)]
	public decimal? YPeg { get; set; }

	[Position(28)]
	public string ReferenceIdentification2 { get; set; }

	[Position(29)]
	public decimal? XPeg2 { get; set; }

	[Position(30)]
	public decimal? YPeg2 { get; set; }

	[Position(31)]
	public string ReferenceIdentification3 { get; set; }

	[Position(32)]
	public decimal? XPeg3 { get; set; }

	[Position(33)]
	public decimal? YPeg3 { get; set; }

	[Position(34)]
	public string UnmarkedNumberOfInnerPacks { get; set; }

	[Position(35)]
	public string UnmarkedNumberOfInnerPackLayers { get; set; }

	[Position(36)]
	public string UnmarkedNumberOfInnerPacksPerLayer { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<PO5_ExpandedItemPhysicalDetails>(this);
		validator.IfOneIsFilled_AllAreRequired(x=>x.Size, x=>x.UnitOrBasisForMeasurementCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.Volume, x=>x.VolumeUnitQualifier);
		validator.IfOneIsFilled_AllAreRequired(x=>x.Length, x=>x.UnitOrBasisForMeasurementCode2);
		validator.OnlyOneOf(x=>x.Length, x=>x.ItemDepth);
		validator.IfOneIsFilled_AllAreRequired(x=>x.Width, x=>x.UnitOrBasisForMeasurementCode3);
		validator.IfOneIsFilled_AllAreRequired(x=>x.Height, x=>x.UnitOrBasisForMeasurementCode4);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ItemDepth, x=>x.UnitOrBasisForMeasurementCode5);
		validator.ARequiresB(x=>x.AssignedIdentification2, x=>x.AssignedIdentification);
		validator.IfOneIsFilled_AllAreRequired(x=>x.TareWeight, x=>x.UnitOrBasisForMeasurementCode6);
		validator.IfOneIsFilled_AllAreRequired(x=>x.Quantity, x=>x.PegCode);
		validator.ARequiresB(x=>x.ReferenceIdentification, x=>x.UnitOrBasisForMeasurementCode7);
		validator.IfOneIsFilled_AllAreRequired(x=>x.PegCode, x=>x.YPeg);
		validator.ARequiresB(x=>x.ReferenceIdentification2, x=>x.UnitOrBasisForMeasurementCode7);
		validator.ARequiresB(x=>x.ReferenceIdentification3, x=>x.UnitOrBasisForMeasurementCode7);
		validator.IfOneIsFilled_AllAreRequired(x=>x.UnmarkedNumberOfInnerPackLayers, x=>x.UnmarkedNumberOfInnerPacksPerLayer);
		validator.Length(x => x.Pack, 1, 6);
		validator.Length(x => x.Size, 1, 8);
		validator.Length(x => x.UnitOrBasisForMeasurementCode, 2);
		validator.Length(x => x.Volume, 1, 8);
		validator.Length(x => x.VolumeUnitQualifier, 1);
		validator.Length(x => x.Length, 1, 8);
		validator.Length(x => x.UnitOrBasisForMeasurementCode2, 2);
		validator.Length(x => x.Width, 1, 8);
		validator.Length(x => x.UnitOrBasisForMeasurementCode3, 2);
		validator.Length(x => x.Height, 1, 8);
		validator.Length(x => x.UnitOrBasisForMeasurementCode4, 2);
		validator.Length(x => x.ItemDepth, 1, 6);
		validator.Length(x => x.UnitOrBasisForMeasurementCode5, 2);
		validator.Length(x => x.InnerPack, 1, 6);
		validator.Length(x => x.SurfaceLayerPositionCode, 2);
		validator.Length(x => x.AssignedIdentification, 1, 20);
		validator.Length(x => x.AssignedIdentification2, 1, 20);
		validator.Length(x => x.Number, 1, 9);
		validator.Length(x => x.TareWeight, 3, 8);
		validator.Length(x => x.UnitOrBasisForMeasurementCode6, 2);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.PegCode, 1);
		validator.Length(x => x.UnitOrBasisForMeasurementCode7, 2);
		validator.Length(x => x.ReferenceIdentification, 1, 80);
		validator.Length(x => x.XPeg, 1, 6);
		validator.Length(x => x.YPeg, 1, 6);
		validator.Length(x => x.ReferenceIdentification2, 1, 80);
		validator.Length(x => x.XPeg2, 1, 6);
		validator.Length(x => x.YPeg2, 1, 6);
		validator.Length(x => x.ReferenceIdentification3, 1, 80);
		validator.Length(x => x.XPeg3, 1, 6);
		validator.Length(x => x.YPeg3, 1, 6);
		validator.Length(x => x.UnmarkedNumberOfInnerPacks, 1, 6);
		validator.Length(x => x.UnmarkedNumberOfInnerPackLayers, 1, 2);
		validator.Length(x => x.UnmarkedNumberOfInnerPacksPerLayer, 1, 2);
		return validator.Results;
	}
}
