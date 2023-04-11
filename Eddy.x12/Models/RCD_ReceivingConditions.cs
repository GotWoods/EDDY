using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models;

[Segment("RCD")]
public class RCD_ReceivingConditions : EdiX12Segment
{
	[Position(01)]
	public string AssignedIdentification { get; set; }

	[Position(02)]
	public decimal? QuantityUnitsReceivedOrAccepted { get; set; }

	[Position(03)]
	public C001_CompositeUnitOfMeasure CompositeUnitOfMeasure { get; set; }

	[Position(04)]
	public decimal? QuantityUnitsReturned { get; set; }

	[Position(05)]
	public C001_CompositeUnitOfMeasure CompositeUnitOfMeasure2 { get; set; }

	[Position(06)]
	public decimal? QuantityInQuestion { get; set; }

	[Position(07)]
	public C001_CompositeUnitOfMeasure CompositeUnitOfMeasure3 { get; set; }

	[Position(08)]
	public string ReceivingConditionCode { get; set; }

	[Position(09)]
	public decimal? QuantityInQuestion2 { get; set; }

	[Position(10)]
	public C001_CompositeUnitOfMeasure CompositeUnitOfMeasure4 { get; set; }

	[Position(11)]
	public string ReceivingConditionCode2 { get; set; }

	[Position(12)]
	public decimal? QuantityInQuestion3 { get; set; }

	[Position(13)]
	public C001_CompositeUnitOfMeasure CompositeUnitOfMeasure5 { get; set; }

	[Position(14)]
	public string ReceivingConditionCode3 { get; set; }

	[Position(15)]
	public decimal? QuantityInQuestion4 { get; set; }

	[Position(16)]
	public C001_CompositeUnitOfMeasure CompositeUnitOfMeasure6 { get; set; }

	[Position(17)]
	public string ReceivingConditionCode4 { get; set; }

	[Position(18)]
	public decimal? QuantityInQuestion5 { get; set; }

	[Position(19)]
	public C001_CompositeUnitOfMeasure CompositeUnitOfMeasure7 { get; set; }

	[Position(20)]
	public string ReceivingConditionCode5 { get; set; }

	[Position(21)]
	public decimal? Quantity { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<RCD_ReceivingConditions>(this);
		validator.IfOneIsFilled_AllAreRequired(x=>x.QuantityUnitsReceivedOrAccepted, x=>x.CompositeUnitOfMeasure);
		validator.IfOneIsFilled_AllAreRequired(x=>x.QuantityUnitsReturned, x=>x.CompositeUnitOfMeasure2);
		validator.Length(x => x.AssignedIdentification, 1, 20);
		validator.Length(x => x.QuantityUnitsReceivedOrAccepted, 1, 9);
		validator.Length(x => x.QuantityUnitsReturned, 1, 9);
		validator.Length(x => x.QuantityInQuestion, 1, 9);
		validator.Length(x => x.ReceivingConditionCode, 2);
		validator.Length(x => x.QuantityInQuestion2, 1, 9);
		validator.Length(x => x.ReceivingConditionCode2, 2);
		validator.Length(x => x.QuantityInQuestion3, 1, 9);
		validator.Length(x => x.ReceivingConditionCode3, 2);
		validator.Length(x => x.QuantityInQuestion4, 1, 9);
		validator.Length(x => x.ReceivingConditionCode4, 2);
		validator.Length(x => x.QuantityInQuestion5, 1, 9);
		validator.Length(x => x.ReceivingConditionCode5, 2);
		validator.Length(x => x.Quantity, 1, 15);
		return validator.Results;
	}
}
