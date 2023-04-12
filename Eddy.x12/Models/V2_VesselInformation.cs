using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models;

[Segment("V2")]
public class V2_VesselInformation : EdiX12Segment
{
	[Position(01)]
	public string LocationIdentifier { get; set; }

	[Position(02)]
	public string ReferenceIdentification { get; set; }

	[Position(03)]
	public decimal? Weight { get; set; }

	[Position(04)]
	public string WeightUnitCode { get; set; }

	[Position(05)]
	public decimal? Weight2 { get; set; }

	[Position(06)]
	public string WeightUnitCode2 { get; set; }

	[Position(07)]
	public decimal? Weight3 { get; set; }

	[Position(08)]
	public string WeightUnitCode3 { get; set; }

	[Position(09)]
	public decimal? Weight4 { get; set; }

	[Position(10)]
	public string WeightUnitCode4 { get; set; }

	[Position(11)]
	public decimal? Weight5 { get; set; }

	[Position(12)]
	public string WeightUnitCode5 { get; set; }

	[Position(13)]
	public string Name { get; set; }

	[Position(14)]
	public decimal? Length { get; set; }

	[Position(15)]
	public string UnitOrBasisForMeasurementCode { get; set; }

	[Position(16)]
	public decimal? Quantity { get; set; }

	[Position(17)]
	public decimal? Quantity2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<V2_VesselInformation>(this);
		validator.IfOneIsFilled_AllAreRequired(x=>x.Weight, x=>x.WeightUnitCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.Weight2, x=>x.WeightUnitCode2);
		validator.IfOneIsFilled_AllAreRequired(x=>x.Weight3, x=>x.WeightUnitCode3);
		validator.IfOneIsFilled_AllAreRequired(x=>x.Weight4, x=>x.WeightUnitCode4);
		validator.IfOneIsFilled_AllAreRequired(x=>x.Weight5, x=>x.WeightUnitCode5);
		validator.Length(x => x.LocationIdentifier, 1, 30);
		validator.Length(x => x.ReferenceIdentification, 1, 80);
		validator.Length(x => x.Weight, 1, 10);
		validator.Length(x => x.WeightUnitCode, 1);
		validator.Length(x => x.Weight2, 1, 10);
		validator.Length(x => x.WeightUnitCode2, 1);
		validator.Length(x => x.Weight3, 1, 10);
		validator.Length(x => x.WeightUnitCode3, 1);
		validator.Length(x => x.Weight4, 1, 10);
		validator.Length(x => x.WeightUnitCode4, 1);
		validator.Length(x => x.Weight5, 1, 10);
		validator.Length(x => x.WeightUnitCode5, 1);
		validator.Length(x => x.Name, 1, 60);
		validator.Length(x => x.Length, 1, 8);
		validator.Length(x => x.UnitOrBasisForMeasurementCode, 2);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.Quantity2, 1, 15);
		return validator.Results;
	}
}
