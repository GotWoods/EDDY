using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("PO4")]
public class PO4_ItemPhysicalDetails : EdiX12Segment
{
	[Position(01)]
	public int? Pack { get; set; }

	[Position(02)]
	public decimal? Size { get; set; }

	[Position(03)]
	public string UnitOfMeasurementCode { get; set; }

	[Position(04)]
	public string PackagingCode { get; set; }

	[Position(05)]
	public string WeightQualifier { get; set; }

	[Position(06)]
	public decimal? GrossWeightPerPack { get; set; }

	[Position(07)]
	public string UnitOfMeasurementCode2 { get; set; }

	[Position(08)]
	public decimal? GrossVolumePerPack { get; set; }

	[Position(09)]
	public string UnitOfMeasurementCode3 { get; set; }

	[Position(10)]
	public decimal? Length { get; set; }

	[Position(11)]
	public decimal? Width { get; set; }

	[Position(12)]
	public decimal? Height { get; set; }

	[Position(13)]
	public string UnitOfMeasurementCode4 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<PO4_ItemPhysicalDetails>(this);
		validator.Length(x => x.Pack, 1, 6);
		validator.Length(x => x.Size, 1, 8);
		validator.Length(x => x.UnitOfMeasurementCode, 2);
		validator.Length(x => x.PackagingCode, 5);
		validator.Length(x => x.WeightQualifier, 1, 2);
		validator.Length(x => x.GrossWeightPerPack, 1, 9);
		validator.Length(x => x.UnitOfMeasurementCode2, 2);
		validator.Length(x => x.GrossVolumePerPack, 1, 9);
		validator.Length(x => x.UnitOfMeasurementCode3, 2);
		validator.Length(x => x.Length, 1, 8);
		validator.Length(x => x.Width, 1, 8);
		validator.Length(x => x.Height, 1, 8);
		validator.Length(x => x.UnitOfMeasurementCode4, 2);
		return validator.Results;
	}
}
