using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v7060;

[Segment("PO8")]
public class PO8_UnmarkedTradeItemPhysicalDetails : EdiX12Segment
{
	[Position(01)]
	public string AssignedIdentification { get; set; }

	[Position(02)]
	public int? Pack { get; set; }

	[Position(03)]
	public decimal? Size { get; set; }

	[Position(04)]
	public string UnitOrBasisForMeasurementCode { get; set; }

	[Position(05)]
	public string PackagingCode { get; set; }

	[Position(06)]
	public C067_CompositeProductWeightBasis CompositeProductWeightBasis { get; set; }

	[Position(07)]
	public decimal? GrossVolumePerPack { get; set; }

	[Position(08)]
	public string UnitOrBasisForMeasurementCode2 { get; set; }

	[Position(09)]
	public decimal? Length { get; set; }

	[Position(10)]
	public string UnitOrBasisForMeasurementCode3 { get; set; }

	[Position(11)]
	public decimal? Width { get; set; }

	[Position(12)]
	public string UnitOrBasisForMeasurementCode4 { get; set; }

	[Position(13)]
	public decimal? Height { get; set; }

	[Position(14)]
	public string UnitOrBasisForMeasurementCode5 { get; set; }

	[Position(15)]
	public decimal? ItemDepth { get; set; }

	[Position(16)]
	public string UnitOrBasisForMeasurementCode6 { get; set; }

	[Position(17)]
	public int? InnerPack { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<PO8_UnmarkedTradeItemPhysicalDetails>(this);
		validator.Required(x=>x.AssignedIdentification);
		validator.IfOneIsFilled_AllAreRequired(x=>x.Size, x=>x.UnitOrBasisForMeasurementCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.GrossVolumePerPack, x=>x.UnitOrBasisForMeasurementCode2);
		validator.IfOneIsFilled_AllAreRequired(x=>x.Length, x=>x.UnitOrBasisForMeasurementCode3);
		validator.OnlyOneOf(x=>x.Length, x=>x.ItemDepth);
		validator.IfOneIsFilled_AllAreRequired(x=>x.Width, x=>x.UnitOrBasisForMeasurementCode4);
		validator.IfOneIsFilled_AllAreRequired(x=>x.Height, x=>x.UnitOrBasisForMeasurementCode5);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ItemDepth, x=>x.UnitOrBasisForMeasurementCode6);
		validator.Length(x => x.AssignedIdentification, 1, 20);
		validator.Length(x => x.Pack, 1, 6);
		validator.Length(x => x.Size, 1, 8);
		validator.Length(x => x.UnitOrBasisForMeasurementCode, 2);
		validator.Length(x => x.PackagingCode, 3, 5);
		validator.Length(x => x.GrossVolumePerPack, 1, 9);
		validator.Length(x => x.UnitOrBasisForMeasurementCode2, 2);
		validator.Length(x => x.Length, 1, 8);
		validator.Length(x => x.UnitOrBasisForMeasurementCode3, 2);
		validator.Length(x => x.Width, 1, 8);
		validator.Length(x => x.UnitOrBasisForMeasurementCode4, 2);
		validator.Length(x => x.Height, 1, 8);
		validator.Length(x => x.UnitOrBasisForMeasurementCode5, 2);
		validator.Length(x => x.ItemDepth, 1, 6);
		validator.Length(x => x.UnitOrBasisForMeasurementCode6, 2);
		validator.Length(x => x.InnerPack, 1, 6);
		return validator.Results;
	}
}
