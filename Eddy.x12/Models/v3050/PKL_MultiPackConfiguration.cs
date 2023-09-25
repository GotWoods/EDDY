using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3050;

[Segment("PKL")]
public class PKL_MultiPackConfiguration : EdiX12Segment
{
	[Position(01)]
	public string ProductServiceIDQualifier { get; set; }

	[Position(02)]
	public string ProductServiceID { get; set; }

	[Position(03)]
	public string UnitOrBasisForMeasurementCode { get; set; }

	[Position(04)]
	public decimal? Quantity { get; set; }

	[Position(05)]
	public decimal? Height { get; set; }

	[Position(06)]
	public decimal? Width { get; set; }

	[Position(07)]
	public decimal? ItemDepth { get; set; }

	[Position(08)]
	public string UnitOrBasisForMeasurementCode2 { get; set; }

	[Position(09)]
	public decimal? GrossWeightPerPack { get; set; }

	[Position(10)]
	public string UnitOrBasisForMeasurementCode3 { get; set; }

	[Position(11)]
	public decimal? GrossVolumePerPack { get; set; }

	[Position(12)]
	public string UnitOrBasisForMeasurementCode4 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<PKL_MultiPackConfiguration>(this);
		validator.Required(x=>x.ProductServiceIDQualifier);
		validator.Required(x=>x.ProductServiceID);
		validator.Required(x=>x.UnitOrBasisForMeasurementCode);
		validator.Required(x=>x.Quantity);
		validator.ARequiresB(x=>x.Height, x=>x.UnitOrBasisForMeasurementCode2);
		validator.ARequiresB(x=>x.Width, x=>x.UnitOrBasisForMeasurementCode2);
		validator.ARequiresB(x=>x.ItemDepth, x=>x.UnitOrBasisForMeasurementCode2);
		validator.IfOneIsFilledThenAtLeastOne(x=>x.UnitOrBasisForMeasurementCode2, x=>x.Height, x=>x.Width, x=>x.ItemDepth);
		validator.IfOneIsFilled_AllAreRequired(x=>x.GrossWeightPerPack, x=>x.UnitOrBasisForMeasurementCode3);
		validator.IfOneIsFilled_AllAreRequired(x=>x.GrossVolumePerPack, x=>x.UnitOrBasisForMeasurementCode4);
		validator.Length(x => x.ProductServiceIDQualifier, 2);
		validator.Length(x => x.ProductServiceID, 1, 40);
		validator.Length(x => x.UnitOrBasisForMeasurementCode, 2);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.Height, 1, 8);
		validator.Length(x => x.Width, 1, 8);
		validator.Length(x => x.ItemDepth, 1, 6);
		validator.Length(x => x.UnitOrBasisForMeasurementCode2, 2);
		validator.Length(x => x.GrossWeightPerPack, 1, 9);
		validator.Length(x => x.UnitOrBasisForMeasurementCode3, 2);
		validator.Length(x => x.GrossVolumePerPack, 1, 9);
		validator.Length(x => x.UnitOrBasisForMeasurementCode4, 2);
		return validator.Results;
	}
}
