using Eddy.Core.Attributes;
using Eddy.Core.Validation;


namespace Eddy.x12.Models;

[Segment("IT3")]
public class IT3_AdditionalItemData : EdiX12Segment
{
	[Position(01)]
	public decimal? NumberOfUnitsShipped { get; set; }

	[Position(02)]
	public string UnitOrBasisForMeasurementCode { get; set; }

	[Position(03)]
	public string ShipmentOrderStatusCode { get; set; }

	[Position(04)]
	public decimal? QuantityDifference { get; set; }

	[Position(05)]
	public string ChangeReasonCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<IT3_AdditionalItemData>(this);
		validator.IfOneIsFilled_AllAreRequired(x=>x.NumberOfUnitsShipped, x=>x.UnitOrBasisForMeasurementCode);
		validator.Length(x => x.NumberOfUnitsShipped, 1, 10);
		validator.Length(x => x.UnitOrBasisForMeasurementCode, 2);
		validator.Length(x => x.ShipmentOrderStatusCode, 2);
		validator.Length(x => x.QuantityDifference, 1, 9);
		validator.Length(x => x.ChangeReasonCode, 2);
		return validator.Results;
	}
}
