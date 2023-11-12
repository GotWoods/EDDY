using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("RCD")]
public class RCD_ReceivingConditions : EdiX12Segment
{
	[Position(01)]
	public string AssignedIdentification { get; set; }

	[Position(02)]
	public decimal? QuantityUnitsReceived { get; set; }

	[Position(03)]
	public string UnitOfMeasurementCode { get; set; }

	[Position(04)]
	public decimal? QuantityUnitsReturned { get; set; }

	[Position(05)]
	public string UnitOfMeasurementCode2 { get; set; }

	[Position(06)]
	public decimal? QuantityInQuestion { get; set; }

	[Position(07)]
	public string UnitOfMeasurementCode3 { get; set; }

	[Position(08)]
	public string ReceivingConditionCode { get; set; }

	[Position(09)]
	public decimal? QuantityInQuestion2 { get; set; }

	[Position(10)]
	public string UnitOfMeasurementCode4 { get; set; }

	[Position(11)]
	public string ReceivingConditionCode2 { get; set; }

	[Position(12)]
	public decimal? QuantityInQuestion3 { get; set; }

	[Position(13)]
	public string UnitOfMeasurementCode5 { get; set; }

	[Position(14)]
	public string ReceivingConditionCode3 { get; set; }

	[Position(15)]
	public decimal? QuantityInQuestion4 { get; set; }

	[Position(16)]
	public string UnitOfMeasurementCode6 { get; set; }

	[Position(17)]
	public string ReceivingConditionCode4 { get; set; }

	[Position(18)]
	public decimal? QuantityInQuestion5 { get; set; }

	[Position(19)]
	public string UnitOfMeasurementCode7 { get; set; }

	[Position(20)]
	public string ReceivingConditionCode5 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<RCD_ReceivingConditions>(this);
		validator.Length(x => x.AssignedIdentification, 1, 6);
		validator.Length(x => x.QuantityUnitsReceived, 1, 9);
		validator.Length(x => x.UnitOfMeasurementCode, 2);
		validator.Length(x => x.QuantityUnitsReturned, 1, 9);
		validator.Length(x => x.UnitOfMeasurementCode2, 2);
		validator.Length(x => x.QuantityInQuestion, 1, 9);
		validator.Length(x => x.UnitOfMeasurementCode3, 2);
		validator.Length(x => x.ReceivingConditionCode, 2);
		validator.Length(x => x.QuantityInQuestion2, 1, 9);
		validator.Length(x => x.UnitOfMeasurementCode4, 2);
		validator.Length(x => x.ReceivingConditionCode2, 2);
		validator.Length(x => x.QuantityInQuestion3, 1, 9);
		validator.Length(x => x.UnitOfMeasurementCode5, 2);
		validator.Length(x => x.ReceivingConditionCode3, 2);
		validator.Length(x => x.QuantityInQuestion4, 1, 9);
		validator.Length(x => x.UnitOfMeasurementCode6, 2);
		validator.Length(x => x.ReceivingConditionCode4, 2);
		validator.Length(x => x.QuantityInQuestion5, 1, 9);
		validator.Length(x => x.UnitOfMeasurementCode7, 2);
		validator.Length(x => x.ReceivingConditionCode5, 2);
		return validator.Results;
	}
}
