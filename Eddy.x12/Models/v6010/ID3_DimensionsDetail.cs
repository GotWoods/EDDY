using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v6010;

[Segment("ID3")]
public class ID3_DimensionsDetail : EdiX12Segment
{
	[Position(01)]
	public string UPCCaseCode { get; set; }

	[Position(02)]
	public string ProductServiceIDQualifier { get; set; }

	[Position(03)]
	public string ProductServiceID { get; set; }

	[Position(04)]
	public int? Pack { get; set; }

	[Position(05)]
	public int? InnerPack { get; set; }

	[Position(06)]
	public decimal? Height { get; set; }

	[Position(07)]
	public decimal? Width { get; set; }

	[Position(08)]
	public decimal? ItemDepth { get; set; }

	[Position(09)]
	public string UnitOrBasisForMeasurementCode { get; set; }

	[Position(10)]
	public decimal? Weight { get; set; }

	[Position(11)]
	public string UnitOrBasisForMeasurementCode2 { get; set; }

	[Position(12)]
	public decimal? Volume { get; set; }

	[Position(13)]
	public string UnitOrBasisForMeasurementCode3 { get; set; }

	[Position(14)]
	public int? TrayCount { get; set; }

	[Position(15)]
	public decimal? Height2 { get; set; }

	[Position(16)]
	public decimal? Width2 { get; set; }

	[Position(17)]
	public decimal? ItemDepth2 { get; set; }

	[Position(18)]
	public string UnitOrBasisForMeasurementCode4 { get; set; }

	[Position(19)]
	public string NestingCode { get; set; }

	[Position(20)]
	public decimal? Nesting { get; set; }

	[Position(21)]
	public string UnitOrBasisForMeasurementCode5 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<ID3_DimensionsDetail>(this);
		validator.AtLeastOneIsRequired(x=>x.UPCCaseCode, x=>x.ProductServiceIDQualifier);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ProductServiceIDQualifier, x=>x.ProductServiceID);
		validator.IfOneIsFilled_AllAreRequired(x=>x.Weight, x=>x.UnitOrBasisForMeasurementCode2);
		validator.IfOneIsFilled_AllAreRequired(x=>x.Volume, x=>x.UnitOrBasisForMeasurementCode3);
		validator.IfOneIsFilled_AllAreRequired(x=>x.Nesting, x=>x.UnitOrBasisForMeasurementCode5);
		validator.Length(x => x.UPCCaseCode, 12);
		validator.Length(x => x.ProductServiceIDQualifier, 2);
		validator.Length(x => x.ProductServiceID, 1, 80);
		validator.Length(x => x.Pack, 1, 6);
		validator.Length(x => x.InnerPack, 1, 6);
		validator.Length(x => x.Height, 1, 8);
		validator.Length(x => x.Width, 1, 8);
		validator.Length(x => x.ItemDepth, 1, 6);
		validator.Length(x => x.UnitOrBasisForMeasurementCode, 2);
		validator.Length(x => x.Weight, 1, 10);
		validator.Length(x => x.UnitOrBasisForMeasurementCode2, 2);
		validator.Length(x => x.Volume, 1, 8);
		validator.Length(x => x.UnitOrBasisForMeasurementCode3, 2);
		validator.Length(x => x.TrayCount, 1, 3);
		validator.Length(x => x.Height2, 1, 8);
		validator.Length(x => x.Width2, 1, 8);
		validator.Length(x => x.ItemDepth2, 1, 6);
		validator.Length(x => x.UnitOrBasisForMeasurementCode4, 2);
		validator.Length(x => x.NestingCode, 1);
		validator.Length(x => x.Nesting, 1, 6);
		validator.Length(x => x.UnitOrBasisForMeasurementCode5, 2);
		return validator.Results;
	}
}
