using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Internals;

namespace Eddy.x12.Models;

[Segment("FU3")]
public class FU3_ProductDetail : EdiX12Segment
{
	[Position(01)]
	public string ProductName { get; set; }

	[Position(02)]
	public string UnitOrBasisForMeasurementCode { get; set; }

	[Position(03)]
	public string BrandName { get; set; }

	[Position(04)]
	public string EntityIdentifierCode { get; set; }

	[Position(05)]
	public string Name { get; set; }

	[Position(06)]
	public string ProductLabel { get; set; }

	[Position(07)]
	public string Description { get; set; }

	[Position(08)]
	public string WeightQualifier { get; set; }

	[Position(09)]
	public string WeightUnitCode { get; set; }

	[Position(10)]
	public decimal? UnitWeight { get; set; }

	[Position(11)]
	public string UnitOrBasisForMeasurementCode2 { get; set; }

	[Position(12)]
	public decimal? Height { get; set; }

	[Position(13)]
	public string UnitOrBasisForMeasurementCode3 { get; set; }

	[Position(14)]
	public decimal? Width { get; set; }

	[Position(15)]
	public string UnitOrBasisForMeasurementCode4 { get; set; }

	[Position(16)]
	public decimal? ItemDepth { get; set; }

	[Position(17)]
	public string UnitOrBasisForMeasurementCode5 { get; set; }

	[Position(18)]
	public decimal? Volume { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<FU3_ProductDetail>(this);
		validator.Required(x=>x.ProductName);
		validator.IfOneIsFilled_AllAreRequired(x=>x.EntityIdentifierCode, x=>x.Name);
		validator.IfOneIsFilled_AllAreRequired(x=>x.UnitOrBasisForMeasurementCode2, x=>x.Height);
		validator.IfOneIsFilled_AllAreRequired(x=>x.UnitOrBasisForMeasurementCode3, x=>x.Width);
		validator.IfOneIsFilled_AllAreRequired(x=>x.UnitOrBasisForMeasurementCode4, x=>x.ItemDepth);
		validator.IfOneIsFilled_AllAreRequired(x=>x.UnitOrBasisForMeasurementCode5, x=>x.Volume);
		validator.Length(x => x.ProductName, 1, 60);
		validator.Length(x => x.UnitOrBasisForMeasurementCode, 2);
		validator.Length(x => x.BrandName, 1, 60);
		validator.Length(x => x.EntityIdentifierCode, 2, 3);
		validator.Length(x => x.Name, 1, 60);
		validator.Length(x => x.ProductLabel, 1, 60);
		validator.Length(x => x.Description, 1, 80);
		validator.Length(x => x.WeightQualifier, 1, 2);
		validator.Length(x => x.WeightUnitCode, 1);
		validator.Length(x => x.UnitWeight, 1, 8);
		validator.Length(x => x.UnitOrBasisForMeasurementCode2, 2);
		validator.Length(x => x.Height, 1, 8);
		validator.Length(x => x.UnitOrBasisForMeasurementCode3, 2);
		validator.Length(x => x.Width, 1, 8);
		validator.Length(x => x.UnitOrBasisForMeasurementCode4, 2);
		validator.Length(x => x.ItemDepth, 1, 6);
		validator.Length(x => x.UnitOrBasisForMeasurementCode5, 2);
		validator.Length(x => x.Volume, 1, 8);
		return validator.Results;
	}
}
