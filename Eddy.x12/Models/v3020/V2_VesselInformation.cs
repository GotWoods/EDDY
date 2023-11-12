using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3020;

[Segment("V2")]
public class V2_VesselInformation : EdiX12Segment
{
	[Position(01)]
	public string LocationIdentifier { get; set; }

	[Position(02)]
	public string ReferenceNumber { get; set; }

	[Position(03)]
	public string WeightUnitQualifier { get; set; }

	[Position(04)]
	public decimal? Weight { get; set; }

	[Position(05)]
	public string WeightUnitQualifier2 { get; set; }

	[Position(06)]
	public decimal? Weight2 { get; set; }

	[Position(07)]
	public string WeightUnitQualifier3 { get; set; }

	[Position(08)]
	public decimal? Weight3 { get; set; }

	[Position(09)]
	public string WeightUnitQualifier4 { get; set; }

	[Position(10)]
	public decimal? Weight4 { get; set; }

	[Position(11)]
	public string WeightUnitQualifier5 { get; set; }

	[Position(12)]
	public decimal? Weight5 { get; set; }

	[Position(13)]
	public string Name { get; set; }

	[Position(14)]
	public decimal? Length { get; set; }

	[Position(15)]
	public string UnitOfMeasurementCode { get; set; }

	[Position(16)]
	public decimal? Quantity { get; set; }

	[Position(17)]
	public decimal? Quantity2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<V2_VesselInformation>(this);
		validator.IfOneIsFilled_AllAreRequired(x=>x.WeightUnitQualifier, x=>x.Weight);
		validator.IfOneIsFilled_AllAreRequired(x=>x.WeightUnitQualifier2, x=>x.Weight2);
		validator.IfOneIsFilled_AllAreRequired(x=>x.WeightUnitQualifier3, x=>x.Weight3);
		validator.IfOneIsFilled_AllAreRequired(x=>x.WeightUnitQualifier4, x=>x.Weight4);
		validator.IfOneIsFilled_AllAreRequired(x=>x.WeightUnitQualifier5, x=>x.Weight5);
		validator.Length(x => x.LocationIdentifier, 1, 25);
		validator.Length(x => x.ReferenceNumber, 1, 30);
		validator.Length(x => x.WeightUnitQualifier, 1);
		validator.Length(x => x.Weight, 1, 8);
		validator.Length(x => x.WeightUnitQualifier2, 1);
		validator.Length(x => x.Weight2, 1, 8);
		validator.Length(x => x.WeightUnitQualifier3, 1);
		validator.Length(x => x.Weight3, 1, 8);
		validator.Length(x => x.WeightUnitQualifier4, 1);
		validator.Length(x => x.Weight4, 1, 8);
		validator.Length(x => x.WeightUnitQualifier5, 1);
		validator.Length(x => x.Weight5, 1, 8);
		validator.Length(x => x.Name, 1, 35);
		validator.Length(x => x.Length, 1, 8);
		validator.Length(x => x.UnitOfMeasurementCode, 2);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.Quantity2, 1, 15);
		return validator.Results;
	}
}
